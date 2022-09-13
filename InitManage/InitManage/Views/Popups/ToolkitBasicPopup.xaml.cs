using CommunityToolkit.Maui.Views;

namespace InitManage.Views.Popups;

public partial class ToolkitBasicPopup : Popup
{
    public bool IsAccepted { get; private set; }

    public ToolkitBasicPopup(string title, string message, string acceptButtonMessage = "Ok", string cancelButtonMessage = null)
    {
        InitializeComponent();

        TitleLabel.Text = title;
        MessageLabel.Text = message;
        AcceptButton.Text = acceptButtonMessage;
        CancelButton.Text = cancelButtonMessage;
    }

    public async Task ShowPopupAsync() => await Application.Current.MainPage.ShowPopupAsync(this);

    private void AcceptButtonClicked(object sender, EventArgs e)
    {
        IsAccepted = true;
        Close();
    }

    private void CancelButtonClicked(object sender, EventArgs e)
    {
        IsAccepted = false;
        Close();
    }
}
