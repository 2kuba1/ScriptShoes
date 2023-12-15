using System.Net;
using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain.Exceptions;

public class InvalidLastNameException : BaseException
{
    public InvalidLastNameException(string lastName) : base($"Invalid lastName ${lastName}")
    {
    }
    
    public InvalidLastNameException() : base($"LastName can't be null")
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}