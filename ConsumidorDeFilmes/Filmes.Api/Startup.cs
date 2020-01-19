using Filmes.Core.Interfaces;
using Filmes.Core.Services;
using Filmes.Infraestrutura.InfraestruturaServices;
using Filmes.Infraestrutura.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Filmes.Api
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddTransient<IMovieUpComing, MovieUpComingServices>();
            services.AddTransient<IApiSettings, ApiSettingsService>();
            services.AddTransient<IMovieApiConsumer, MovieApiConsumerServices>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


           
        }
    }
}
