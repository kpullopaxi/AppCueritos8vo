using DATOS.Models.Database;

namespace MOVIL_APP.Views.Public;
using MOVIL_APP.Libs;
using Newtonsoft.Json;
using System.Collections.ObjectModel;


public partial class SelectProduct : ContentPage
{
 
    string ipServer = Conn.GetProductSearchUrl();

    HttpClient cliente = new HttpClient();
    ObservableCollection<Catalog> catalog;
    
    private List<Order> ordera;
    public SelectProduct(List<Order> orderData)
	{
		InitializeComponent();
        ordera = orderData;
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };

        cliente = new HttpClient(handler);
        
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

    private List<Product> shoppingCart = new List<Product>();
    private List<OrderDetail> order = new List<OrderDetail>();


    private void x(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var selectedProduct = (Product)e.CurrentSelection[0];

            // Agrega el producto al carrito de compras
            shoppingCart.Add(selectedProduct);

            // Limpia la selección actual en la colección
            collectionCatalog.SelectedItem = null;

            // Navega a la página de carrito de compras y pasa la lista de productos seleccionados
            //Navigation.PushAsync(new ShoppingCar(shoppingCart));
        }
    }

    private void btnUser_Clicked(object sender, EventArgs e)
    {

    }


    private void btnOrder_Clicked(object sender, EventArgs e)
    {

    }

    private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        buscarProduct(txtSearch.Text);
       
    }

    private void collectionCatalog_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var selectedProduct = (Product)e.CurrentSelection[0];

            // Agrega el producto al carrito de compras
            shoppingCart.Add(selectedProduct);

            // Limpia la selección actual en la colección
            collectionCatalog.SelectedItem = null;
            btnCheckOut.Text = "Checkout ("+shoppingCart.Count+")";
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        // Navega a la página de carrito de compras y pasa la lista de productos seleccionados
        OrderDTO dto = new OrderDTO();
        dto.selectedProducts = shoppingCart;
        dto.orders = this.ordera;
        Navigation.PushAsync(new ShoppingCar(dto));
    }
}