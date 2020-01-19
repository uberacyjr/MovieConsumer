using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Filmes.Infraestrutura.Interfaces;
using RestSharp;

namespace Filmes.Infraestrutura.InfraestruturaServices
{
    public class MovieApiConsumerServices: IMovieApiConsumer
    {
        private readonly IApiSettings _ApiSettings;

        public MovieApiConsumerServices(IApiSettings apiSettings)
        {
            _ApiSettings = apiSettings;
        }

        public RestClient CriarRequestApi(out RestRequest request, string Url)
        {
            var client = new RestClient(Url);
            request = new RestRequest(Url);
            return client;
        }

        public void AdicionarParametrosQueryString(Dictionary<string, string> queryStringParameters, IRestRequest request)
        {
            request.AddParameter("api_key", _ApiSettings.ObterAppSettings().MovieApiKey);

            foreach (KeyValuePair<string, string> parameter in queryStringParameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }
        }

        public async Task<IRestResponse> ObterResponseApi(IRestClient client, IRestRequest request)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            IRestResponse restResponse = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
            return restResponse;
        }
    }
}
