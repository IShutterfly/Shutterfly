using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace DataAccess
{
    public class UsersDbContextFactory : IDesignTimeDbContextFactory<UsersDbContext>
    {
        public UsersDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<UsersDbContext>();

            string callingAssemblyPath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));

            var connectionString = configuration.GetConnectionString("DefaultConnection").Replace("%CONTENTROOTPATH%", callingAssemblyPath);
            builder.UseSqlServer(connectionString);

            return new UsersDbContext(connectionString);
        }
    }
}
