using Cielo.Requests;
using RestSharp;

namespace Cielo
{
    public interface ICieloService
    {
        IRestResponse Send(IRequestXml request);
    }
}