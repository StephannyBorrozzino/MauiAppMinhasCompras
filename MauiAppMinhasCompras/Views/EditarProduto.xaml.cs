using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
    public EditarProduto()
    {
        InitializeComponent();
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        if (BindingContext is Produto produto)
        {
            pickerCategoria.SelectedItem = produto.Categoria;
        }
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto produto = BindingContext as Produto;

            produto.Descricao = txt_descricao.Text;
            produto.Quantidade = Convert.ToDouble(txt_quantidade.Text);
            produto.Preco = Convert.ToDouble(txt_preco.Text);
            produto.Categoria = pickerCategoria.SelectedItem?.ToString();

            await App.Db.Update(produto);

            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}