﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.GraphTheory.Network
Imports Microsoft.VisualBasic.Data.visualize.Network.Analysis
Imports Microsoft.VisualBasic.Data.visualize.Network.FileStream.Generic
Imports Microsoft.VisualBasic.Data.visualize.Network.Graph
Imports Microsoft.VisualBasic.Linq
Imports Node = Microsoft.VisualBasic.Data.visualize.Network.Graph.Node

Public Module CreateKnowledge

    <Extension>
    Public Iterator Function ExtractKnowledges(Of Knowledge As {New, INamedValue, DynamicPropertyBase(Of String)})(graph As NetworkGraph, Optional eps As Double = 0.00000001) As IEnumerable(Of Knowledge)
        ' 解析出所有的信息孤岛
        Dim island = IteratesSubNetworks(Of Node, Edge, NetworkGraph)(graph, singleNodeAsGraph:=False)

        ' 并行计算知识分区
        For Each gc As NetworkGraph In island.Select(Function(g) g.ComputeKnowlegdes(eps))
            Dim knowledges = gc.vertex _
                .GroupBy(Function(i)
                             Return i.data(NamesOf.REFLECTION_ID_MAPPING_NODETYPE)
                         End Function) _
                .ToArray

            For Each term As IGrouping(Of String, Node) In knowledges
                Dim hits As Index(Of String) = term.Select(Function(v) v.label).Indexing
                Dim metadata = gc.graphEdges _
                    .Where(Function(url)
                               Return url.U.label Like hits OrElse url.V.label Like hits
                           End Function) _
                    .Select(Function(url) {url.U, url.V}) _
                    .IteratesALL _
                    .GroupBy(Function(v) v.label) _
                    .Select(Function(v) v.First) _
                    .GroupBy(Function(v)
                                 Return v.data("knowledge_type")
                             End Function) _
                    .ToArray
                Dim props As New Dictionary(Of String, String)

                For Each p In metadata
                    Call props.Add(p.Key, p.Select(Function(v) v.label).JoinBy("; "))
                Next

                Yield New Knowledge With {
                    .Key = term.Key,
                    .Properties = props
                }
            Next
        Next
    End Function

    <Extension>
    Public Function ComputeKnowlegdes(graph As NetworkGraph, eps As Double) As NetworkGraph
        Call Communities.Analysis(graph, eps:=eps)

        Return graph
    End Function
End Module
