using System.Text.Json.Serialization;

namespace CleanArch.Domain.Dtos;
public sealed class GetAccessTokenResponseDto
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = default!;
}
