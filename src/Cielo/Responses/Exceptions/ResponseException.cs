using System;

namespace Cielo.Responses.Exceptions {

    public class ResponseException : ApplicationException {
        public ErrorResponse ResponseError { get; set; }

        public ResponseException(ErrorResponse responseError)
            : base(responseError.Message) {
            ResponseError = responseError;
        }

        public ResponseException(string responseContent, Exception innerException)
            : base(message: responseContent, innerException: innerException) {

        }
    }
}
