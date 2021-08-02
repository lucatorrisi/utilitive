using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilitive.Internal;

namespace Utilitive.Object
{
    public static class ObjectUtility
    {
        /// <summary>
        /// Securely takes the value of a property given its name. Default value if the property is not found
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">Source object</param>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        public static T TryGetPropertyValue<T>(this object obj, string propertyName)
        {
            try
            {
                return obj is T ? (T)obj.GetType().GetProperty(propertyName)
                    .GetValue(obj, null) : default;
            }
            catch (Exception) { return default; }
        }

        /// <summary>
        /// Safely takes the value of all properties that are castable to the given class
        /// </summary>
        /// <param name="obj">Source object</param>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        public static IEnumerable<T> TryGetPropertyValuesByClass<T>(this object obj, string[] propertyNames)
        {
            if (obj is null || !propertyNames.Any())
                return default;

            return obj.GetType().GetProperties()
                .Where(p => propertyNames.Contains(p.Name))
                .ToCastablePropertieInfosArray<T>(obj)
                .Select(p => (T)p.GetValue(obj, null))
                .ToArray();
        }
    }
}
