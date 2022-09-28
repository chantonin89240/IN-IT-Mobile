
namespace InitManage.Views.Controls;

public partial class Loader : ContentView
{
	public Loader()
	{
		InitializeComponent();
	}

	#region [Bindable Property => LoadingMessage]
	public static BindableProperty LoadingMessageProperty = BindableProperty.Create(nameof(LoadingMessage), typeof(string), typeof(Loader), default(string), BindingMode.TwoWay, propertyChanged: OnLoadingMessagePropertyChanged);

	public string LoadingMessage
	{
		get => (string)GetValue(LoadingMessageProperty);
		set => SetValue(LoadingMessageProperty, value);
	}

	private static void OnLoadingMessagePropertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is Loader current && newValue is string loadingMessage)
			current.LoadingMessageLabel.Text = loadingMessage;
	}
	#endregion


	#region [Bindable Property => IsLoaderVisible]
	public static BindableProperty IsLoaderVisibleProperty = BindableProperty.Create(nameof(IsLoaderVisible), typeof(bool), typeof(Loader), default(bool), BindingMode.TwoWay, propertyChanged: OnIsLoaderVisiblePropertyChanged);

	public bool IsLoaderVisible
	{
		get => (bool)GetValue(LoadingMessageProperty);
		set => SetValue(LoadingMessageProperty, value);
	}

	private static void OnIsLoaderVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is Loader current && newValue is bool isVisible)
			current.ParentStackLayout.IsVisible = isVisible;
	}
	#endregion
}