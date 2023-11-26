@ModelType IEnumerable(Of webLivraria3.Livro)
@Code
    ViewData("Title") = "Livro"
End Code

<h2>Livro</h2>

<p>
    @Html.ActionLink("Novo", "Create")
</p>
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
        @Html.DisplayFor(Function(modelItem) item.Edicao)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.AnoPublicacao)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Valor)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Assunto.First().Descricao)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Autor.First().Nome)
    </td>
    <td>
        @Html.ActionLink("Alterar", "Edit", New With {.id = item.Codl}) |
        @Html.ActionLink("Detalhes", "Details", New With {.id = item.Codl}) |
        @Html.ActionLink("Apagar", "Delete", New With {.id = item.Codl})
    </td>
</tr>
Next

</table>
