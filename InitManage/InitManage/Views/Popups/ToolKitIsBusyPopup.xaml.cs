using CommunityToolkit.Maui.Views;

namespace InitManage.Views.Popups;

public partial class ToolKitIsBusyPopup : Popup
{
	public ToolKitIsBusyPopup()
	{
		InitializeComponent();
	}

    public void SetIsBusy(bool isBusy, string message = null)
    {
        if (isBusy)
        {
            MessageLabel.Text = message;
            Application.Current.MainPage.ShowPopup(this);
        }
        else
        {
            Close();
        }
    }
}
