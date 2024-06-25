using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StateManagementDemo.Models
{
    public static class TempDataExtensions
    {
        public static void Put<T>(this ITempDataDictionary tempdata,string key, T value)
        {
            tempdata[key]= Newtonsoft.Json.JsonConvert.SerializeObject(value);
        }
        public static T Get<T>(this ITempDataDictionary tempdata, string key)
        {
            tempdata.TryGetValue(key, out var o);
            return o== null ? default(T) :JsonConvert.DeserializeObject<T>((string)o);

        }
    }
}
