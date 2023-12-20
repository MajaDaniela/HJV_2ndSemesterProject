using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace HJV_2ndSemesterProject
{
    //An extension that allows for databinding to an enumeration type in XAML.
    public class EnumBindingSourceExtension : MarkupExtension
    {
        public Type EnumType { get; private set; }

        public EnumBindingSourceExtension(Type enumType) 
        {
            if (enumType is null || !enumType.IsEnum)
                throw new Exception("EnumType must not be null and of type Enum");
            EnumType = enumType;
        }
       // If it is an enum it uses the GetDescription method to return an array of userfriendly strings to be displayed in the UI.
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            List<string> descriptions = new List<string>();
              Array values = Enum.GetValues(EnumType);
            foreach(Enum value in values)
            {
                descriptions.Add(value.GetDescription());
            }
            return descriptions.ToArray();
        }
    }
}
