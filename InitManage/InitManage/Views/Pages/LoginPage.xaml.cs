namespace InitManage.Views.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		Application.Current.MainPage = new ResourcesPage();
    }
}
