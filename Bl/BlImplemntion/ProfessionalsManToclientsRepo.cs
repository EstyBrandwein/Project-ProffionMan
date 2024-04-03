using Bl.BlApi;
using Bl.BlObject;
using Dal;
using Dal.DalImplemntion;
using Dal.DalObject;

namespace Bl.BlImplemntion
{
    public class ProfessionalsManToclientsRepo:IProfessionalsManToclientsRepo
    {
        ProfessionalsManDB professionalsManRepo;
        AddressDB addressRepo;
        ProfessionDB professionRepo;
        public ProfessionalsManToclientsRepo(DalManager dalManager)
        {
            this.professionalsManRepo = dalManager.professionalsMan;
            this.addressRepo = dalManager.address;
            this.professionRepo = dalManager.profession;
        }

        public ProfessionalsManToclients Add(ProfessionalsManToclients t)
        {
            ProfessionalsMan a = new ProfessionalsMan() { 
                Id = t.Id,FirstName = t.FirstName,LastName = t.LastName,
                Email = t.Email,WhatsApp = t.WhatsApp,IdAdress = t.Address.Id,IdType= t.profession.Id};
            professionalsManRepo.Add(a);
            return t;
        }
        public ProfessionalsManToclients Delete(int idPrefessional)
        {
            ProfessionalsMan t = professionalsManRepo.Delete(idPrefessional);
            Address a = addressRepo.Delete(t.IdAdress);
            Profession p = professionRepo.Delete(t.IdType);
            return new ProfessionalsManToclients() { Id = t.Id,FirstName = t.FirstName,LastName = t.LastName,
                Email = t.Email,WhatsApp = t.WhatsApp,
                Address = new AddressToClient() {Id = a.Id,City = a.City,Nighbord = a.Neighborhood },
                profession = new ProfessionToClient() {Id =  p.Id,Type = p.Type}
            };
        }
        public List<ProfessionalsManToclients> GetAll()
        {
            List<ProfessionalsMan> addressToClients = professionalsManRepo.GetAll();
            List<ProfessionalsManToclients> ans = new List<ProfessionalsManToclients>();
            for (int i = 0; i < addressToClients.Count; i++)
            {
                ProfessionalsManToclients a = new ProfessionalsManToclients();
                a.Id = addressToClients[i].Id;
                a.FirstName = addressToClients[i].FirstName;
                a.LastName = addressToClients[i].LastName;
                a.Phon = addressToClients[i].Phon;
                a.WhatsApp = addressToClients[i].WhatsApp;
                a.Email = addressToClients[i].Email;
                a.HourlyPrice = addressToClients[i].HourlyPrice;
                a.Address = new AddressToClient()
                {
                    Id = addressToClients[i].IdAdressNavigation.Id,
                    City = addressToClients[i].IdAdressNavigation.City,
                    Nighbord = addressToClients[i].IdAdressNavigation.Neighborhood
                };
                a.profession = new ProfessionToClient() { Id = addressToClients[i].IdTypeNavigation.Id, Type = addressToClients[i].IdTypeNavigation.Type };
                ans.Add(a);
            }
            return ans;
        }

        public ProfessionalsManToclients GetById(int id)
        {
            ProfessionalsMan professionalMen = professionalsManRepo.GetById(id);
            return new ProfessionalsManToclients()
            {
                Id = professionalMen.Id,
                FirstName = professionalMen.FirstName,
                LastName = professionalMen.LastName,
                Phon = professionalMen.Phon,
                WhatsApp = professionalMen.WhatsApp,
                Email = professionalMen.Email,
                HourlyPrice = professionalMen.HourlyPrice,
                Address = new AddressToClient()
                {
                    Id = professionalMen.IdAdressNavigation.Id,
                    City = professionalMen.IdAdressNavigation.City,
                    Nighbord = professionalMen.IdAdressNavigation.Neighborhood
                },
                profession = new ProfessionToClient() { Id = professionalMen.IdTypeNavigation.Id, Type = professionalMen.IdTypeNavigation.Type }
            };

        }


        public ProfessionalsManToclients Update(int id, ProfessionalsManToclients t)
        {
            ProfessionalsMan professionalmanToUpdate = new ProfessionalsMan()
            {
                Id = t.Id,
                FirstName = t.FirstName,
                LastName = t.LastName,
                Email = t.Email,
                WhatsApp = t.WhatsApp,
                IdAdress = t.Address.Id,
                IdType = t.profession.Id
            };
            professionalsManRepo.Update(professionalmanToUpdate.Id, professionalmanToUpdate);
            return t;
        }

    }
}
