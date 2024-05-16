﻿#Region "Microsoft.VisualBasic::66b806c5f5c5879e969dc5d7c3785cd3, src\graphQL\KnowledgeBuilder\HubAlignment.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.



    ' /********************************************************************************/

    ' Summaries:


    ' Code Statistics:

    '   Total Lines: 20
    '    Code Lines: 14
    ' Comment Lines: 0
    '   Blank Lines: 6
    '     File Size: 635 B


    ' Class HubAlignment
    ' 
    '     Constructor: (+1 Overloads) Sub New
    '     Function: GetObject, GetSimilarity
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.DataMining.BinaryTree

Public Class HubAlignment : Inherits ComparisonProvider

    ReadOnly matrix As Dictionary(Of String, Dictionary(Of String, Double))

    Public Sub New(matrix As Dictionary(Of String, Dictionary(Of String, Double)), equals As Double, gt As Double)
        MyBase.New(equals, gt)

        Me.matrix = matrix
    End Sub

    Public Overrides Function GetSimilarity(x As String, y As String) As Double
        Return matrix(x)(y)
    End Function

    Public Overrides Function GetObject(id As String) As Object
        Return matrix(id)
    End Function
End Class
