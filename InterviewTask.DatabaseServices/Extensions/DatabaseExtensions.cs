﻿using InterviewTask.DatabaseServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewTask.DatabaseServices.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services)
        {
            services.AddScoped<DatabaseOperation>();

            return services;
        }
    }
}