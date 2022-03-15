﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.Data.visualize.Network.Graph
Imports Microsoft.VisualBasic.DataMining.UMAP

Module umapKnowledge

    <Extension>
    Private Function toFullMatrix(g As NetworkGraph, ByRef labels As String()) As Double()()
        Dim nodes As Index(Of String) = g.vertex.Select(Function(v) v.label).Indexing
        Dim mat As Double()() = New Double(nodes.Count - 1)() {}

        For i As Integer = 0 To mat.Length - 1
            mat(i) = New Double(mat.Length - 1) {}
        Next

        For Each edge As Edge In g.graphEdges
            Dim i As Integer = nodes.IndexOf(edge.U.label)
            Dim j As Integer = nodes.IndexOf(edge.V.label)

            mat(i)(j) += edge.weight
            mat(j)(i) += edge.weight
        Next

        labels = nodes.Objects

        Return mat
    End Function

    <Extension>
    Public Function RunUMAP(g As NetworkGraph, ByRef labels As String()) As Umap
        Dim umap As New Umap(dimensions:=3)
        Dim nEpochs As Integer
        Dim matrix As Double()() = g.toFullMatrix(labels)

        Call Console.WriteLine("Initialize fit..")

        nEpochs = umap.InitializeFit(matrix)

        Console.WriteLine("- Done")
        Console.WriteLine()
        Console.WriteLine("Calculating..")

        For i As Integer = 0 To nEpochs - 1
            Call umap.Step()

            If (100 * i / nEpochs) Mod 5 = 0 Then
                Console.WriteLine($"- Completed {i + 1} of {nEpochs} [{CInt(100 * i / nEpochs)}%]")
            End If
        Next

        Return umap
    End Function
End Module
