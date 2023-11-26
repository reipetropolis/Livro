@ModelType webLivraria3.Assunto
@Code
    ViewData("Title") = "Apagar"
End Code

<h2>Apagar Assunto</h2>

<h3>Tem certeza que deseja apagar este assunto?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Apagar" class="btn btn-default" /> |
            @Html.ActionLink("Voltar a lista", "Index")
        </div>
    End Using
</div>
