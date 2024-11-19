﻿using System.Text.Json.Serialization;

namespace RacetimeTrackerClient.Model;

public class User
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
}