using System;
using System.IO;
using UnityEngine;

namespace ZFramework.Config.Runtime
{
    public static class ConfigHelper
    {
        
        public static string ConfigPath => Application.streamingAssetsPath + "/Config/";
        
        public static string GetText(string key)
        {
            try
            {
                string configStr = File.ReadAllText(ConfigPath + key + ".json");
                return configStr;
            }
            catch (Exception e)
            {
                throw new Exception($"load config file fail, key: {key}", e);
            }
        }


        public static T ToObject<T>(string str)
        {
            return JsonHelper.FromJson<T>(str);
        }
    }
}
