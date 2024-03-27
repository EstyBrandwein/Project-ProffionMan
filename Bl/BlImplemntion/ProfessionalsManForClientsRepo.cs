using Bl.BlObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Bl.BlApi;
using Dal.DalImplemntion;
using Dal.DalObject;

namespace Bl.BlImplemntion
{
    public class ProfessionalsManForClientsRepo: IRepo<ProfessionalsManToclients>
    {
        DalManager dal;
        public ProfessionalsManForClientsRepo(DalManager dal)
        {
            this.dal = dal;
        }

        public ProfessionalsManToclients Add(ProfessionalsManToclients t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProfessionalsManToclients> GetAll()
        {
            throw new NotImplementedException();
        }

        //public List<ProfessionalsManToclients> GetAll()
        //{
        //    List<ProfessionalsMan> professionalsMan = dal.professionalsMan.GetAll();
        //    List<ProfessionalsManToclients> ans = new List<ProfessionalsManToclients>();
        //    for (int i = 0; i < professionalsMan.Count; i++)
        //    {
        //        ans.Add(new ProfessionalsManToclients())
        //        ProfessionalsManToclients x = new ProfessionalsManToclients();
        //        x.HourlyPrice = professionalsMan[i].HourlyPrice;
        //        AddressToClient addressToClient = new AddressToClient();
        //        addressToClient.City = professionalsMan[i].A
        //        //x.Address.City = professionalsMan[i].Address.;
        //        x.profession = professionalsMan[i].profession;
        //    }



        //}

        public ProfessionalsManToclients GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ProfessionalsManToclients Update(int id, ProfessionalsManToclients t)
        {
            throw new NotImplementedException();
        }

    }
}
