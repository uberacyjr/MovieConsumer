using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Filmes.Core.Interfaces;
using Filmes.Core.ResponseModels;
using Filmes.Infraestrutura.Interfaces;
using Newtonsoft.Json;
using RestSharp;

namespace Filmes.Core.Services
{
    public class MovieGenreServices : IMovieGenre
    {
        private readonly IApiSettings _ApiSettings;
        private readonly IMovieApiConsumer _MovieApiConsumer;
        private readonly string Url;
        private readonly string EndPoint = "/genre/movie/list";

        public MovieGenreServices(IApiSettings apiSettings, IMovieApiConsumer movieApiConsumer)
        {
            _ApiSettings = apiSettings;
            _MovieApiConsumer = movieApiConsumer;
            Url = _ApiSettings.ObterAppSettings().BaseUrl + EndPoint;
        }

        public MovieGenreDTO GetGenreListByLanguage(string language)
        {
            RestClient client = _MovieApiConsumer.CriarRequestApi(out RestRequest request, Url);
            Dictionary<string, string> requestParameters = CriarRequestParameters(language);
            _MovieApiConsumer.AdicionarParametrosQueryString(requestParameters, request);
            Task<IRestResponse> restResponse = _MovieApiConsumer.ObterResponseApi(client, request);
            MovieGenreDTO movieGenre = DeserializarResponse(restResponse);
            return movieGenre;
        }

        private static MovieGenreDTO DeserializarResponse(Task<IRestResponse> response)
        {
            var resultado = new MovieGenreDTO();

            if (response.Result.StatusCode == HttpStatusCode.OK)
                resultado = JsonConvert.DeserializeObject<MovieGenreDTO>(response.Result.Content);
            else
            {
                resultado.Errors = JsonConvert.DeserializeObject<ErrorObjectDTO>(response.Result.Content);
                resultado.HttpStatusCode = resultado.HttpStatusCode;
                resultado.Genres = Enumerable.Empty<GenreDTO>().ToList();
            }

            return resultado;
        }

        private static Dictionary<string, string> CriarRequestParameters(string language) => new Dictionary<string, string> { { "language", language }};

    }
}
