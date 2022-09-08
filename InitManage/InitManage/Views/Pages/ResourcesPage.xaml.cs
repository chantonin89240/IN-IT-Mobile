namespace InitManage.Views.Pages;

public partial class ResourcesPage : ContentPage
{
	public ResourcesPage()
	{
		InitializeComponent();
		MaCollection.ItemsSource = new List<string>() { "é", "ezfez", "ezon", "", "", "", "", ""};

    }
}
