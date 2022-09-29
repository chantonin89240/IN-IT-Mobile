
using System.Text.Json.Serialization;
using InitManage.Models.Interfaces;

namespace InitManage.Models.DTOs;

public class TypeDTO : ITypeEntity
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }
}
