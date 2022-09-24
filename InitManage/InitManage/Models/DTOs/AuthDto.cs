using System;
using Newtonsoft.Json;

namespace InitManage.Models.DTOs;

public class AuthDtoDown
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("mail")]
    public string Mail { get; set; }

    [JsonProperty("firstname")]
    public string Firstname { get; set; }

    [JsonProperty("lastname")]
    public string Lastname { get; set; }

    [JsonProperty("isAdmin")]
    public bool IsAdmin { get; set; }
}

public class AuthDtoUp
{
    [JsonProperty("mail")]
    public string Mail { get; set; }

    [JsonProperty("firstname")]
    public string Password { get; set; }
}

