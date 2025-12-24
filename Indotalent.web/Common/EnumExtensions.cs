using System.ComponentModel;
using System;
using System.Linq;

namespace Indotalent.Web.Common
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(Enum value)
        {
   
                var field = value.GetType().GetField(value.ToString());
                if (field != null)
                {
                    var attr = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
                return value.ToString(); // Fallback to the enum name
            }
        }

    }


