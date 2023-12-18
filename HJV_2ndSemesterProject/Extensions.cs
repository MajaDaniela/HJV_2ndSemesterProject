using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject
{
    public static class Extensions
    {
        /*A Method that returns the Description attribute (if available) for a given enum-value. Adding Descriptions
         in this way allows for easy conversion to reader friendly strings as well as translation to Danish.
         source https://stackoverflow.com/questions/2650080/how-to-get-c-sharp-enum-description-from-value */

        public static string GetDescription<T>(this T source) where T : Enum
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }
}
