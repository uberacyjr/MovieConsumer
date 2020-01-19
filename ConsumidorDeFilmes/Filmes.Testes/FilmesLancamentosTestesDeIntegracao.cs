using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Filmes.Core.Interfaces;
using Filmes.Core.Models;
using Filmes.Core.RequestModels;
using Filmes.Core.Services;

namespace Filmes.Testes
{
    [TestClass]
    public class FilmesLancamentosTestesDeIntegracao
    {
        private static IMovieUpComing _movie;

        public FilmesLancamentosTestesDeIntegracao()
        {
            _movie = new MovieUpComingServices();
        }

        [TestMethod]
        public void Quando_Requisitar_API_Sem_Parametros_Retorna_Lista_Filmes_Lancamentos()
        {
            MovieUpComingDTO upComingMovies = _movie.GetMoviesUpComing();
            Assert.IsTrue(upComingMovies.results.Any());
        }

    }
}