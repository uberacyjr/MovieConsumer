using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Filmes.Core.Interfaces;
using Filmes.Core.ResponseDTO.BaseDTO;
using Filmes.Core.ResponseDTO.MoviesUpComingDTO;
using Filmes.Infraestrutura.Interfaces;
using Newtonsoft.Json;
using RestSharp;

namespace Filmes.Core.Services
{
    /// <summary>
    /// Serviço responsável por requisições para https://api.themoviedb.org/3/movie/upcoming
    /// </summary>
    public class MovieUpComingServices : IMovieUpComing
    {
        private readonly IMovieApiConsumer _MovieApiConsumer;
        private readonly IMovieGenre _MovieGenre;
        private readonly string Url;
        private const string EndPoint = "/movie/upcoming";

        public MovieUpComingServices(IApiSettings apiSettings, IMovieApiConsumer movieApiConsumer)
        {
            _MovieApiConsumer = movieApiConsumer;
            Url = apiSettings.ObterAppSettings().BaseUrl + EndPoint;
        }

        public MovieUpComingDTO GetMoviesUpComing(string language, int page, string region)
        {
            RestClient client = _MovieApiConsumer.CriarRequestApi(out RestRequest request, Url);
            Dictionary<string, string> requestParameters = CriarRequestParameters(language, page, region);
            _MovieApiConsumer.AdicionarParametrosQueryString(requestParameters, request);
            Task<IRestResponse> restResponse = _MovieApiConsumer.ObterResponseApi(client, request);
            MovieUpComingDTO upcomingMovies = DeserializarResponse(restResponse);
            //AdicionarGeneroNosFilmes(language, upcomingMovies);

            return upcomingMovies;
        }

        private void AdicionarGeneroNosFilmes(string language, MovieUpComingDTO upcomingMovies)
        {
            if(!upcomingMovies.Results.Any())
                return;

            MovieGenreDTO genres = _MovieGenre.GetGenreListByLanguage(language);
            AdicionarGeneroDeAcordoComId(upcomingMovies, genres);
        }

        private static void AdicionarGeneroDeAcordoComId(MovieUpComingDTO upcomingMovies, MovieGenreDTO genres)
        {
            foreach (ResultDTO movie in upcomingMovies.Results)
            {
                movie.Genres = new List<string>();

                foreach (string genreName in movie.Genre_ids.Select(genreId => genres.Genres.First(f => f.Id == genreId)?.Name))
                {
                    movie.Genres.Add(genreName);
                }
            }
        }

        private static MovieUpComingDTO DeserializarResponse(Task<IRestResponse> response)
        {
            var resultado = new MovieUpComingDTO();

            if (response.Result.StatusCode == HttpStatusCode.OK)
                resultado = JsonConvert.DeserializeObject<MovieUpComingDTO>(response.Result.Content);
            else
            {
                resultado.Errors = JsonConvert.DeserializeObject<ErrorObjectDTO>(response.Result.Content);
                resultado.HttpStatusCode = resultado.HttpStatusCode;
                resultado.Results = Enumerable.Empty<ResultDTO>().ToList();
            }

            return resultado;
        }

        private static Dictionary<string, string> CriarRequestParameters(string language, int page, string region) => new Dictionary<string, string> { { "language", language }, { "page", page.ToString() }, { "regioan", region } };
    }
}
