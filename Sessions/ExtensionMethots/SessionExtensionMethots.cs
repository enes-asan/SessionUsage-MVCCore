using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sessions.ExtensionMethots
{
    public static class SessionExtensionMethots
    {
        public static void SetObject(this ISession session,string key,object value)
        {
            var stringValue = JsonConvert.SerializeObject(value);
            session.SetString(key, stringValue);
        }
        public static T GetObject<T>(this ISession session,string key) where T:class
        {
            var stringValue = session.GetString(key);
            if (string.IsNullOrEmpty(stringValue))
            {
                return null;
            }
            T objectValue = JsonConvert.DeserializeObject<T>(stringValue);
            return objectValue;
        }
    }
}
