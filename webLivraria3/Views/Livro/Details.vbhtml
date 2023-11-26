@ModelType webLivraria3.Livro
@Code
    ViewData("Title") = "Detalhes do livro"
End Code

<h2>Detalhes do livro</h2>

<div>
    <h4>Livro</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Titulo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Titulo)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Editora)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Editora)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Edicao)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Edicao)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.AnoPublicacao)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AnoPublicacao)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Valor)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Valor)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Alterar", "Edit", New With {.id = Model.Codl}) |
    @Html.ActionLink("Volta a lista", "Index")
</p>
