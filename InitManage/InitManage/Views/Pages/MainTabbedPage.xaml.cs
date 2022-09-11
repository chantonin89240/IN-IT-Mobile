namespace InitManage.Views.Pages;

public partial class MainTabbedPage : TabbedPage
{
	public MainTabbedPage()
	{
		InitializeComponent();

		#if IOS
		this.SelectedTabColor = (Color)Application.Current.Resources.MergedDictionaries.FirstOrDefault()["Primary"];
		#endif
    }
}
