using InitManage.Commons.Enums;
using InitManage.Models.Interfaces;
using Newtonsoft.Json;

namespace InitManage.Models.DTOs;

public class ResourceDTOCreate : IResourceCreate
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("picture")]
    public string Picture { get; set; }

    [JsonProperty("type")]
    public ResourceType Type { get; set; }

    public int Capacity { get; set; }
}