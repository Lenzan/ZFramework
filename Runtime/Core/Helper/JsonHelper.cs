using Newtonsoft.Json;
using System.ComponentModel;

namespace ZFramework
{
    public static class JsonHelper
    {
        public static string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T FromJson<T>(string str)
        {
            T t = JsonConvert.DeserializeObject<T>(str);
            
            ISupportInitialize iSupportInitialize = t as ISupportInitialize;
            if (iSupportInitialize == null)
            {
                return t;
            }
            iSupportInitialize.EndInit();
            return t;
        }

        public static T Clone<T>(T t)
        {
            return FromJson<T>(ToJson(t));
        }
    }
}
