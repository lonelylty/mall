using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Heals.CSX.Mall.Web
{
    public class EnumDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            Dictionary<string, Type> dict = GetAllEnum();
            foreach (var item in swaggerDoc.Components.Schemas)
            {
                var property = item.Value;
                var typeName = item.Key;
                Type itemType = null;
                if (property.Enum != null && property.Enum.Count > 0)
                {
                    if (dict.ContainsKey(typeName))
                    {
                        itemType = dict[typeName];
                        List<OpenApiInteger> list = new List<OpenApiInteger>();
                        foreach (var val in property.Enum)
                        {
                            list.Add((OpenApiInteger)val);
                        }
                        property.Description += DescribeEnum(itemType, list);
                    }
                }
            }
            static Dictionary<string, Type> GetAllEnum()
            {
                Assembly ass = Assembly.Load("Heals.CSX.Mall.Domain.Shared");
                Type[] types = ass.GetTypes();
                Dictionary<string, Type> dict = new Dictionary<string, Type>();
                foreach (Type item in types)
                {
                    if (item.IsEnum)
                    {
                        dict.Add(item.FullName, item);
                    }
                }
                return dict;
            }
            static string DescribeEnum(Type type, List<OpenApiInteger> enums)
            {
                if (type == null)
                {
                    return string.Empty;
                }
                var enumDescriptions = new List<string>();
                foreach (var item in enums)
                {
                    var value = Enum.Parse(type, item.Value.ToString());
                    var desc = GetDescription(type, value);
                    if (string.IsNullOrEmpty(desc))
                    {
                        enumDescriptions.Add($"{item.Value}:{Enum.GetName(type, value)}; ");
                    }
                    else
                    {
                        enumDescriptions.Add($"{item.Value}:{Enum.GetName(type, value)}, {desc}; ");
                    }
                }
                return $"<br/>{Environment.NewLine}{string.Join("<br/>" + Environment.NewLine, enumDescriptions)}";
            }
            static string GetDescription(Type t, object value)
            {
                foreach (MemberInfo mInfo in t.GetMembers())
                {
                    if (mInfo.Name == t.GetEnumName(value))
                    {
                        foreach (Attribute attr in Attribute.GetCustomAttributes(mInfo))
                        {
                            if (attr.GetType() == typeof(DescriptionAttribute))
                            {
                                return ((DescriptionAttribute)attr).Description;
                            }
                        }
                    }
                }
                return string.Empty;
            }
        }
    }
}
