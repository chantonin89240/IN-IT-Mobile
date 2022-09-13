using System;
namespace InitManage.Models.Interfaces;

public interface ISearchable
{
    bool IsCorrespondingToSearch(string searchedValue);
}

