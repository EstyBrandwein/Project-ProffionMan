using Dal.DalApi;
using Dal.DalImplemntion;
using Dal.DalObject;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalManager
    {
        public ProfessionalsManDB professionalsMan { get; }
        public ProfessionDB profession { get; }
        public AddressDB address { get; }
        public ReferenceDB reference { get; }

        public DalManager()
        {
            // באן הגדרנו אוסף של מחלקות שרות
            ServiceCollection services = new();
            // מוסיפים לאוסף אוביקטים
            services.AddDbContext<Context>();

            services.AddScoped<IRepo<ProfessionalsMan>, ProfessionalsManDB>();
            services.AddScoped<IRepo<Profession>, ProfessionDB>();
            services.AddScoped<IRepo<Address>, AddressDB>();
            services.AddScoped<IRepo<Reference>, ReferenceDB>();
            // הגדרת מנהל למחלקות השרות שנקרא פרווידר
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            professionalsMan = (ProfessionalsManDB ) serviceProvider.GetRequiredService<IRepo<ProfessionalsMan>>();
            profession = (ProfessionDB) serviceProvider.GetRequiredService<IRepo<Profession>>();
            address = (AddressDB)serviceProvider.GetRequiredService<IRepo<Address>>();
            reference = (ReferenceDB)serviceProvider.GetRequiredService<IRepo<Reference>>();
        }
    }
}
