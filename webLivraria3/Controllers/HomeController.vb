Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private db As New DBContext

    Function Index() As ActionResult
        Return View(db.Livroes.ToList().Take(10).OrderBy(Function(p) p.Titulo))
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
