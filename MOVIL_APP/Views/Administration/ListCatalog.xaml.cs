using DATOS.Models.Database;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using MOVIL_APP.Libs;

namespace MOVIL_APP.Views.Administration;

public partial class ListCatalog : ContentPage
{
    string ipServer = Conn.GetProductSearchUrl();

    HttpClient cliente = new HttpClient();
    ObservableCollection<Catalog> catalog;
    public ListCatalog()
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
            string FullUrl = $"{ipServer}/api/Catalog";
            var content = await cliente.GetStringAsync(FullUrl);
            List<Catalog> mostrarCatalog = JsonConvert.DeserializeObject<List<Catalog>>(content);
            catalog = new ObservableCollection<Catalog>(mostrarCatalog);
            collectionCatalog.ItemsSource = catalog;
        }
        catch (Exception ex)
        {

            await DisplayAlert("ERROR", $"Error al conectarse: {ex.Message}", "CERRAR");
        }



    }
    private void btnOrder_Clicked(object sender, EventArgs e)
    {

    }

    private void btnUser_Clicked(object sender, EventArgs e)
    {

    }

    private void collectionCatalog_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}