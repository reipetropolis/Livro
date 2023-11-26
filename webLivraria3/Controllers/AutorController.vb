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
    Public Class AutorController
        Inherits System.Web.Mvc.Controller

        Private db As New DBContext

        ' GET: Autor
        Function Index() As ActionResult
            Return View(db.Autor.ToList())
        End Function

        ' GET: Autor/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim autor As Autor = db.Autor.Find(id)
            If IsNothing(autor) Then
                Return HttpNotFound()
            End If
            Return View(autor)
        End Function

        ' GET: Autor/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Autor/Create
        'Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        'obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="CodAu,Nome")> ByVal autor As Autor) As ActionResult
            If ModelState.IsValid Then
                db.Autor.Add(autor)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(autor)
        End Function

        ' GET: Autor/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim autor As Autor = db.Autor.Find(id)
            If IsNothing(autor) Then
                Return HttpNotFound()
            End If
            Return View(autor)
        End Function

        ' POST: Autor/Edit/5
        'Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        'obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="CodAu,Nome")> ByVal autor As Autor) As ActionResult
            If ModelState.IsValid Then
                db.Entry(autor).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(autor)
        End Function

        ' GET: Autor/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim autor As Autor = db.Autor.Find(id)
            If IsNothing(autor) Then
                Return HttpNotFound()
            End If
            Return View(autor)
        End Function

        ' POST: Autor/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim autor As Autor = db.Autor.Find(id)
            db.Autor.Remove(autor)
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
