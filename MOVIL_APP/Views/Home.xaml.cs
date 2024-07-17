
using DATOS.Models.Database;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using MOVIL_APP.Libs;

namespace MOVIL_APP.Views;
public partial class Home : ContentPage
{

    string ipServer = Conn.GetProductSearchUrl();
    
    HttpClient cliente = new HttpClient();
    ObservableCollection<Catalog> catalog;

    public Home()
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
    private void listCatalog_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {


        buscarProduct(txtSearch.Text);
    }

    private async void buscarProduct(string search)
    {
        try
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            HttpClient cliente = new HttpClient(handler);
            var url = $"{ipServer}/api/Product/getByCriteria?criteria=" + search;
            var response = await cliente.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(jsonContent);
                collectionCatalog.ItemsSource = productList;
            }
            else
            {

            }
        }
        catch (Exception ex)
        {

        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
    private List<Product> shoppingCart = new List<Product>();
    private List<OrderDetail> order = new List<OrderDetail>();
    private void collectionCatalog_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var selectedProduct = (Product)e.CurrentSelection[0];

            // Agrega el producto al carrito de compras
            shoppingCart.Add(selectedProduct);

            // Limpia la selección actual en la colección
            collectionCatalog.SelectedItem = null;

            // Navega a la página de carrito de compras y pasa la lista de productos seleccionados
            Navigation.PushAsync(new ShoppingCar(new OrderDTO()));
        }
    }

    private void txtSearch_TextChanged_1(object sender, TextChangedEventArgs e)
    {

    }

    protected override bool OnBackButtonPressed()
    {
        return true; //evita regresar
    }
}