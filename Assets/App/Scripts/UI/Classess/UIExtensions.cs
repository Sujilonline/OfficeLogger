using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace OfficeLogger
{
    public static class UIExtensions
    {
        /// <summary>
        /// Sets the value for the particular windows or popups
        /// </summary>
        /// <returns>The value.</returns>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public static KeyValuePair<string,object> SetValue(this string key, object value)
        {
            return new KeyValuePair<string, object>(key, value);
        }

        public static void ForEach <T>(this IEnumerable<T> items, System.Action<T> action)
        {
            foreach (var item in items)
            {
                action.Invoke(item);
            }
        }
    }
}

