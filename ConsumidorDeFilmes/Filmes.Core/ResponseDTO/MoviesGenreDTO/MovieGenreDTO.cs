using System.Collections.Generic;
using Filmes.Core.ResponseDTO.BaseDTO;
using Filmes.Core.ResponseDTO.MoviesGenreDTO;

namespace Filmes.Core.ResponseDTO.BaseDTO
{
    public class MovieGenreDTO : BaseRootObjectDTO
    {
        public List<GenreDTO> Genres { get; set; }
    }
}