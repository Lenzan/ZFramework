
namespace ZFramework
{
    public static partial class Log
    {
        /// <summary>
        /// 框架日志辅助器接口
        /// </summary>
        public interface ILogHelper
        {
            void Log(LogLevel level, object message);
        }
    }
}
