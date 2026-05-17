using System.Net;

namespace PayBridge.Shared;

public class AppException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public AppException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) 
        : base(message)
    {
        StatusCode = statusCode;
    }
}

public class NotFoundException : AppException
{
    public NotFoundException(string message) : base(message, HttpStatusCode.NotFound) { }
}

public class ValidationException : AppException
{
    public ValidationException(string message) : base(message, HttpStatusCode.BadRequest) { }
}

public class UnauthorizedException : AppException
{
    public UnauthorizedException(string message) : base(message, HttpStatusCode.Unauthorized) { }
}

public class ConflictException : AppException
{
    public ConflictException(string message) : base(message, HttpStatusCode.Conflict) { }
}
