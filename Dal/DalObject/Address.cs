using System;
using System.Collections.Generic;

namespace Dal.DalObject;

public partial class Address
{
    public int Id { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public string Apartment { get; set; }

    public string Neighborhood { get; set; }

    public virtual ICollection<ProfessionalsMan> ProfessionalsMen { get; set; } = new List<ProfessionalsMan>();
}
