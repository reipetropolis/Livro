@ModelType webLivraria3.Assunto
@Code
    ViewData("Title") = "Detalhes Assunto"
End Code

<h2>Detalhes do Assunto</h2>

<div>
    <h4>Assunto</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Descricao)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Descricao)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Alterar", "Edit", New With {.id = Model.codAs}) |
    @Html.ActionLink("Volta a lista", "Index")
</p>
