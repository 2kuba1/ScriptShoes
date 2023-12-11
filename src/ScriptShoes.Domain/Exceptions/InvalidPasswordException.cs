using System.Net;
using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain.Exceptions;

public class InvalidPasswordException : BaseException
{
    public InvalidPasswordException() : base("Invalid password")
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}