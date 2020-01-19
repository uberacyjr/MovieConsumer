using System.Collections.Generic;
using Filmes.Core.ResponseDTO.MoviesUpComingDTO;

namespace Filmes.Api.Models
{
    public class MovieUpComingVM
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string DataLancamento { get; set; }

        public static List<MovieUpComingVM> ConveterParaVM(MovieUpComingDTO movieUpComingDTO)
        {
            List<MovieUpComingVM> moviesVM = movieUpComingDTO.Results.ConvertAll(r => new MovieUpComingVM
            {
                Nome = r.Title,
                Genero = "",
                DataLancamento = r.Release_date
            });

            return moviesVM;
        }
    }
}
