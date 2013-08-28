using System.Configuration;
using System.Data;
using Cielo.Responses;
using Cielo.Requests;
using RestSharp;

namespace Cielo
{
    public class CieloService : ICieloService
    {
        private readonly string _endPointUrl;

        public CieloService(string endPointUrl = null)
        {
            if (string.IsNullOrEmpty(endPointUrl)) endPointUrl = ConfigurationManager.AppSettings["cielo.webservice.url"];
            if (string.IsNullOrEmpty(endPointUrl)) throw new NoNullAllowedException("Cielo service endpoint was not provided and its not configured");
            _endPointUrl = endPointUrl;
        }

        private string Execute(ICieloRequest cieloRequest)
        {
            var client = new RestClient(_endPointUrl);
            var request = new RestRequest(Method.POST);
            request.AddParameter("mensagem", cieloRequest.ToXml(false));
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public CreateTransactionResponse CreateTransaction(CreateTransactionRequest request)
        {
            return new CreateTransactionResponse(Execute(request));
        }

        public CheckTransactionResponse CheckTransaction(CheckTransactionRequest request)
        {
            return new CheckTransactionResponse(Execute(request));
        }
    }
}
