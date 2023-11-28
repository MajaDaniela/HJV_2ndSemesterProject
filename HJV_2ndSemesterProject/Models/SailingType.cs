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
        Autorisationssejlads,
        MAS,
        Patruljesejlads,
        SAR,
        SAREX,
        PolitiMaritimKontrol,
        SKA_Kontrol,
        Sommertogt,
        Springex,
        SURVEX,
        Øvelsesejlads,
        [Description("Forlægningssejlads til")]
        ForlægningssejladstTil,
        [Description("Forlægningssejlads fra")]
        ForlægningssejladsFra,

    }
}
