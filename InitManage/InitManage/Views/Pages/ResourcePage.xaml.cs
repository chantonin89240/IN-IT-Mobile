namespace InitManage.Views.Pages;

public partial class ResourcePage : ContentPage
{
	public ResourcePage()
	{
		InitializeComponent();
		BookingsCollectionView.ItemsSource = new List<string>() { "", "", "", "", "", "", "" };

    }
}
