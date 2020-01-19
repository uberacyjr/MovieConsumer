using System.Collections.Generic;

namespace Filmes.Core.ResponseModels
{
    public class MovieGenreDTO : BaseRootObjectDTO
    {
        public List<GenreDTO> Genres { get; set; }
    }
}