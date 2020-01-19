using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmes.Core.Interfaces;
using Filmes.Core.Models;
using Filmes.Core.RequestModels;
using Filmes.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Api.Controllers
{
    [Route("filme/[controller]")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private readonly IMovieUpComing _MovieUpComingServices;
        private readonly IEnumerable<string> _Localizacoes;
        public LancamentosController(IMovieUpComing movieUpComingServices, IEnumerable<string> localizacoes)
        {
            _MovieUpComingServices = movieUpComingServices;
            _Localizacoes = AbreviacaoLocalizacao.ObterAbreviacoesLocalizcao();
        }
        // GET: api/Filme
        [HttpGet]
        public IActionResult Get(string language = "pt-BR", int page = 1, string region = "")
        {
            if (page < 1) return BadRequest("Parâmetro page deve ser maior que 1.");
            if (!_Localizacoes.Contains(language)) return BadRequest("Parâmetro language inválido. Infome um entre os: " + string.Join(", ", _Localizacoes));

            MovieUpComingDTO moviesUpComing = _MovieUpComingServices.GetMoviesUpComing(language, page, region);
            return Ok(moviesUpComing.results);
        }
    }
}
