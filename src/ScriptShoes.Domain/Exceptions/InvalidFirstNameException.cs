using System.Net;
using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain.Exceptions;

public class InvalidFirstNameException : BaseException
{
    public InvalidFirstNameException(string firstName) : base($"Invalid firstName ${firstName}")
    {
    }

    public InvalidFirstNameException() : base($"FirstName can't be null")
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}