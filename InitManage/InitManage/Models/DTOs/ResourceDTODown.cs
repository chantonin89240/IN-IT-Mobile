using InitManage.Commons.Enums;
using InitManage.Models.Interfaces;
using Newtonsoft.Json;

namespace InitManage.Models.DTOs;

public class ResourceDTODown : IResource
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("image")]
    public string Image { get; set; }

    [JsonProperty("type")]
    public ResourceType Type { get; set; }

    public int Capacity { get; set; }
}