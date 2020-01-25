using Filmes.Infraestrutura.Interfaces;

namespace Filmes.Infraestrutura.InfraestruturaServices
{
    public class ApiSettingsService : IApiSettings
    {
        public ApiSettings ObterAppSettings()
        {
            return new ApiSettings();
        }
    }
}
