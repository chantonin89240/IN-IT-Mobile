using System;
using InitManage.Services.Interfaces;
using InitManage.Views.Popups;

namespace InitManage.Services;

public class CommunityToolKitAlertDialogService : IAlertDialogService
{
    private ToolKitIsBusyPopup _toolKitIsBusyPopup;
    private bool _isBusyPopupDisplay;

    public CommunityToolKitAlertDialogService()
    {
    }

    public async Task<bool> AlertAsync(string title, string message, string acceptButtonMessage = "Ok", string cancelButtonMessage = null)
    {
        var popup = new ToolkitBasicPopup(title, message, acceptButtonMessage, cancelButtonMessage);
        await popup.ShowPopupAsync();

        return popup.IsAccepted;
    }

    public void SetIsBusy(bool isBusy, string message = null)
    {
        if (_isBusyPopupDisplay == isBusy)
            return;

        if (isBusy)
            _toolKitIsBusyPopup = new ToolKitIsBusyPopup();

        _isBusyPopupDisplay = isBusy;
        _toolKitIsBusyPopup.SetIsBusy(isBusy, message);
    }
}

