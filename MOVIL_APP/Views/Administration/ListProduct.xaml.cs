using DATOS.Models.Database;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using MOVIL_APP.Libs;

namespace MOVIL_APP.Views.Administration;

public partial class ListProduct : ContentPage
{
    string ipServer = Conn.GetProductSearchUrl();
    HttpClient cliente = new HttpClient();
    ObservableCollection<Product> product;
    public ListProduct()
	{
		InitializeComponent();

        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };

        cliente = new HttpClient(handler);

        Obtener();
    }


    public async void Obtener()
    {
        try
        {
            string FullUrl = $"{ipServer}/api/Product";
            var content = await cliente.GetStringAsync(FullUrl);
            List<Product> mostrarProduct = JsonConvert.DeserializeObject<List<Product>>(content);
            product = new ObservableCollection<Product>(mostrarProduct);
            collectionCatalog.ItemsSource = product;
        }
        catch (Exception ex)
        {

            await DisplayAlert("ERROR", $"Error al conectarse: {ex.Message}", "CERRAR");
        }



    }

    private void btnOrder_Clicked(object sender, EventArgs e)
    {

    }

    private void collectionProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void collectionCatalog_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}