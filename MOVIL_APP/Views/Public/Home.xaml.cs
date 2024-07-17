using DATOS.Models.Database;

namespace MOVIL_APP.Views.Public;

public partial class Home : ContentPage
{
    private List<User> GetUsers;
    public Home(List<User> userData)
    {
        InitializeComponent();
        GetUsers = userData;
        btnUser.Text = GetUsers[0].fullName;
            
    }

    private void btnUser_Clicked(object sender, EventArgs e)
    {
       
        Navigation.PushAsync(new Public.AccountSettings(GetUsers));
    }

    private void btnOrder_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Public.OrderCreate(GetUsers));
    }
    protected override bool OnBackButtonPressed()
    {
        return true; 
    }
}