using System;
using System.Collections.Generic;

namespace Dal.DalObject;

public partial class Profession
{
    public int Id { get; set; }

    public string Type { get; set; }

    public virtual ICollection<ProfessionalsMan> ProfessionalsMen { get; set; } = new List<ProfessionalsMan>();
}
