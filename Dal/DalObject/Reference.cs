﻿using System;
using System.Collections.Generic;

namespace Dal.DalObject;

public partial class Reference
{
    public int Id { get; set; }

    public int Rating { get; set; }

    public string Phon { get; set; }

    public string Email { get; set; }

    public string Describe { get; set; }

    public int IdProfessionals { get; set; }

    public string Name { get; set; }

    public virtual ProfessionalsMan IdProfessionalsNavigation { get; set; }
}
