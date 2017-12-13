using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

using Newtonsoft.Json.Serialization;
using AutoMapper;
using Autofac;

using Chat.Core.Configuration;
using Chat.Data.DatabaseContext;
using Chat.Core.Data;
using Chat.Data.Repository;
using Chat.Data.UnitOfWork;
using Chat.Service.SecurityManagement;
using Autofac.Extensions.DependencyInjection;
using Chat.Core.Domain.SecurityManagement;

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
            services.AddDbContextPool<SecurityManagementContext>(options => options.UseSqlServer(settings.ConnectionStrings.SecurityManagement, b => b.MigrationsAssembly("Chat.Admin.Api")));
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

        public static IServiceCollection AddCustomizedCors(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsClient", builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            }));
            return services;
        }

        public static IServiceCollection AddCustomizedIdentity(this IServiceCollection services)
        {
            //services.AddIdentity<User, Role>()
            //    .AddRoleStore<SimplRoleStore>()
            //    .AddUserStore<SimplUserStore>()
            //    .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceProvider Build(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SecurityManagementContext>().As<IDatabaseContext<SecurityManagementContext>>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork<SecurityManagementContext>>().As<IUnitOfWork<SecurityManagementContext>>().InstancePerLifetimeScope();

            builder.RegisterType<Repository<SecurityManagementContext, GroupMember, int>>().As<IRepository<SecurityManagementContext, GroupMember, int>>().InstancePerLifetimeScope();
            builder.RegisterType<GroupMemberService>().As<IGroupMemberService>().InstancePerLifetimeScope();

            builder.RegisterInstance(configuration);
            builder.RegisterInstance(hostingEnvironment);
            builder.Populate(services);
            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }



    }
}
