using System;
using System.Configuration;
using System.Data;
using Cielo.Responses;
using Cielo.Requests;
using Cielo.Responses.Exceptions;
using RestSharp;

namespace Cielo {
    public class CieloService : ICieloService {
        private readonly string _endPointUrl;

        public CieloService(string endPointUrl = null) {
            if (string.IsNullOrEmpty(endPointUrl)) endPointUrl = ConfigurationManager.AppSettings["cielo.webservice.url"];
            if (string.IsNullOrEmpty(endPointUrl)) throw new NoNullAllowedException("Cielo service endpoint was not provided and its not configured");
            _endPointUrl = endPointUrl;
        }

        protected virtual string Execute(ICieloRequest cieloRequest) {
            var client = new RestClient(_endPointUrl);
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Xml };
            var mensagemValue = cieloRequest.ToXml(false);
            request.AddParameter("mensagem", mensagemValue);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public CreateTransactionResponse CreateTransaction(CreateTransactionRequest request) {
            var responseContent = string.Empty;

            try {
                responseContent = Execute(request);
                CreateExceptionIfError(responseContent);
                return new CreateTransactionResponse(responseContent);
            }
            catch (Exception ex) {
                throw new ResponseException(responseContent, ex);
            }
        }

        public CheckTransactionResponse CheckTransaction(CheckTransactionRequest request) {

            var responseContent = string.Empty;
            try {
                responseContent = Execute(request);
                CreateExceptionIfError(responseContent);
                return new CheckTransactionResponse(responseContent);
            }
            catch (Exception ex) {
                throw new ResponseException(responseContent, ex);
            }
        }

        public CancelTransactionResponse CancelTransaction(CancelTransactionRequest request) {
            var responseContent = string.Empty;
            try {
                responseContent = Execute(request);
                CreateExceptionIfError(responseContent);
                return new CancelTransactionResponse(responseContent);
            }
            catch (Exception ex) {
                throw new ResponseException(responseContent, ex);
            }
        }

        private static void CreateExceptionIfError(string responseContent) {
            if (responseContent.Contains("<erro xmlns=\"http://ecommerce.cbmp.com.br\">")) {
                throw new ResponseException(new ErrorResponse(responseContent));
            }
        }
    }
}
