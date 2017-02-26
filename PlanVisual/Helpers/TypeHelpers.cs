namespace PlanVisual.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    public static class TypeHelpers
    {
        public static Type ItemType<T>(this ICollection<T> someList)
        {
            return typeof(T);
        }

        public static string PropertyName<T, TP>(Expression<Func<T, TP>> expression) where T : class
        {
            var memberExpression = (MemberExpression)expression.Body;
            return memberExpression.Member.Name;
        }

        public static bool HasProperty(this object objectToCheck, string methodName)
        {
            var type = objectToCheck.GetType();
            return type.GetProperty(methodName) != null;
        }

        public static bool HasProperty(this Type objectType, string propertyName)
        {
            return objectType.GetProperty(propertyName) != null;
        }

        public static object PropertyValue(this object obj, string propertyName)
        {
            if (obj.HasProperty(propertyName))
            {
                return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
            }
            else
            {
                throw new ArgumentException($"Object don't have {propertyName} property.");
            }
        }
    }
}
