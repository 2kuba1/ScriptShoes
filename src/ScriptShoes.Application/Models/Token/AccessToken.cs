namespace ScriptShoes.Application.Models.Token;

public class AccessToken
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expires { get; set; }
}