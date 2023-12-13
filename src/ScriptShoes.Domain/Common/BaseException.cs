using System.Net;

namespace ScriptShoes.Domain.Common;

public abstract class BaseException : Exception
{
    public abstract HttpStatusCode StatusCode { get; }

    protected BaseException(string message) : base(message)
    {
    }
}