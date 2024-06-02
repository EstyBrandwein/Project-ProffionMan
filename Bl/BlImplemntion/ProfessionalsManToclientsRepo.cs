using Bl.BlApi;
using Bl.BlObject;
using Dal;
using Dal.DalImplemntion;
using Dal.DalObject;
using System.Collections.ObjectModel;

namespace Bl.BlImplemntion
{
    public class ProfessionalsManToclientsRepo:IProfessionalsManToclientsRepo
    {
        ProfessionalsManDB professionalsManRepo;
        AddressDB addressRepo;
        ProfessionDB professionRepo;
        ReferenceDB reference;
        public ProfessionalsManToclientsRepo(DalManager dalManager)
        {
            this.professionalsManRepo = dalManager.professionalsMan;
            this.addressRepo = dalManager.address;
            this.professionRepo = dalManager.profession;
            this.reference = dalManager.reference;
        }

        public ProfessionalsManToclients Add(ProfessionalsManToclients t,AddressToClient address,int appartment,string street,string typeProfession)
        {
            ProfessionalsMan a = new ProfessionalsMan()
            {
                FirstName = t.FirstName,
                LastName = t.LastName,
                Email = t.Email,
                WhatsApp = t.WhatsApp,
                IdAdressNavigation = new Address() {City = address.City,Neighborhood = address.Nighbord,Building = appartment,Street = street}
                ,IdTypeNavigation = new Profession() { Type =typeProfession }
                ,Phon = t.Phon
                
            
            };

            professionalsManRepo.Add(a);
            return t;
        }
        public ProfessionalsManToclients Delete(int idPrefessional)
        {
            ProfessionalsMan t = professionalsManRepo.Delete(idPrefessional);
            Address a = addressRepo.Delete(t.IdAdress);
            reference.Delete(idPrefessional);
            return new ProfessionalsManToclients() {FirstName = t.FirstName,LastName = t.LastName,
                Email = t.Email,WhatsApp = t.WhatsApp,Phon= t.Phon,
                Address = new AddressToClient() {City = a.City,Nighbord = a.Neighborhood },
                profession = new ProfessionToClient() {Type = t.IdTypeNavigation.Type}
            };
        }
        public List<ProfessionalsManToclients> GetAll()
        {
            List<ProfessionalsMan> addressToClients = professionalsManRepo.GetAll();
            List<ProfessionalsManToclients> ans = new List<ProfessionalsManToclients>();
            for (int i = 0; i < addressToClients.Count; i++)
            {
                ProfessionalsManToclients a = new ProfessionalsManToclients();
                //a.Id = addressToClients[i].Id;
                a.FirstName = addressToClients[i].FirstName;
                a.LastName = addressToClients[i].LastName;
                a.Phon = addressToClients[i].Phon;
                a.WhatsApp = addressToClients[i].WhatsApp;
                a.Email = addressToClients[i].Email;
               // a.HourlyPrice = addressToClients[i].HourlyPrice;
                a.Address = new AddressToClient()
                {
                    //Id = addressToClients[i].IdAdressNavigation.Id,
                    City = addressToClients[i].IdAdressNavigation.City,
                    Nighbord = addressToClients[i].IdAdressNavigation.Neighborhood
                };
                a.profession = new ProfessionToClient() { 
                    //Id = addressToClients[i].IdTypeNavigation.Id, 
                    Type = addressToClients[i].IdTypeNavigation.Type };
                a.References = new Collection<ReferenceBL>();
                foreach (var item in addressToClients[i].References)
                {
                    a.References.Add(new ReferenceBL() { 
                        Describe = item.Describe,Eamail = item.Email
                        ,Phon = item.Phon,Rating = item.Rating,Name = item.Name });
                }
                


                ans.Add(a);
            }
            return ans;
        }

        public ProfessionalsManToclients GetById(int id)
        {
            ProfessionalsMan professionalMen = professionalsManRepo.GetById(id);
            if(professionalMen == null)
            {
                throw new Exception("there is no this id");
            }
            ProfessionalsManToclients a = new ProfessionalsManToclients()
            {
                //Id = professionalMen.Id,
                FirstName = professionalMen.FirstName,
                LastName = professionalMen.LastName,
                Phon = professionalMen.Phon,
                WhatsApp = professionalMen.WhatsApp,
                Email = professionalMen.Email,
                //HourlyPrice = professionalMen.HourlyPrice,
                Address = new AddressToClient()
                {
                    //Id = professionalMen.IdAdressNavigation.Id,
                    City = professionalMen.IdAdressNavigation.City,
                    Nighbord = professionalMen.IdAdressNavigation.Neighborhood
                },
                profession = new ProfessionToClient() {
                    //Id = professionalMen.IdTypeNavigation.Id, 
                    Type = professionalMen.IdTypeNavigation.Type }
                
            };
            a.References = new Collection<ReferenceBL>();
            foreach (var item in professionalMen.References)
            {
                a.References.Add(new ReferenceBL()
                {
                    Describe = item.Describe,
                    Eamail = item.Email
                    ,
                    Phon = item.Phon,
                    Rating = item.Rating,
                    Name = item.Name
                });
            }
            return a;


        }


        public ProfessionalsManToclients Update(ProfessionalsManToclients t,string street,int building)
        {
            ProfessionalsMan professionalmanToUpdate = new ProfessionalsMan()
            {
                FirstName = t.FirstName,
                LastName = t.LastName,
                Email = t.Email,
                WhatsApp = t.WhatsApp,
                Phon = t.Phon,
                IdAdressNavigation= new Address() { City = t.Address.City,Neighborhood = t.Address.Nighbord,Street = street,Building = building},
                IdTypeNavigation = new Profession() { Type = t.profession.Type}
            };
            professionalsManRepo.Update(professionalmanToUpdate.Id, professionalmanToUpdate);
            return t;
        }

    }
}
