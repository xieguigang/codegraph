﻿Imports System.Runtime.CompilerServices
Imports graph.MySQL.graphdb
Imports Microsoft.VisualBasic.Data.visualize.Network.FileStream.Generic
Imports Microsoft.VisualBasic.Data.visualize.Network.Graph
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Serialization.JSON
Imports Oracle.LinuxCompatibility.MySQL.MySqlBuilder
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Public Class KnowlegdeBuilder : Inherits graphdbMySQL

    ReadOnly vocabularyIndex As New Dictionary(Of String, UInteger)
    ReadOnly toLabel As New Dictionary(Of String, knowledge_vocabulary)

    Sub New(graphdb As graphMySQL)
        Call MyBase.New(
            graphdb.graph,
            graphdb.hash_index,
            graphdb.knowledge,
            graphdb.knowledge_vocabulary
        )

        For Each vocabulary As knowledge_vocabulary In knowledge_vocabulary.select(Of knowledge_vocabulary)()
            Call Me.vocabularyIndex.Add(vocabulary.vocabulary.ToLower, vocabulary.id)
            Call Me.toLabel.Add(vocabulary.id, vocabulary)
        Next
    End Sub

    Public Function PullNextGraph(vocabulary As String()) As NetworkGraph
        Dim seed = knowledge _
            .where(knowledge.field("knowledge_term") = 0) _
            .order_by({"graph_size"}, desc:=True) _
            .find(Of knowledge)

        If seed Is Nothing Then
            Return Nothing
        End If

        Dim g As New NetworkGraph
        Dim pull As New List(Of link)(push(g, seed))

        Return g
    End Function

    Private Sub addNode(g As NetworkGraph, seed As knowledge)
        Dim ctor As New Node With {
            .ID = seed.id,
            .label = seed.key,
            .data = New NodeData With {
                .label = seed.display_title,
                .Properties = New Dictionary(Of String, String) From {
                    {NamesOf.REFLECTION_ID_MAPPING_NODETYPE, toLabel(seed.node_type).vocabulary.ToLower}
                },
                .origID = seed.key,
                .size = {seed.graph_size + 1},
                .mass = seed.graph_size,
                .weights = .size,
                .color = toLabel(seed.node_type).color.GetBrush
            }
        }

        Call g.AddNode(ctor, assignId:=False)
    End Sub

    Private Function pullNodes(links As IEnumerable(Of link)) As IEnumerable(Of knowledge)
        Return knowledge _
           .where(knowledge.f("id").in(links.Select(Function(l) l.id).Distinct)) _
           .select(Of knowledge)
    End Function

    Private Function push(g As NetworkGraph, seed As knowledge) As IEnumerable(Of link)
        Dim links As New List(Of link)

        Call links.AddRange(loadViaFromNodes(seed.id, Nothing))
        Call links.AddRange(loadViaToNodes(seed.id, Nothing))

        Dim moreSeeds As New List(Of knowledge)(pullNodes(links))

        Do While True
            Dim excludes As String() = links _
                .Select(Function(l) l.id) _
                .Distinct _
                .Select(Function(i) i.ToString) _
                .ToArray
            Dim a = links.Count
            Dim b = moreSeeds.Count

            For Each seed2 In moreSeeds.ToArray
                Dim pull = loadViaFromNodes(seed2.id, excludes) _
                    .JoinIterates(loadViaToNodes(seed2.id, excludes)) _
                    .ToArray
                links.AddRange(pull)
                moreSeeds.AddRange(pullNodes(pull))
            Next

            If links.Count = a AndAlso moreSeeds.Count = b Then
                Exit Do
            End If
        Loop
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Private Function loadViaFromNodes(seed As UInteger, excludes As IEnumerable(Of String)) As IEnumerable(Of link)
        Return loadLinks(seed, "from_node", "to_node", excludes.SafeQuery.ToArray)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Private Function loadViaToNodes(seed As UInteger, excludes As IEnumerable(Of String)) As IEnumerable(Of link)
        Return loadLinks(seed, "to_node", "from_node", excludes.SafeQuery.ToArray)
    End Function

    Private Function loadLinks(seed As UInteger, field As String, take As String, excludes As String()) As IEnumerable(Of link)
        Dim sql = graph _
           .left_join("knowledge").on(
                f("knowledge.`id`") = f(take)) _
           .left_join("knowledge_vocabulary").on(
                f("knowledge_vocabulary.`id`") = f("node_type")) _
           .where(graph.f(field) = seed, f("knowledge_term") = 0)

        If Not excludes.IsNullOrEmpty Then
            sql = sql.and(Not f("knowledge.`id`").in(excludes))
        End If

        Dim q = sql.select(Of link)("knowledge.id", $"{field} as seed", "weight", "display_title", "vocabulary AS node_type")

        Return q
    End Function

End Class

Public Class link

    <DatabaseField("id")> Public Property id As UInteger
    <DatabaseField("seed")> Public Property seed As UInteger
    <DatabaseField("weight")> Public Property weight As Double
    <DatabaseField("display_title")> Public Property display_title As String
    <DatabaseField("node_type")> Public Property node_type As String

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function

End Class