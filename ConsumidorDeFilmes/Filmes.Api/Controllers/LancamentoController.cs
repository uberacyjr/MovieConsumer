using System.Linq;
using Filmes.Core.Interfaces;
using Filmes.Core.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        private readonly IMovieUpComing _MovieUpComingServices;

        public LancamentoController(IMovieUpComing movieUpComingServices)
        {
            _MovieUpComingServices = movieUpComingServices;
        }

        // GET: api/Lancamento
        [HttpGet]
        public IActionResult Get(string language = "pt-BR", int page = 1, string region = "")
        {
            MovieUpComingDTO moviesUpComing = _MovieUpComingServices.GetMoviesUpComing(language, page, region);

            if (moviesUpComing.Results.Any())
                return Ok(moviesUpComing.Results);

            string mensagensDeValidacao = string.Join(", ", moviesUpComing.Errors.Errors);

            return BadRequest(mensagensDeValidacao);
        }
    }
}