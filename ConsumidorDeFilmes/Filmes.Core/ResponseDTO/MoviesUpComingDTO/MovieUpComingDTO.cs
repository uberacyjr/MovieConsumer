using System.Collections.Generic;
using System.Linq;
using Filmes.Core.ResponseDTO.BaseDTO;

namespace Filmes.Core.ResponseDTO.MoviesUpComingDTO
{
    public class MovieUpComingDTO : BaseRootObjectDTO
    {
        public List<ResultDTO> Results { get; set; }

        public void AdicionarGeneroDeAcordoComId(MovieUpComingDTO upcomingMovies, MovieGenreDTO genres)
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
    }
}
