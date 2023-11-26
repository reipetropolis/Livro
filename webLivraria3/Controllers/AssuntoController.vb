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
    Public Class AssuntoController
        Inherits System.Web.Mvc.Controller

        Private db As New DBContext

        ' GET: Assunto
        Function Index() As ActionResult
            Return View(db.Assunto.ToList())
        End Function

        ' GET: Assunto/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim assunto As Assunto = db.Assunto.Find(id)
            If IsNothing(assunto) Then
                Return HttpNotFound()
            End If
            Return View(assunto)
        End Function

        ' GET: Assunto/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Assunto/Create
        'Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        'obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="codAs,Descricao")> ByVal assunto As Assunto) As ActionResult
            If ModelState.IsValid Then
                db.Assunto.Add(assunto)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(assunto)
        End Function

        ' GET: Assunto/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim assunto As Assunto = db.Assunto.Find(id)
            If IsNothing(assunto) Then
                Return HttpNotFound()
            End If
            Return View(assunto)
        End Function

        ' POST: Assunto/Edit/5
        'Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        'obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="codAs,Descricao")> ByVal assunto As Assunto) As ActionResult
            If ModelState.IsValid Then
                db.Entry(assunto).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(assunto)
        End Function

        ' GET: Assunto/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim assunto As Assunto = db.Assunto.Find(id)
            If IsNothing(assunto) Then
                Return HttpNotFound()
            End If
            Return View(assunto)
        End Function

        ' POST: Assunto/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim assunto As Assunto = db.Assunto.Find(id)
            db.Assunto.Remove(assunto)
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
