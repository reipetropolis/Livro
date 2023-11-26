@ModelType IEnumerable(Of webLivraria3.Assunto)
@Code
    ViewData("Title") = "Assunto"
End Code

<h2>Assunto</h2>

<p>
    @Html.ActionLink("Novo", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Descricao)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Descricao)
        </td>
        <td>
            @Html.ActionLink("Alterar", "Edit", New With {.id = item.codAs}) |
            @Html.ActionLink("Detalhes", "Details", New With {.id = item.codAs}) |
            @Html.ActionLink("Apagar", "Delete", New With {.id = item.codAs})
        </td>
    </tr>
Next

</table>
