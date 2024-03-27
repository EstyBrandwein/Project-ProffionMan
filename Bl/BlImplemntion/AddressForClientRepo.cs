using Bl.BlApi;
using Bl.BlObject;
using Dal;
using Dal.DalImplemntion;
using Dal.DalObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlImplemntion
{
    public class AddressForClientRepo : IRepoAddress
    {
        AddressRepo addressRepo;
        public AddressForClientRepo(DalManager dalManager)
        {
            this.addressRepo = dalManager.address;
        }

        public AddressToClient Add(AddressToClient t, string street, string apartment)
        {
            
            addressRepo.Add(new Address() { City = t.City,Street = street, Apartment = apartment,Neighborhood = t.Nighbord,Id = t.Id});
            return t;
        }
        public AddressToClient Delete(int id)
        {
            Address a = addressRepo.Delete(id);
            return new AddressToClient() { City = a.City, Nighbord = a.Neighborhood };
        }
        public List<AddressToClient> GetAll()
        {
            List<Address> addressToClients = addressRepo.GetAll();
            List<AddressToClient> ans = new List<AddressToClient>();
            for (int i = 0; i < addressToClients.Count; i++)
            {
                ans.Add(new AddressToClient() {Id = addressToClients[i].Id, City = addressToClients[i].City, Nighbord = addressToClients[i].Street });
            }
            return ans;
        }

        public AddressToClient GetById(int id)
        {
            Address address = addressRepo.GetById(id);
            return new AddressToClient() { City = address.City, Nighbord = address.Street };
            
        }

        public AddressToClient Update(int id, AddressToClient t,string street,string apartment)
        {
            Address address = new Address();
            address.City = t.City;
            address.Neighborhood = t.Nighbord;
            address.Street = street;
            address.Apartment = apartment;
            addressRepo.Update(id, address);
            return t;
        }
    }
}
