using System.Collections.Generic;

namespace Filmes.Core.ResponseModels
{
    public class ResultDTO
    {
        public List<int> Genre_ids { get; set; }
        public List<string> Genres { get; set; }
        public string Title { get; set; }
        public string Release_date { get; set; }
    }
}