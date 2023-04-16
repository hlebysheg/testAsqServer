using System;
using testAsqServer.service.formService;

namespace testAsqServer.service
{
    public static class ApplicationDependencyInjectionExtensions
    {
        public static IServiceCollection AddOrderService(this IServiceCollection services)
        {
            return services
                .AddScoped<IFormService, FormServiceWorker>();
        }
    }
}

