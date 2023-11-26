Imports System.IO
Imports System.Web.Mvc
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Namespace Controllers
    Public Class RelatorioController
        Inherits Controller

        Private db As New DBContext
        Private Shared Property doc As Document
        Private Shared Property sec As Section

        ' GET: Relatorio
        Function Index() As ActionResult
            Return View(db.Livroes.ToList().Take(10).OrderBy(Function(p) p.Titulo))
        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Pdf() As ActionResult
            Dim pdfArquivo = GeraPdf()
            'Return File(pdfArquivo, System.Net.Mime.MediaTypeNames.Application.Pdf)
            Return File(pdfArquivo, "application/pdf")
        End Function

        Public Function GeraPdf() As Byte()

            Dim relatorio = db.Livroes.ToList()

            Using result = New MemoryStream()
                Dim pdfRenderer = New PdfDocumentRenderer()
                pdfRenderer.Document = GeraDocument(relatorio)
                pdfRenderer.RenderDocument()
                pdfRenderer.PdfDocument.Save(result)
                Return result.ToArray()
            End Using
        End Function

        Private Shared Function GeraDocument(ByVal listaRelatorio As List(Of Livro)) As Document
            doc = New Document()
            sec = doc.AddSection()
            doc.Info.Title = "Relatório Livros"
            doc.Info.Subject = "Relatório Livros"
            doc.Info.Author = "Reinaldo"
            SetaStyle()
            Cabecalho()
            DadosPrincipal(listaRelatorio)
            Rodape()
            Return doc
        End Function

        Private Shared Sub SetaStyle()
            doc.DefaultPageSetup.TopMargin = "7mm"
            doc.DefaultPageSetup.BottomMargin = "10mm"
            doc.DefaultPageSetup.RightMargin = "0mm"
            doc.DefaultPageSetup.LeftMargin = "7mm"
            Dim style = doc.Styles("Normal")
            style.Font.Name = "Verdana"
            style.Font.Size = 6
            style = doc.AddStyle("caption", "Normal")
            style.Font.Size = 5
            style.Font.Bold = True
            style.ParagraphFormat.SpaceBefore = "0.3mm"
            style.ParagraphFormat.SpaceAfter = "0.3mm"
            style = doc.AddStyle("value", "Normal")
            style.Font.Size = 6
        End Sub

        Private Shared Sub Cabecalho()
            Dim table = CreateBloco()
            table.AddColumn("198mm")
            Dim row As Row = table.AddRow()
            row.Height = "2mm"
            Dim headerLivraria = row.Cells(0).AddParagraph($"Livraria")
            headerLivraria.Format.Font.Size = 7
            headerLivraria.Format.Alignment = ParagraphAlignment.Left
            headerLivraria.Format.SpaceAfter = "2mm"
            row.Cells(0).Format.Alignment = ParagraphAlignment.Center
            row.Cells(0).Shading.Color = Colors.LightGray
            Dim num = row.Cells(0).AddParagraph($"Relatório de livros")
            num.Format.Font.Bold = True
            num.Format.Font.Size = 15
            num.Format.Alignment = ParagraphAlignment.Center
            num.Format.SpaceBefore = "2mm"
            num.Format.SpaceAfter = "2mm"
            row.Height = "2mm"
        End Sub

        Private Shared Function CreateBloco(ByVal Optional titulo As String = Nothing) As Table
            If titulo IsNot Nothing Then
                Dim title = sec.AddParagraph()
                title.AddText(titulo)
                title.Format.Font.Size = 6
                title.Format.KeepWithNext = True
                title.Format.SpaceBefore = "0.6mm"
                title.Format.SpaceAfter = "0.3mm"
            End If

            Dim table = CreateTable(sec)
            Return table
        End Function

        Private Shared Function CreateTable(ByVal sec As Section) As Table
            Dim table = sec.AddTable()
            table.Borders.Color = Color.FromArgb(255, 0, 0, 0)
            Return table
        End Function

        Private Shared Function CreateBlocoSemBorda(ByVal Optional titulo As String = Nothing) As Table
            If titulo IsNot Nothing Then
                Dim title = sec.AddParagraph()
                title.AddText(titulo)
                title.Format.Font.Size = 6
                title.Format.KeepWithNext = True
                title.Format.SpaceBefore = "0.6mm"
                title.Format.SpaceAfter = "0.3mm"
            End If

            Dim table = CreateTableSemBorda(sec)
            Return table
        End Function

        Private Shared Function CreateTableSemBorda(ByVal sec As Section) As Table
            Dim table = sec.AddTable()
            table.Borders.Visible = False
            Return table
        End Function

        Private Shared Sub DadosPrincipal(ByVal listaRelatorio As List(Of Livro))
            Dim table = CreateBlocoSemBorda("")
            table.AddColumn("40mm")
            table.AddColumn("27mm")
            table.AddColumn("27mm")
            table.AddColumn("27mm")
            table.AddColumn("20mm")
            table.AddColumn("27mm")
            table.AddColumn("27mm")
            Dim rHeader = table.AddRow()
            rHeader.Format.Font.Size = 8
            rHeader.Height = "5mm"
            rHeader.Borders.Bottom.Color = Color.FromArgb(255, 0, 0, 0)
            rHeader.Format.Alignment = ParagraphAlignment.Left
            rHeader.Format.SpaceAfter = "3mm"
            rHeader.Cells(0).AddParagraph("Titulo")
            rHeader.Cells(1).AddParagraph("Valor")
            rHeader.Cells(1).Format.Alignment = ParagraphAlignment.Center
            rHeader.Cells(2).AddParagraph("Editora")
            rHeader.Cells(2).Format.Alignment = ParagraphAlignment.Center
            rHeader.Cells(3).AddParagraph("Ano Publicação")
            rHeader.Cells(3).Format.Alignment = ParagraphAlignment.Center
            rHeader.Cells(4).AddParagraph("Edição")
            rHeader.Cells(4).Format.Alignment = ParagraphAlignment.Center
            rHeader.Cells(5).AddParagraph("Assunto")
            rHeader.Cells(5).Format.Alignment = ParagraphAlignment.Center
            rHeader.Cells(6).AddParagraph("Autor")
            rHeader.Cells(6).Format.Alignment = ParagraphAlignment.Center


            For Each itemDados As Livro In listaRelatorio
                Dim row = table.AddRow()
                row.Height = "5mm"
                row.Format.Font.Size = 8
                row.Cells(0).Format.Alignment = ParagraphAlignment.Left
                row.Cells(0).Format.SpaceAfter = "3mm"
                row.Cells(0).Format.SpaceBefore = "2mm"
                row.Cells(0).AddParagraph(itemDados.Titulo)
                row.Cells(1).Format.Alignment = ParagraphAlignment.Right
                row.Cells(1).Format.SpaceAfter = "3mm"
                row.Cells(1).Format.SpaceBefore = "2mm"

                If itemDados.Valor = 0 Then
                    row.Cells(1).AddParagraph("0,00")
                Else
                    row.Cells(1).AddParagraph(String.Format("{0:#,0.00}", itemDados.Valor.ToString()))
                End If

                row.Cells(2).Format.Alignment = ParagraphAlignment.Right
                row.Cells(2).Format.SpaceAfter = "3mm"
                row.Cells(2).Format.SpaceBefore = "2mm"
                row.Cells(2).AddParagraph(itemDados.Editora)

                row.Cells(3).Format.Alignment = ParagraphAlignment.Right
                row.Cells(3).Format.SpaceAfter = "3mm"
                row.Cells(3).Format.SpaceBefore = "2mm"

                row.Cells(3).AddParagraph(itemDados.AnoPublicacao)

                row.Cells(4).Format.Alignment = ParagraphAlignment.Right
                row.Cells(4).Format.SpaceAfter = "3mm"
                row.Cells(4).Format.SpaceBefore = "2mm"

                row.Cells(4).AddParagraph(itemDados.Edicao)

                row.Cells(5).Format.Alignment = ParagraphAlignment.Right
                row.Cells(5).Format.SpaceAfter = "3mm"
                row.Cells(5).Format.SpaceBefore = "2mm"

                row.Cells(5).AddParagraph(itemDados.Assunto.First().Descricao)

                row.Cells(6).Format.Alignment = ParagraphAlignment.Right
                row.Cells(6).Format.SpaceAfter = "3mm"
                row.Cells(6).Format.SpaceBefore = "2mm"

                row.Cells(6).AddParagraph(itemDados.Autor.First().Nome)

            Next

        End Sub

        Private Shared Sub Rodape()
            Dim table = sec.Footers.Primary.AddTable()
            table.AddColumn("99mm")
            table.AddColumn("99mm")
            Dim row As Row = table.AddRow()
            row.Borders.Top.Color = Color.FromArgb(255, 0, 0, 0)
            Dim headerImpresso = row.Cells(0).AddParagraph($"Impresso em: " & DateTime.Now.ToString())
            headerImpresso.Format.Font.Size = 7
            headerImpresso.Format.Alignment = ParagraphAlignment.Left
            headerImpresso.Format.SpaceAfter = "5mm"
        End Sub
    End Class
End Namespace