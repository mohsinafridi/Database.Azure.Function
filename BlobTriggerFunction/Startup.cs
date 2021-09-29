using BlobTriggerFunction.Models;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(BlobTriggerFunction.Startup))]
namespace BlobTriggerFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = "Data Source=LHRLT-1125;Integrated Security=true;Database=PracticeDB";
            builder.Services.AddDbContext<AppDbContext>(
                options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
        }
    }
}
