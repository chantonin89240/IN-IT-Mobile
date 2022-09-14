using System;
using InitManage.Commons.Enums;
using Newtonsoft.Json;

namespace InitManage.Models.Interfaces;

public interface IResourceCreate
{
    string Name { get; set; }

    string Description { get; set; }

    string Picture { get; set; }

    ResourceType Type { get; set; }

    int Capacity { get; set; }

    //ajouter une liste des options
}

