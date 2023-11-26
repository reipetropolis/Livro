Imports System.ComponentModel.DataAnnotations

Public Class Livro
    Public Sub New()
        Assunto = New HashSet(Of Assunto)()
        Autor = New HashSet(Of Autor)()
    End Sub

    <Key>
    Public Property Codl As Integer

    <Required>
    <StringLength(40)>
    Public Property Titulo As String

    <Required>
    <StringLength(40)>
    Public Property Editora As String

    Public Property Edicao As Integer?

    <StringLength(4)>
    Public Property AnoPublicacao As String

    Public Property Valor As Decimal

    Public Property Assunto_CodAs As Integer

    Public Property Autor_CodAu As Integer
    Public Overridable Property Assunto As ICollection(Of Assunto)

    Public Overridable Property Autor As ICollection(Of Autor)

End Class
