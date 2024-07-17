using DATOS.Models.Database;

using DATOS.Repository;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using MOVIL_APP.Libs;

namespace MOVIL_APP.Views;

public partial class ShoppingCar : ContentPage
{
    private List<OrderDetail> orderData = new List<OrderDetail>();
    string ipServer = Conn.GetProductSearchUrl();
    private List<Product> shoppingCart;
    List<Order> orders = new List<Order>();

    public ShoppingCar(OrderDTO orderDTO)
	{
       
        InitializeComponent();
        this.orders = orderDTO.orders;
        shoppingCart = orderDTO.selectedProducts;

        // Establece el origen de datos del ListView
        CollectionShoppingCar.ItemsSource = shoppingCart;
        //calcular 
        decimal totalAmount = CalculateTotalAmount(shoppingCart);
        lblTotalAmount.Text = $"Total Amount: {totalAmount:C}";


    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //decimal totalAmount = CalculateTotalAmount(shoppingCart);
        //lblTotalAmount.Text = $"Total Amount: {totalAmount:C}";

        GenerateCompra();
    }

    private decimal CalculateTotalAmount(List<Product> products)
    {
        decimal totalAmount = 0;

        // Itera a través de la lista y suma los precios de cada producto
        foreach (var product in products)
        {
            totalAmount += product.price ;
        }

        return totalAmount;
    }

    public async Task GenerateCompra()
    {
        try
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            using (var cliente = new HttpClient(handler))
            {
                cliente.BaseAddress = new Uri(ipServer);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                DateTime fechaActual = DateTime.Now;
                string fechaFormateada = fechaActual.ToString("yyyy-MM-dd HH:mm:ss");
                var price = shoppingCart[0].price;

                foreach (var item in shoppingCart)
                {
                    var parametros = new Dictionary<string, string>

                        {
                            { "idOrder", this.orders[0].id },
                            { "idProduct", item.id },
                            { "amount", "1" },
                            { "price",item.price.ToString() },
                            { "details", "" },
                            { "state", "1" }
                        };

                    var contenido = new FormUrlEncodedContent(parametros);

                    var respuesta = await cliente.PostAsync("/api/OrderDetail", contenido);
                    var jsonResponse = await respuesta.Content.ReadAsStringAsync();
                    //transforma la respuesta y lo combierte a una clase con sus atributos
                    var data = JsonConvert.DeserializeObject<OrderDetail>(jsonResponse);
                    if (respuesta.IsSuccessStatusCode)
                    {
                        orderData.Add(data);
                    }
                    else
                    {

                        var mensajeError = await respuesta.Content.ReadAsStringAsync();
                    }
                }

                if (orderData.Count > 0)
                {
                    _ = DisplayAlert("Alerta", $"Se ha generado la compra:", "Cerrar");

                }
                else
                {

                    _ = DisplayAlert("Alerta", $"Error en la solicitud", "Cerrar");
                }


            }
        }
        catch (HttpRequestException ex)
        {

            _ = DisplayAlert("Alerta", $"Error en la solicitud HTTP: {ex.Message}", "Cerrar");
        }
        catch (Exception ex)
        {

            _ = DisplayAlert("Alerta", $"Error inesperado: {ex.Message}", "Cerrar");
        }


    }

}