using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Iti.Challenge.CrossCutting.DependencyInjection
{
    public static class MediatorServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Iti.Challenge.Application");
            services.AddMediatR(assembly);
            return services;
        }
    }
}
