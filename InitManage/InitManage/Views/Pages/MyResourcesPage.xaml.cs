namespace InitManage.Views.Pages;

public partial class MyResourcesPage : ContentPage
{
	public MyResourcesPage()
	{
		InitializeComponent();
		MyReservationsCollectionView.ItemsSource = new List<string>() {"", "", "", "","","","" };
    }
}
