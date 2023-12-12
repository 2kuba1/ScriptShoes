using System.Net;
using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain.Exceptions;

public class InvalidEmailException : BaseException
{
    public InvalidEmailException(string email) : base($"Invalid email {email}")
    {
    }

    public InvalidEmailException() : base($"Email can't be null")
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}