using System.Linq;
using System.Net;
using Filmes.Core.Interfaces;
using Filmes.Core.ResponseModels;
using Newtonsoft.Json;
using RestSharp;

namespace Filmes.Core.Services
{
    /// <summary>
    /// Serviço responsável por requisições para https://api.themoviedb.org/3/movie/upcoming
    /// </summary>
    public class MovieUpComingServices : IMovieUpComing
    {
        private const string Url = "https://api.themoviedb.org/3/movie/upcoming";
        //TODO: Passar para o appsettings.json
        private const string MovieApiKey = "a1de31f89cd7dc7847967f7b2c2dfe29";

        public MovieUpComingDTO GetMoviesUpComing(string language, int page, string region)
        {
            RestClient client = CriarRequestApi(out RestRequest request);
            AdicionarParametrosQueryString(language, page, region, request);
            MovieUpComingDTO upcomingMovies = ObterResponseApi(client, request);
            return upcomingMovies;
        }

        private static MovieUpComingDTO ObterResponseApi(IRestClient client, IRestRequest request)
        {
            IRestResponse response = client.Get(request);
            MovieUpComingDTO upcomingMovies = DeserializarResponse(response);
            return upcomingMovies;
        }

        private static MovieUpComingDTO DeserializarResponse(IRestResponse response)
        {
            var resultado = new MovieUpComingDTO();

            if (response.StatusCode == HttpStatusCode.OK)
                resultado = JsonConvert.DeserializeObject<MovieUpComingDTO>(response.Content);
            else
            {
                resultado.Errors = JsonConvert.DeserializeObject<ErrorObjectDTO>(response.Content);
                resultado.HttpStatusCode = resultado.HttpStatusCode;
                resultado.Results = Enumerable.Empty<ResultDTO>().ToList();
            }

            return resultado;
        }

        private static RestClient CriarRequestApi(out RestRequest request)
        {
            var client = new RestClient(Url);
            request = new RestRequest(Url);
            return client;
        }

        private static void AdicionarParametrosQueryString(string language, int page, string region, IRestRequest request)
        {
            request.AddParameter("api_key", MovieApiKey);
            request.AddParameter("language", language);
            request.AddParameter("page", page);
            request.AddParameter("regioan", region);
        }
    }
}
