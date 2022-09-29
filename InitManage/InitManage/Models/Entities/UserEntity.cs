using System;
using InitManage.Models.Interfaces;

namespace InitManage.Models.Entities;

public class UserEntity : IUserEntity
{
    public UserEntity()
    {
    }

    public long Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
}
