using System;
namespace InitManage.Services.Interfaces;

public interface IAlertDialogService
{
    Task<bool> AlertAsync(string title, string message, string acceptButtonMessage = "Ok", string cancelButtonMessage = null);

    void SetIsBusy(bool isBusy, string message = null);
}

