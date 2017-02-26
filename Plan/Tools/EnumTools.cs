namespace Plan.Tools
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;

    public static class EnumTools
    {
        public static string ToDisplayString(this Enum value)
        {
            var @enum = (Enum)value;
            var description = @enum.ToString();

            var attrib = GetAttribute<DisplayAttribute>(@enum);
            if (attrib != null)
            {
                description = attrib.Name;
            }

            return description;
        }

        private static T GetAttribute<T>(Enum enumValue) where T : Attribute
        {
            return enumValue.GetType().GetTypeInfo()
                .GetDeclaredField(enumValue.ToString())
                .GetCustomAttribute<T>();
        }
    }
}
