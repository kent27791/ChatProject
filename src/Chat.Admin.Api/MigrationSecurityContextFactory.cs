using Chat.Admin.Api.Extentions;
using Chat.Core.Configuration;
using Chat.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Chat.Admin.Api
{
    public class MigrationSecurityContextFactory : IDesignTimeDbContextFactory<SecurityManagementContext>
    {
        public SecurityManagementContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            ISettings setting = (configuration as IConfiguration).GetCustomizedSettings();

            var builder = new DbContextOptionsBuilder<SecurityManagementContext>();

            var connectionString = setting.ConnectionStrings.SecurityManagement;

            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("Chat.Admin.Api"));

            return new SecurityManagementContext(builder.Options);
        }
    }
}
