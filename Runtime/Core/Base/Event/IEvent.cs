using System;
using Cysharp.Threading.Tasks;

namespace ZFramework
{
    public interface IEvent
    {
        Type GetEventType();
    }

    public abstract class AEvent<A> : IEvent where A: struct
    {
        public Type GetEventType()
        {
            return typeof (A);
        }

        protected abstract UniTask Run( A a);

        public async UniTask Handle( A a)
        {
            try
            {
                await Run(a);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
   
}
