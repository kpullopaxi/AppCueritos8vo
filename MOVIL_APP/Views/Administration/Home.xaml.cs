namespace MOVIL_APP.Views.Administration;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
	}

    private void btnOrder_Clicked(object sender, EventArgs e)
    {

    }

    private void btnProductOrder_Clicked(object sender, EventArgs e)
    {

    }

    private void btnProduct_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Administration.ListProduct());

    }

  
    private void btnCatalog_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Administration.ListCatalog());

    }

    protected override bool OnBackButtonPressed()
    {
        return true; //evita regresar
    }
}