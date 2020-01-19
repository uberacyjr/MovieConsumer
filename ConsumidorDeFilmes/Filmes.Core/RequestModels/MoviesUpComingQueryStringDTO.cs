namespace Filmes.Core.RequestModels
{
    public class MoviesUpComingQueryStringDTO
    {
        public string Language { get; set; } = "en-US";
        public string Page { get; set; } = "1";
        public string Region { get; set; } = "";
    }
}
