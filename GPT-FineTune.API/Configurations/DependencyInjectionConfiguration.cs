using GPT_FineTune.Application.Interfaces;
using GPT_FineTune.Application.Services;
using GPT_FineTune.Infra.Repositories;

namespace GPT_FineTune.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITrainingDataService, TrainingDataService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFineTuneService, FineTuneService>();
            services.AddScoped<IFileApiRepository, FileApiRepository>();
            services.AddScoped<IFineTuneApiRepository, FineTuneApiRepository>();

            return services;
        }
    }
}
