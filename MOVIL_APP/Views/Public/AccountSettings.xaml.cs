using DATOS.Models.Database;

namespace MOVIL_APP.Views.Public;

public partial class AccountSettings : ContentPage
{
    private List<User> GetUsers;
    public AccountSettings(List<User> userData)
	{
		InitializeComponent();

        GetUsers = userData;
        lblDocumentNumber.Text = GetUsers[0].documentNumber;
        lblFullName.Text = GetUsers[0].fullName;
        lblUserName.Text = GetUsers[0].userName;
        lblTitleName.Text= GetUsers[0].fullName;


    }

    private void btnCloseSession_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Public.Login());

    }
}