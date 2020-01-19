using System.Net;

namespace Filmes.Core.ResponseModels
{
    public class BaseRootObjectDTO
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public ErrorObjectDTO Errors { get; set; }
    }
}
