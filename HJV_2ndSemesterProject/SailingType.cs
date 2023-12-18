using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject
{
    public enum SailingType
    {
        //This is an enumeration for the different types of sailings. The enum values are English while the descriptions are Danish.

        [Description("Autorisationssejlads")]
        AuthorisationSailing,
        MAS,
        [Description("Patruljesejlads")]
        Partole,
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
        [Description("Øvelsessejlads")]
        Training,

    }
}
