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
        public ProfessionalsManToclients Add(ProfessionalsManToclients t, AddressToClient address, int appartment, string street, string typeProfession);
        public ProfessionalsManToclients Update(ProfessionalsManToclients t, string street, int building);
        List<ProfessionalsManToclients> GetAll();
        ProfessionalsManToclients GetById(int id);
        ProfessionalsManToclients Delete(int id);
    }
}
