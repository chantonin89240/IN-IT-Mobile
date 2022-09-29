using InitManage.Models.Interfaces;
using Newtonsoft.Json;

namespace InitManage.Models.DTOs;

public class ResourceDTOUp : IResourceEntity
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("picture")]
    public string Picture { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("capacity")]
    public int Capacity { get; set; }
    public long Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Image { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}