using SiteBuilder.DataEntity.Models;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SiteBuilder.Core.Helpers
{
    public static class HttpContextExtensions
    {
        //public static Tenant GetUser(this HttpContextBase context)
        //{
        //    return (Tenant)context.Items["Tenant"];
        //}

        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
