@ModelType IEnumerable(Of webLivraria3.Livro)
@Code
    ViewData("Title") = "Página Inicial"
End Code


<div class="jumbotron">
    <h1>LIVRARIA</h1>

    <table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Titulo)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Editora)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Assunto)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Autor)
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
                    @Html.DisplayFor(Function(modelItem) item.Assunto.First().Descricao)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Autor.First().Nome)
                </td>
            </tr>
        Next

    </table>
</div>

