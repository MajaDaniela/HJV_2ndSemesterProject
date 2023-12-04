using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.Models
{
     public enum SailingType
    {
        // Describes the nature of a sailing.

        [Description("Autorisationssejlads")]
        AuthorisationSailing,
        MAS,
        [Description("Patrol")]
        Patruljesejlads,
        SAR,
        SAREX,
        [Description("Politi Maritim Kontrol")]
        PoliceMaritimeControl,
        [Description("Ska-kontrol")]
        SKAControl,
        [Description("Sommertogt")]
        SummerCruise,
        Springex,
        SURVEX,
        [Description("ØvelsesSejlads")]
        Training,
        //[Description("Forlægningssejlads til")]
        //ForlægningssejladstTil,
        //[Description("Forlægningssejlads fra")]
        //ForlægningssejladsFra,

    }
}
