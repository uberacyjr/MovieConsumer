using System;
using System.Collections.Generic;
using Filmes.Core.ResponseDTO.MoviesUpComingDTO;

namespace Filmes.Api.Models
{
    public class MovieUpComingVM
    {
        public string Genero { get; set; }
        public string Nome { get; set; }
        public string DataLancamento { get; set; }

        public List<MovieUpComingVM> ConverterMovieUpcomingDTOParaVM(MovieUpComingDTO resultado)
        {
            return resultado.Results.ConvertAll(c => new MovieUpComingVM
            {
                Genero = string.Join(",", c.Genres),
                Nome = c.Title,
                DataLancamento = $"{c.Release_date:dd/MM/yyyy}"
            });
        }
    }
}
