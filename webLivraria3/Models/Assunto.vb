Imports System.ComponentModel.DataAnnotations

Public Class Assunto
    Public Sub New()
        Livro = New HashSet(Of Livro)()
    End Sub

    <Key>
    Public Property codAs As Integer

    <Required>
    <StringLength(20)>
    Public Property Descricao As String

    Public Overridable Property Livro As ICollection(Of Livro)

End Class
