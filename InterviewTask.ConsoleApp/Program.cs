﻿using InterviewTask.EntityFramework;
using InterviewTask.Logic.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InterviewTask.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var consoleApp = CreateHostBuilder(args)
                             .Build()
                             .Services
                             .GetService<ConsoleApp>();
            consoleApp.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureServices((context, services) =>
               {
                   services.AddScoped<ConsoleApp>()
                     .AddScoped<LinksDisplay>()
                     .AddEfRepository<CrawlerContext>(o =>
                     {
                         string dbConnection = context.Configuration.GetConnectionString("connection");
                         o.UseSqlServer(dbConnection);
                     })
                     .AddInterviewTaskLogicServices();
               })
               .ConfigureLogging(options => options.SetMinimumLevel(LogLevel.Error));
    }
}