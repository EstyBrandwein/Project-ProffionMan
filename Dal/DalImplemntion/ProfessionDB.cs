using Dal.DalApi;
using Dal.DalObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalImplemntion
{
    public class ProfessionDB : IRepo<Profession>
    {
        Context context;
        public ProfessionDB(Context context)
        {
            this.context = context;
        }

        public Profession Add(Profession t)
        {
            context.Professions.Add(t);
            context.SaveChanges();
            return t;
        }

        public Profession Delete(int id)
        {
            Profession remove =  context.Professions.FirstOrDefault(x=>x.Id == id);
            context.Professions.Remove(remove);
            context.SaveChanges();
            return remove;
        }

        public List<Profession> GetAll()
        {
            return context.Professions.ToList();
        }

        public Profession GetById(int id)
        {
            return context.Professions.FirstOrDefault(x=>x.Id == id);
        }
        public Profession Update(int id, Profession t)
        {
            Profession n = context.Professions.FirstOrDefault(x => x.Id == id);
            n = t;
            context.SaveChanges();
            return t;
        }
    }
}
