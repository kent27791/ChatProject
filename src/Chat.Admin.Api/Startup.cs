using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Chat.Admin.Api.Extentions;
using Chat.Core.Configuration;
using Chat.Core.Data;
using Chat.Core.Domain.LogManagement;
using Chat.Data.DatabaseContext;
using Chat.Data.Repository;
using Chat.Service.LogManagement;
using Chat.Data.UnitOfWork;
using Chat.Core.Domain.SecurityManagement;
using Chat.Service.SecurityManagement;

namespace Chat.Admin.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly ISettings _settings;
        private readonly IHostingEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _settings = configuration.GetCustomizedSettings();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //system
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCustomizedSettings(_settings);
            services.AddCustomizedMvc();
            services.AddCustomizedDataStore(_settings);
            services.AddCustomizedAutoMapper();
            services.AddCustomizedSwagger();
            //database
            services.AddSingleton<IDatabaseContext<LogManagementContext>, LogManagementContext>();
            services.AddSingleton<IDatabaseContext<SecurityManagementContext>, SecurityManagementContext>();
            //unit of work
            services.AddSingleton<IUnitOfWork<LogManagementContext>, UnitOfWork<LogManagementContext>>();
            services.AddSingleton<IUnitOfWork<SecurityManagementContext>, UnitOfWork<SecurityManagementContext>>();
            //repository
            services.AddTransient<IRepository<LogManagementContext, SystemLog, int>, Repository<LogManagementContext, SystemLog, int>>();
            services.AddTransient<IRepository<SecurityManagementContext, GroupMember, int>, Repository<SecurityManagementContext, GroupMember, int>>();
            //service
            services.AddTransient<ISystemLogService, SystemLogService>();
            services.AddTransient<IGroupMemberService, GroupMemberService>();

            return services.Build(_configuration, _hostingEnvironment);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePagesWithReExecute("/Home/ErrorWithCode/{0}");
            app.UseCustomizedStaticFiles(env);
            app.UseCustomizedIdentity();
            app.UseCustomizedMvc();
            app.UseCustomizedLogger(env, loggerFactory);
            app.UseCustomizedSwagger();
        }
    }
}
