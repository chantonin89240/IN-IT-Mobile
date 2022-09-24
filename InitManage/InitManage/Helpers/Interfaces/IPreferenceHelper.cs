﻿using System;
namespace InitManage.Helpers.Interfaces;

public interface IPreferenceHelper
{
    bool IsAdmin { get; set; }
    string Username { get; set; }
    TimeSpan TimeBeforeReceiveNotification { get; set; }
    bool IsNotificationEnabled { get; set; }
}

