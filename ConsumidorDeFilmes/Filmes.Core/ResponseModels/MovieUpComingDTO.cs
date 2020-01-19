using System.Collections.Generic;
using System.Net;

namespace Filmes.Core.ResponseModels
{
    public class MovieUpComingDTO
    {
        public List<ResultDTO> Results { get; set; }
        public int Page { get; set; }
        public int Total_results { get; set; }
        public DateDTO Dates { get; set; }
        public int Total_pages { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public ErrorObject Errors { get; set; }
    }
    
    public class ErrorObject
    {
        public List<string> Errors { get; set; }
    }
}
