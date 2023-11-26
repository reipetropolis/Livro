
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions

Public Class DBContext
    Inherits System.Data.Entity.DbContext


    Private _Autor As DbSet(Of Autor)
    Public Property Autor() As DbSet(Of Autor)
        Get
            Return _Autor
        End Get
        Set(ByVal value As DbSet(Of Autor))
            _Autor = value
        End Set
    End Property


    Private _Assunto As DbSet(Of Assunto)
    Public Property Assunto() As DbSet(Of Assunto)
        Get
            Return _Assunto
        End Get
        Set(ByVal value As DbSet(Of Assunto))
            _Assunto = value
        End Set
    End Property

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
    End Sub

    Public Property Livroes As System.Data.Entity.DbSet(Of Livro)

End Class
