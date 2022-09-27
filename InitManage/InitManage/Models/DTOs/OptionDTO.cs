using System;
using InitManage.Models.Interfaces;
using Newtonsoft.Json;

namespace InitManage.Models.DTOs;

public class OptionDTO : IOptionEntity
{
    public OptionDTO()
    {
    }

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("type_id")]
    public long TypeId { get; set; }
}

