using System;
using InitManage.Commons.Enums;
using Newtonsoft.Json;

namespace InitManage.Models.Interfaces;

public interface IResource
{
    long Id { get; set;}

    string Name { get; set; }

    string Description { get; set; }

    string Image { get; set; }

    ResourceType Type { get; set; }

    int Capacity { get; set; }
}

