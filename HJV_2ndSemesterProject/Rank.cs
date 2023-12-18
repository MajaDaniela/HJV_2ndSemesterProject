using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject
{
    public enum Rank
    {
        //This is an enum for the ranks of volunteers. The enum values are English while the descriptions are Danish.

        [Description("Menig")]
        Private,
        [Description("Korporal")]
        Corporal,
        [Description("Sergent")]
        Sergeant
    }
}
