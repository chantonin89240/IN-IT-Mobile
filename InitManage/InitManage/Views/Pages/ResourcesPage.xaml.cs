using CsharpTools.Services;
using CsharpTools.Services.Interfaces;
using HttpService = CsharpTools.Services.HttpService;
using System.Linq;

namespace InitManage.Views.Pages;

public partial class ResourcesPage : ContentPage
{
    public IHttpService _httpService = new HttpService();

    public ResourcesPage()
	{

        InitializeComponent();
		MaCollection.ItemsSource = new List<string>() { "é", "ezfez", "ezon", "", "", "", "", ""};
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var x = await _httpService.SendHttpRequest<IEnumerable<ResourceDTODown>>("http://10.4.0.112:3000/api/pokemons", HttpMethod.Get);
        MaCollection.ItemsSource = x?.Content;
    }
}
