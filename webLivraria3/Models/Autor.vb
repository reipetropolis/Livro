Imports System.ComponentModel.DataAnnotations

Public Class Autor
    Public Sub New()
        Livro = New HashSet(Of Livro)()
    End Sub

    <Key>
    Public Property CodAu As Integer

    <Required>
    <StringLength(40)>
    Public Property Nome As String

    Public Overridable Property Livro As ICollection(Of Livro)

End Class
