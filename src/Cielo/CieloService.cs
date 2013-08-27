using RestSharp;
using Cielo.Requests;

namespace Cielo
{
    public class CieloService : ICieloService
    {
        private readonly string _endPointUrl;

        public CieloService(string endPointUrl)
        {
            _endPointUrl = endPointUrl;
        }

        public IRestResponse Send(IRequestXml request)
        {
            var client = new RestClient(_endPointUrl);
            var postRequest = new RestRequest(Method.POST);
            postRequest.AddParameter("mensagem", request.ToXml(false));
            return client.Execute(postRequest);
        }
    }
}
