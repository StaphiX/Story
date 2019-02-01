using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnityExtentions
{
    public static class ObjectExtensions
    {
        public static string ToStringValues(this object obj)
        {
            StringBuilder sb = new StringBuilder();
            if (obj == null)
            {
                return "NULL";
            }

            //sb.AppendLine("Hash: ");
            //sb.AppendLine(obj.GetHashCode().ToString());
            //sb.AppendLine("Type: ");
            //sb.AppendLine(obj.GetType().ToString());

            var props = GetProperties(obj);

            foreach (var prop in props)
            {
                sb.AppendLine(prop.Key + " : " + prop.Value);
            }

            return sb.ToString();
        }

        private static Dictionary<string, string> GetProperties(object obj)
        {
            var props = new Dictionary<string, string>();
            if (obj == null)
                return props;

            var bindingFlags = BindingFlags.Instance |
                   BindingFlags.NonPublic |
                   BindingFlags.Public | BindingFlags.DeclaredOnly;

            var fieldNames = obj.GetType().GetFields(bindingFlags)
                                        .Select(field => field.Name)
                                        .ToList();

            foreach (var name in fieldNames)
            {
                try
                {
                    FieldInfo fi = obj.GetType().GetField(name, bindingFlags);
                    object fieldObj = fi.GetValue(obj);
                    props.Add(name, fieldObj.ToString());
                }
                catch(Exception e)
                {
                    props.Add(name, e.Message);
                }
            }

            return props;
        }
    }
}
