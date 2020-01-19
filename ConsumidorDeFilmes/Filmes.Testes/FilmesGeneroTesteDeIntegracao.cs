using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Filmes.Core.Interfaces;
using Filmes.Core.ResponseModels;
using Filmes.Core.Services;
using Filmes.Infraestrutura.InfraestruturaServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Filmes.Testes
{
    [TestClass]
    public class FilmesGeneroTesteDeIntegracao
    {
        public static IMovieGenre _genre;

        public FilmesGeneroTesteDeIntegracao()
        {
            _genre = new MovieGenreServices(new ApiSettingsService(), new MovieApiConsumerServices(new ApiSettingsService()));
        }

        [TestMethod]
        public void Quando_Requisitar_API_Sem_Parametros_Retorna_Lista_Generos()
        {
            MovieGenreDTO upComingMovies = _genre.GetGenreListByLanguage("pt-BR");
            Assert.IsTrue(upComingMovies.Genres.Any());
        }
    }
}
