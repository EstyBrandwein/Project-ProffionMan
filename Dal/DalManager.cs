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
        public ProfessionalsManRepo professionalsMan { get; }
        public ProfessionRepo profession { get; }
        public AddressRepo address { get; }
        public ReferenceRepo reference { get; }

        public DalManager()
        {
            // באן הגדרנו אוסף של מחלקות שרות
            ServiceCollection services = new();
            // מוסיפים לאוסף אוביקטים
            services.AddDbContext<Context>();


            services.AddScoped<IRepo<ProfessionalsMan>, ProfessionalsManRepo>();
            services.AddScoped<IRepo<Profession>, ProfessionRepo>();
            services.AddScoped<IRepo<Address>, AddressRepo>();
            services.AddScoped<IRepo<Reference>, ReferenceRepo>();
            //....
            // הגדרת מנהל למחלקות השרות שנקרא פרווידר
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            professionalsMan = (ProfessionalsManRepo ) serviceProvider.GetRequiredService<IRepo<ProfessionalsMan>>();
            profession = (ProfessionRepo) serviceProvider.GetRequiredService<IRepo<Profession>>();
            address = (AddressRepo)serviceProvider.GetRequiredService<IRepo<Address>>();
            reference = (ReferenceRepo)serviceProvider.GetRequiredService<IRepo<Reference>>();
        }
    }
}
