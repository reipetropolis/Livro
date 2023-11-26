@ModelType webLivraria3.Livro
@Code
    ViewData("Title") = "Apagar Livro"
End Code

<h2>Apagar Livor</h2>

<h3>Tem certeza que deseja excluir este livro</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Apagar" class="btn btn-default" /> |
            @Html.ActionLink("Volta a lista", "Index")
        </div>
    End Using
</div>
