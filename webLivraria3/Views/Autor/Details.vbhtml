@ModelType webLivraria3.Autor
@Code
    ViewData("Title") = "Detalhes Autor"
End Code

<h2>Detalhes do Autor</h2>

<div>
    <h4>Autor</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Nome)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nome)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Alterar", "Edit", New With {.id = Model.CodAu}) |
    @Html.ActionLink("Volta a lista", "Index")
</p>
