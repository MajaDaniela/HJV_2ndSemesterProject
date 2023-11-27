﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.Models
{
     public enum Role
    {
        [Description("Navigatør")]
        Navigator,
        [Description("Vagtchef")]
        OfficerOfTheWatch,
        [Description("Fartøjsfører")]
        VesselMaster,
        [Description("Motorpasser")]
        EngineFitter,
        [Description("Assisterende Motorpasser")]
        AssistantEngineFitter



    }
}