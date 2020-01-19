using System.Linq;
using System.Threading.Tasks;
using Filmes.Core.Interfaces;
using Filmes.Core.ResponseDTO.MoviesUpComingDTO;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IMovieUpComing _MovieUpComingServices;

        public FilmeController(IMovieUpComing movieUpComingServices)
        {
            _MovieUpComingServices = movieUpComingServices;
        }

        // GET: api/Filme
        [HttpGet]
        public async Task<IActionResult> Get(string language = "pt-BR", int page = 1, string region = "")
        {
            MovieUpComingDTO moviesUpComing = _MovieUpComingServices.GetMoviesUpComing(language, page, region);

            if (moviesUpComing.Results.Any())
                return Ok(moviesUpComing);

            string mensagensDeValidacao = string.Join(", ", moviesUpComing.Errors.Errors);

            return BadRequest(mensagensDeValidacao);
        }
    }
}