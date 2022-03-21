﻿Imports Microsoft.VisualBasic.Data.GraphTheory

''' <summary>
''' A knowledge node in this graph database
''' </summary>
Public Class Knowledge : Inherits Vertex

    ''' <summary>
    ''' the count of the current knowledge term 
    ''' has been mentioned in the knowledge 
    ''' network.
    ''' </summary>
    ''' <returns></returns>
    Public Property mentions As Integer

    ''' <summary>
    ''' the data type of the current term data.
    ''' </summary>
    ''' <returns></returns>
    Public Property type As String

    ''' <summary>
    ''' current knowledge term is a master source term?
    ''' </summary>
    ''' <returns>
    ''' true - is a master source term, 
    ''' false - is a meta data term
    ''' </returns>
    Public Property isMaster As Boolean

End Class


