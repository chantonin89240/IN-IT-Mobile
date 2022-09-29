using System;
using Newtonsoft.Json;

namespace InitManage.Models.Interfaces;

public interface IResourceCreate
{
    string Name { get; set; }

    string Description { get; set; }

    string Picture { get; set; }

    string Type { get; set; }

    int Capacity { get; set; }

    //ajouter une liste des options
}

