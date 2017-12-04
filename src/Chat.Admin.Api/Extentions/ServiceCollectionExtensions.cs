using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

using Newtonsoft.Json.Serialization;
using AutoMapper;

using Chat.Core.Configuration;
using Chat.Data.DatabaseContext;
namespace Chat.Admin.Api.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static ISettings GetCustomizedSettings(this IConfiguration configuration)
        {
            ISettings settings = configuration.GetSection("MySettings").Get<MySettings>();
            return settings;
        }

        public static IServiceCollection AddCustomizedSettings(this IServiceCollection services, ISettings settings)
        {
            services.AddSingleton<ISettings>(settings);
            return services;
        }

        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services)
        {
            //services.AddMvc().AddJsonOptions(options =>
            //{
            //    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //});
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
            });
            return services;
        }

        public static IServiceCollection AddCustomizedDataStore(this IServiceCollection services, ISettings settings)
        {
            services.AddDbContextPool<LogManagementContext>(options => options.UseSqlServer(settings.ConnectionStrings.LogManagement));
            services.AddDbContextPool<SecurityManagementContext>(options => options.UseSqlServer(settings.ConnectionStrings.SecurityManagement));
            services.AddDbContextPool<ChatManagementContext>(options => options.UseSqlServer(settings.ConnectionStrings.ChatManagement));
            return services;
        }

        public static IServiceCollection AddCustomizedAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper();
            return services;
        }

        public static IServiceCollection AddCustomizedSwagger(this IServiceCollection services)
        {
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "Payment api document", Version = "v1" });
            //});
            return services;
        }

        public static IServiceProvider Build(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            return services.BuildServiceProvider();
        }



    }
}
