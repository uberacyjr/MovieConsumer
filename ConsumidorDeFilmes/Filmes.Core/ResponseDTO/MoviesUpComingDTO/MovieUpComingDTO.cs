using System.Collections.Generic;
using Filmes.Core.ResponseDTO.BaseDTO;

namespace Filmes.Core.ResponseDTO.MoviesUpComingDTO
{
    public class MovieUpComingDTO : BaseRootObjectDTO
    {
        public List<ResultDTO> Results { get; set; }
    }
}
