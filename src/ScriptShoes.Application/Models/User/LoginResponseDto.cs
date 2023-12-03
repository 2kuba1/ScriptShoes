namespace ScriptShoes.Application.Models.User;

public class LoginResponseDto
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime AccessTokenExpirationTime { get; set; }
    public DateTime RefreshTokenExpirationTime { get; set; }
}