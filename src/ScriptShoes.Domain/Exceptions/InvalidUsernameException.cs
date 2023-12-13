using System.Net;
using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain.Exceptions;

public class InvalidUsernameException : BaseException
{
    public string Username { get; }

    public InvalidUsernameException(string username) : base($"Invalid username: {username}")
        => Username = username;

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}