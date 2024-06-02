using Dal.DalApi;
using Dal.DalObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalImplemntion
{
    public class ReferenceDB : IRepo<Reference>
    {
        Context context;
        public ReferenceDB(Context context)
        {
            this.context = context;
        }

        public Reference Add(Reference t)
        {
            context.References.Add(t);
            context.SaveChanges();
            return t;
        }

        public ProfessionalsMan Delete(int id)
        {
            foreach (var item in context.References)
            {
                if(item.IdProfessionals == id)
                {
                    context.References.Remove(item);
                }
            }

            context.SaveChanges();
            return context.ProfessionalsMen.FirstOrDefault(x => x.Id == id);
        }

        public List<Reference> GetAll()
        {
            return context.References.ToList();
        }

        public Reference GetById(int id)
        {
            return context.References.FirstOrDefault(x=>x.Id == id);
        }
        public Reference Update(int id, Reference professionalsMan)
        {
            Reference n = context.References.FirstOrDefault(x => x.Id == id);
            n = professionalsMan;
            context.SaveChanges();
            return professionalsMan;
        }

        Reference IRepo<Reference>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
