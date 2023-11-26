@ModelType IEnumerable(Of webLivraria3.Autor)
@Code
    ViewData("Title") = "Autor"
End Code

<h2>Autor</h2>

<p>
    @Html.ActionLink("Novo", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nome)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Nome)
        </td>
        <td>
            @Html.ActionLink("Alterar", "Edit", New With {.id = item.CodAu}) |
            @Html.ActionLink("Detalhes", "Details", New With {.id = item.CodAu}) |
            @Html.ActionLink("Apagar", "Delete", New With {.id = item.CodAu})
        </td>
    </tr>
Next

</table>
