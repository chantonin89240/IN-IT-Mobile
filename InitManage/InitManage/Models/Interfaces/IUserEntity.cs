using System;
namespace InitManage.Models.Interfaces;

public interface IUserEntity
{
    long Id { get; set; }
    string Firstname { get; set; }
    string Lastname { get; set; }
}

