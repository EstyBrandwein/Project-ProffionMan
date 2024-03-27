using Bl.BlObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi
{
    public interface IProfessionalsManToclientsRepo
    {
        public ProfessionalsManToclients Add(ProfessionalsManToclients t);
        public ProfessionalsManToclients Update(int id, ProfessionalsManToclients t);
        List<ProfessionalsManToclients> GetAll();
        ProfessionalsManToclients GetById(int id);
        ProfessionalsManToclients Delete(int id);
    }
}
