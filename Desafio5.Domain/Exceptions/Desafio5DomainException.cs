using Desafio5.Domain.Enum;
using System.Net;

namespace Desafio5.Domain.Exceptions;

public class Desafio5DomainException : Exception
{
    public ErrorCodeEnum ErrorCode { get; set; }
    public HttpStatusCode? StatusCode { get; set; }

    public Desafio5DomainException(string message, ErrorCodeEnum errorCode, HttpStatusCode? statusCode = null) : base(message)
    {
        this.ErrorCode = errorCode;
        this.StatusCode = statusCode;
    }

    public Desafio5DomainException(string message, ErrorCodeEnum errorCode, Exception innerException, HttpStatusCode? statusCode = null) : base(message, innerException)
    {
        this.ErrorCode = errorCode;
        this.StatusCode = statusCode;
    }
}