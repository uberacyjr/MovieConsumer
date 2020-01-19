using System.Linq;
using System.Threading.Tasks;
using Filmes.Api.Models;
using Filmes.Core.Interfaces;
using Filmes.Core.ResponseDTO.BaseDTO;
using Filmes.Core.ResponseDTO.MoviesUpComingDTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IMovieUpComing _MovieUpComingServices;
        private readonly IMovieGenre _MovieGenre;

        public FilmeController(IMovieUpComing movieUpComingServices, IMovieGenre movieGenre)
        {
            _MovieUpComingServices = movieUpComingServices;
            _MovieGenre = movieGenre;
        }

        // GET: api/Filme
        [HttpGet]
        public async Task<IActionResult> Get(string language = "pt-BR", int page = 1, string region = "")
        {
            MovieUpComingDTO moviesUpComing = _MovieUpComingServices.GetMoviesUpComing(language, page, region);
            AdicionarGeneroNosFilmes(language, moviesUpComing);

            if (moviesUpComing.Results.Any())
                return Ok(new MovieUpComingVM().ConverterMovieUpcomingDTOParaVM(moviesUpComing));


            string mensagensDeValidacao = string.Join(", ", moviesUpComing.Errors.Errors);

            return BadRequest(mensagensDeValidacao);
        }

        private void AdicionarGeneroNosFilmes(string language, MovieUpComingDTO upcomingMovies)
        {
            if (!upcomingMovies.Results.Any())
                return;
            MovieGenreDTO genres = _MovieGenre.GetGenreListByLanguage(language);
            upcomingMovies.AdicionarGeneroDeAcordoComId(upcomingMovies, genres);
        }
    }
}