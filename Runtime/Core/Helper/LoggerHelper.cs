using System;
using UnityEngine;

namespace ZFramework
{
    public class LoggerHelper : Log.ILogHelper
    {
        public void Log(LogLevel level, object message)
        {
            switch (level)
            {
#if UNITY_EDITOR
                case LogLevel.Debug:
                    Debug.Log(string.Format("<color=#888888>{0}</color>", message.ToString()));
                    break;

                case LogLevel.Info:
                    Debug.Log(string.Format("<color=black>{0}</color>", message.ToString()));
                    break;

                case LogLevel.Warning:
                    Debug.LogWarning(string.Format("<color=yellow>{0}</color>", message.ToString()));
                    break;

                case LogLevel.Error:
                    Debug.LogError(string.Format("<color=red>{0}</color>", message.ToString()));
                    break;
#endif

                default:
                    throw new Exception(message.ToString());
            }
        }
    }
}
