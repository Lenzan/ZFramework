using System;

namespace ZFramework
{
    [AttributeUsage(AttributeTargets.Class)]
    public class UIFactoryAttribute : BaseAttribute
    {
        public string Type { get; }

        public UIFactoryAttribute(string type)
        {
            this.Type = type;
        }
    }
}
