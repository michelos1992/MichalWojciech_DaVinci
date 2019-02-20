using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace REPOSITORY.Models
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var builder = new ConfigurationBuilder()
            //                    .SetBasePath(Directory.GetCurrentDirectory())
            //                    .AddJsonFile("appsettings.json");
            //var configuration = builder.Build();
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-N29LUPF\MISIUSQL;Database=mydemo7;persist security info=True;Integrated Security=SSPI;");

        }
        public DbSet<Product> Products { get; set; }
    }
}
