using System;
using InitManage.Helpers.Interfaces;

namespace InitManage.Helpers;

public class PreferenceHelper : IPreferenceHelper
{
    public bool IsAdmin
    {
        get => Preferences.Get(nameof(IsAdmin), false);
        set => Preferences.Set(nameof(IsAdmin), value);
    }

    public string Username
    {
        get => Preferences.Get(nameof(Username), string.Empty);
        set => Preferences.Set(nameof(Username), value);
    }
}

