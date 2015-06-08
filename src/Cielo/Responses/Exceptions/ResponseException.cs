using System;

namespace Cielo.Responses.Exceptions
{
    public class ResponseException : ApplicationException
    {
        public ResponseException(ErrorResponse responseError)
            : base(responseError.Message)
        {
            ResponseError = responseError;
        }

        public ResponseException(string responseContent, Exception innerException)
            : base(responseContent, innerException)
        {
        }

        public ErrorResponse ResponseError { get; set; }
    }
}