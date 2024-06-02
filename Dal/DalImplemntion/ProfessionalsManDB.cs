using Dal.DalApi;
using Dal.DalObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalImplemntion
{
    public class ProfessionalsManDB : IRepo<ProfessionalsMan>
    {
        Context context;
        public ProfessionalsManDB(Context context)
        {
            this.context = context;
        }

        public ProfessionalsMan Add(ProfessionalsMan t)
        {
            context.ProfessionalsMen.Add(t);
            context.Addresses.Add(t.IdAdressNavigation);
            context.Professions.Add(t.IdTypeNavigation);
            context.SaveChanges();
            return t;
        }

        public ProfessionalsMan Delete(int id)
        {
            ProfessionalsMan remove =  context.ProfessionalsMen.Include(x => x.IdAdressNavigation).Include(x => x.IdTypeNavigation).FirstOrDefault(x=>x.Id == id);
            context.ProfessionalsMen.Remove(remove);
            context.SaveChanges();
            return remove;
        }

        public List<ProfessionalsMan> GetAll()
        {
            return context.ProfessionalsMen.Include(x=>x.IdAdressNavigation).Include(x=>x.IdTypeNavigation).Include(x=>x.References).ToList();
        }

        public ProfessionalsMan GetById(int id)
        {
            return context.ProfessionalsMen.Include(x => x.IdAdressNavigation).Include(x => x.IdTypeNavigation).FirstOrDefault(x=>x.Id == id);
        }
        public ProfessionalsMan Update(int id, ProfessionalsMan professionalsMan)
        {
            ProfessionalsMan n = context.ProfessionalsMen.Include(x => x.IdAdressNavigation).Include(x => x.IdTypeNavigation.Type).FirstOrDefault(x => x.Id == id);
            n = professionalsMan;
            context.SaveChanges();
            return professionalsMan;
        }

    }
}
