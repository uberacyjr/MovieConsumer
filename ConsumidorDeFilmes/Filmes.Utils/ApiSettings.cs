using System;
using System.Collections.Generic;

namespace Filmes.Infraestrutura
{
    public class ApiSettings
    {
        public string MovieApiKey { get; } = "a1de31f89cd7dc7847967f7b2c2dfe29";
        public string BaseUrl { get; } = "https://api.themoviedb.org/3";
    }
}
