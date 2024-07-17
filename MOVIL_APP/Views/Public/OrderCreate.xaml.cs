using DATOS.Models.Database;
using MOVIL_APP.Libs;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MOVIL_APP.Views.Public;

public partial class OrderCreate : ContentPage
{
    private List<User> GetUsers;
    private List<Order> orderData = new List<Order>();
    
    string ipServer = Conn.GetProductSearchUrl();
    public OrderCreate(List<User> userData)
    {

        InitializeComponent();
        GetUsers = userData;


    }

    private void generateOrden_Clicked(object sender, EventArgs e)
    {
        _ = generateOrder();
    }

    private void btnUser_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Public.AccountSettings(GetUsers));
    }

    public async Task generateOrder() {
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

                var parametros = new Dictionary<string, string>
        {
            { "idUser", GetUsers[0].id },
            { "createdAt", fechaFormateada },
            { "address", txtAddress.Text },
            { "coordinates", "{}" },
            { "total", "0" },
            { "state", "1" }
        };

                var contenido = new FormUrlEncodedContent(parametros);

                var respuesta = await cliente.PostAsync("/api/Order", contenido);
                var jsonResponse = await respuesta.Content.ReadAsStringAsync();
                //transforma la respuesta y lo combierte a una clase con sus atributos
                var data = JsonConvert.DeserializeObject<Order>(jsonResponse);

                if (respuesta.IsSuccessStatusCode)
                {
                    orderData.Add(data);
                    _=Navigation.PushAsync(new Views.Public.SelectProduct(orderData));
                }
                else
                {
                 
                    var mensajeError = await respuesta.Content.ReadAsStringAsync();
                   _= DisplayAlert("Alerta", $"Error en la solicitud: {mensajeError}", "Cerrar");
                }
            }
        }
        catch (HttpRequestException ex)
        {
            
           _= DisplayAlert("Alerta", $"Error en la solicitud HTTP: {ex.Message}", "Cerrar");
        }
        catch (Exception ex)
        {
           
           _= DisplayAlert("Alerta", $"Error inesperado: {ex.Message}", "Cerrar");
        }


    }

}