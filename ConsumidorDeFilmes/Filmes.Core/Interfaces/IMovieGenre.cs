using Filmes.Core.ResponseDTO.BaseDTO;

namespace Filmes.Core.Interfaces
{
    public interface IMovieGenre
    {
        MovieGenreDTO GetGenreListByLanguage(string language);
    }
}
