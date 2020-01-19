using Filmes.Core.ResponseModels;

namespace Filmes.Core.Interfaces
{
    public interface IMovieGenre
    {
        MovieGenreDTO GetGenreListByLanguage(string language);
    }
}
