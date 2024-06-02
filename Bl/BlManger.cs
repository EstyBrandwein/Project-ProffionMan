using Bl.BlImplemntion;
using Dal;
using Dal.DalImplemntion;
//using Dal.DalObject;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Bl
{
    public class BlManger
    {
        public AddressForClientRepo addressForClientRepo { get; }
        public ProfessionalsManToclientsRepo professionalsManToclientsRepo { get; }
        //.....

        public BlManger(string connection)
        {
            ServiceCollection services = new();
            services.AddScoped<DalManager>(d => new DalManager(connection));
            //services.AddScoped<DalManager>();

            services.AddScoped<AddressForClientRepo>();
            services.AddScoped<ProfessionalsManToclientsRepo>();
            //.....
            ServiceProvider servicesProvider = services.BuildServiceProvider();
            
            addressForClientRepo= servicesProvider.GetService<AddressForClientRepo>();
            professionalsManToclientsRepo = servicesProvider.GetService<ProfessionalsManToclientsRepo>();  
            //..........

        }
    }
}
