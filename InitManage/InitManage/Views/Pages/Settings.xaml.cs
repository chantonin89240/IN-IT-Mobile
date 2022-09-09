namespace InitManage.Views.Pages;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent();
	}

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		Navigation.PushAsync(new ResourcePage());
    }
}
