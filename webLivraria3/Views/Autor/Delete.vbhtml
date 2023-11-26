@ModelType webLivraria3.Autor
@Code
    ViewData("Title") = "Apaga Autor"
End Code

<h2>Apaga Autor</h2>

<h3>Tem certeza que deseja apagar este Autor?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Apagar" class="btn btn-default" /> |
            @Html.ActionLink("Volta a lista", "Index")
        </div>
    End Using
</div>
