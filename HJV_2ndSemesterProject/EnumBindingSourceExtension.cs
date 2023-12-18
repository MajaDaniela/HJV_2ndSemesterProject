using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;


namespace HJV_2ndSemesterProject
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        public Type EnumType { get; private set; }

        public EnumBindingSourceExtension(Type enumType) 
        {

            if (enumType is null || !enumType.IsEnum)
                throw new Exception("EnumType must not be null and of type Enum");
            EnumType = enumType;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            List<string> descriptions = new List<string>();
            //return Enum.GetValues(EnumType);
              Array values = Enum.GetValues(EnumType);
            foreach(Enum value in values)
            {
                descriptions.Add(value.GetDescription());
            }
            return descriptions.ToArray();
        }


    }
}
