using System;
namespace InitManage.Models.Interfaces;

public interface IOptionEntity
{
    long Id { get; set; }
    string Name { get; set; }
    long TypeId { get; set; }
}

