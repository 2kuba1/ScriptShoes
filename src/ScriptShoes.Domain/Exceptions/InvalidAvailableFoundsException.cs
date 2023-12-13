using System.Net;
using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain.Exceptions;

public class InvalidAvailableFoundsException : BaseException
{
    public InvalidAvailableFoundsException(float availableFounds) : base($"Invalid available founds ${availableFounds}")
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}