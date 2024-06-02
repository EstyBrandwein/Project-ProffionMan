using Bl.BlObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi
{
    public interface IRepoAddress
    {
        public AddressToClient Add(AddressToClient t, string street, int apartment);
        public AddressToClient Update(int id, AddressToClient t, string street, int apartment);
        List<AddressToClient> GetAll();
        AddressToClient GetById(int id);
        AddressToClient Delete(int id);
    }
}
