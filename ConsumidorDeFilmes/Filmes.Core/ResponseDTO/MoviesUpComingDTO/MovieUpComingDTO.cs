using System.Collections.Generic;

namespace Filmes.Core.ResponseModels
{
    public class MovieUpComingDTO : BaseRootObjectDTO
    {
        public List<ResultDTO> Results { get; set; }
    }
}
