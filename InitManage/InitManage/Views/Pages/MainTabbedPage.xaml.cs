using InitManage.ViewModels.Resource;
using InitManage.ViewModels.Setting;

namespace InitManage.Views.Pages;

public partial class MainTabbedPage : TabbedPage
{
	public MainTabbedPage()
	{
		InitializeComponent();

        #if IOS
		this.SelectedTabColor = (Color)Application.Current.Resources.MergedDictionaries.FirstOrDefault()["Primary"];
        #endif

        var resourcesPage = ContainerLocator.Container.Resolve<ResourcesPage>();
        resourcesPage.BindingContext = ContainerLocator.Container.Resolve<ResourcesViewModel>();
        this.Children.Add(resourcesPage);

        var myResourcesPage = ContainerLocator.Container.Resolve<MyResourcesPage>();
        myResourcesPage.BindingContext = ContainerLocator.Container.Resolve<MyResourcesViewModel>();
        this.Children.Add(myResourcesPage);

        var settingPage = ContainerLocator.Container.Resolve<SettingsPage>();
		settingPage.BindingContext = ContainerLocator.Container.Resolve<SettingsViewModel>();
		this.Children.Add(settingPage);
    }
}
