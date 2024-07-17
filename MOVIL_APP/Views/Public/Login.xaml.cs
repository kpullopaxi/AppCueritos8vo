using DATOS.Models.Database;
using Newtonsoft.Json;
using MOVIL_APP.Libs;

namespace MOVIL_APP.Views.Public;

public partial class Login : ContentPage
{
    string ipServer = Conn.GetProductSearchUrl();
    public Login()
	{
		InitializeComponent();

       
    }
    private List<User> userData = new List<User>();
    public async Task Validacion(string userName, string password)
    {
        try
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            string url = $"{ipServer}/api/Auth/Login";
            HttpClient cliente = new HttpClient(handler);
            var data = new Dictionary<string, string>
        {
            { "userName", userName },
            { "password", password }
        };

            var content = new FormUrlEncodedContent(data);
            var respuesta = await cliente.PostAsync(url, content);
            

            if (respuesta.IsSuccessStatusCode)
            {

                var jsonResponse = await respuesta.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(jsonResponse);

                if (user != null)
                {
                    clearTXT();
                    if (user.idRole== "5C6B9DD4-4429-449F-9807-3324C4A6014D") {
                        userData.Add(user);
                        await Navigation.PushAsync(new Administration.Home());
                       
                    }
                    else
                    {
                        userData.Add(user);
                    
                        await Navigation.PushAsync(new Public.Home(userData));
                    }
                  
                }
                else
                {
                    // Credenciales incorrectas
                    await DisplayAlert("ERROR", "Credenciales incorrectas", "CERRAR");
                }
            }
            else
            {
             
                await DisplayAlert("ERROR", "Error al realizar la solicitud", "CERRAR");
            }
        }
        catch (Exception ex)
        {
         
            await DisplayAlert("ERROR", $"Error inesperado: {ex.Message}", "CERRAR");
        }
    }


    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        _ = Validacion(txtUsername.Text, txtPassword.Text);
  
    }

    public void clearTXT() {
        txtUsername.Text = "";
        txtPassword.Text = "";
    
    }

    protected override bool OnBackButtonPressed()
    {
        return true; //evita regresar
    }
}