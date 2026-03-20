using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class RelatorioPage : ContentPage
{
    public RelatorioPage()
    {
        InitializeComponent();
        CarregarRelatorio();
    }

    private async void CarregarRelatorio()
    {
        var listaProdutos = await App.Db.GetAll();

        var relatorio = listaProdutos
            .GroupBy(p => p.Categoria)
            .Select(g => new
            {
                Categoria = g.Key,
                TotalGasto = g.Sum(p => p.Total)
            })
            .ToList();

        relatorioView.ItemsSource = relatorio;
    }
}