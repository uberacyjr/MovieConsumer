using Filmes.Core.Models;

namespace Filmes.Core.Interfaces
{
    public interface IMovieUpComing
    {
        MovieUpComingDTO GetMoviesUpComing(string language, int page, string region);
    }
}
