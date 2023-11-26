Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports webLivraria3

Namespace Controllers
    Public Class LivroController
        Inherits System.Web.Mvc.Controller

        Private db As New DBContext

        ' GET: Livro
        Function Index() As ActionResult
            Dim teste = db.Livroes.ToList()
            Return View(db.Livroes.ToList())
        End Function

        ' GET: Livro/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim livro As Livro = db.Livroes.Find(id)
            If IsNothing(livro) Then
                Return HttpNotFound()
            End If
            Return View(livro)
        End Function

        ' GET: Livro/Create
        Function Create() As ActionResult
            ViewBag.list = db.Assunto.ToList()
            ViewBag.listAutor = db.Autor.ToList()
            Return View()
        End Function

        ' POST: Livro/Create
        'Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        'obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Codl,Titulo,Editora,Edicao,AnoPublicacao,Valor,Assunto_CodAs,Autor_CodAu")> ByVal livro As Livro) As ActionResult
            If ModelState.IsValid Then
                Dim assunto As Assunto = db.Assunto.Find(livro.Assunto_CodAs)
                livro.Assunto.Add(assunto)
                Dim autor As Autor = db.Autor.Find(livro.Autor_CodAu)
                livro.Autor.Add(autor)
                db.Livroes.Add(livro)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(livro)
        End Function

        ' GET: Livro/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim livro As Livro = db.Livroes.Find(id)
            ViewBag.list = db.Assunto.ToList()
            ViewBag.listAutor = db.Autor.ToList()
            If IsNothing(livro) Then
                Return HttpNotFound()
            End If
            Return View(livro)
        End Function

        ' POST: Livro/Edit/5
        'Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        'obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Codl,Titulo,Editora,Edicao,AnoPublicacao,Valor,Assunto_CodAs,Autor_CodAu,Assunto,Autor")> ByVal livro As Livro) As ActionResult
            If ModelState.IsValid Then
                db.Entry(livro).State = EntityState.Modified
                Dim assunto As Assunto = db.Assunto.Find(livro.Assunto_CodAs)
                livro.Assunto.Add(assunto)
                Dim autor As Autor = db.Autor.Find(livro.Autor_CodAu)
                livro.Autor.Add(autor)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(livro)
        End Function

        ' GET: Livro/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim livro As Livro = db.Livroes.Find(id)
            If IsNothing(livro) Then
                Return HttpNotFound()
            End If
            Return View(livro)
        End Function

        ' POST: Livro/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim livro As Livro = db.Livroes.Find(id)
            db.Livroes.Remove(livro)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
