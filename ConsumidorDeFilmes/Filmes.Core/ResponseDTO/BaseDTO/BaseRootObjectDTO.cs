using System.Net;

namespace Filmes.Core.ResponseDTO.BaseDTO
{
    public class BaseRootObjectDTO
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public ErrorObjectDTO Errors { get; set; }
    }
}
