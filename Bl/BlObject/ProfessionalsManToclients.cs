using Dal.DalObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bl.BlObject
{
    public class ProfessionalsManToclients
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ProfessionToClient profession { get; set; }

        public int? HourlyPrice { get; set; }

        public AddressToClient Address { get; set; }
        public string WhatsApp { get; set; }

        public string Email { get; set; }

        public string Phon { get; set; }
    }
}
