using System;
using System.Collections.Generic;

namespace Dal.DalObject;

public partial class Reference
{
    public int Id { get; set; }

    public int Rating { get; set; }

    public string Phon { get; set; }

    public string Eamail { get; set; }

    public string Describe { get; set; }

    public int IdProfessionals { get; set; }

    public virtual ProfessionalsMan IdProfessionalsNavigation { get; set; }
}
