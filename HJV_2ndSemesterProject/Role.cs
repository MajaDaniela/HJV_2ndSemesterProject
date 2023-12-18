using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject
{
    public enum Role
    {
        //A volunteer (with relevant training) may have a specialised role aboard the vessel.
       // The enum values are English while the descriptions are Danish.

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
