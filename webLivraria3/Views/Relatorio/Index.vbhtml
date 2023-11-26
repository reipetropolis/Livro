@ModelType IEnumerable(Of webLivraria3.Livro)
@Code
    ViewData("Title") = "Relatório"
End Code

<div class="jumbotron">
    <h1> Relatório</h1>

    <table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Titulo)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Editora)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Edicao)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.AnoPublicacao)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Valor)
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Titulo)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Editora)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Edicao)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.AnoPublicacao)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Valor)
                </td>
            </tr>
        Next

    </table>

    @Using (Html.BeginForm("Pdf", "Relatorio"))
        @Html.AntiForgeryToken()

        @<div class="form-horizontal">
            <hr />
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Gerar Pdf" class="btn btn-default" />
                </div>
            </div>
        </div>
    End Using
</div>


