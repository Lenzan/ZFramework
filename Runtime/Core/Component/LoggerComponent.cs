namespace ZFramework
{
    [ObjectSystem]
    public class LoggerComponentAwakeSystem : AwakeSystem<LoggerComponent, Log.ILogHelper>
    {
        public override void Awake(LoggerComponent self, Log.ILogHelper helper)
        {
            self.Awake(helper);
        }
    }

    public class LoggerComponent : Component
    {
        public void Awake(Log.ILogHelper logHelper)
        {
            Log.SetLogHelper(logHelper);

            Log.Info("日志系统初始化。");
        }
    }
}
