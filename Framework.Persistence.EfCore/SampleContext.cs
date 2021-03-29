using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Persistence.EfCore
{
    public class SampleContext : DbContext
    {
        private readonly string connectionString;
        private readonly bool useLogging;

        //in Startup, instead of services.AddDbContext<>, use 
        //services.AddScoped(_ => new SampleContext(connectionString, useLogging));
        //and you can provide those parameters via configuration
        public SampleContext(string connectionString, bool useLogging)
        {
            this.connectionString = connectionString;
            this.useLogging = useLogging;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(this.connectionString);

            /*if (useLogging)
             * optionsBuilder.LoggerFactor(...)*/
        }
    }
}
