using System;
namespace InitManage.Models.Interfaces;

public interface IUser
{
    long Id { get; set; }
    string Firstname { get; set; }
    string Lastname { get; set; }
}

