using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CubeSolver.Utils
{
    public static class ExtensionMethods
    {
        public static string GetDescription(this Enum value)
        {
            // standard way to get at the decription attribute on an enum
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
                    if (attr != null)
                        return attr.Description;
                }
            }
            return "";
        }
    }
}
