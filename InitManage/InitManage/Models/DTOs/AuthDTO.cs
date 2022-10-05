using System;
using Newtonsoft.Json;

namespace InitManage.Models.DTOs;

public class AuthDTODown
{
    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("token")]
    public string Token { get; set; }
}

public class AuthDtoUp
{
    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }
}

