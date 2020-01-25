using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace Filmes.Infraestrutura.Interfaces
{
    public interface IMovieApiConsumer
    {
        RestClient CriarRequestApi(out RestRequest request, string Url);
        void AdicionarParametrosQueryString(Dictionary<string, string> queryStringParameters, IRestRequest request);
        Task<IRestResponse> ObterResponseApi(IRestClient client, IRestRequest request);
    }
}
