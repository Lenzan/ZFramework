using MongoDB.Bson.Serialization.Attributes;
using System;
using UnityEngine;

namespace ZFramework
{
    [BsonIgnoreExtraElements]
    public abstract class Component : Object , IDisposable
    {
        [BsonIgnore]
        public long InstanceId { get; set; }

        public static GameObject Global { get; } = GameObject.Find("Global");

        [BsonIgnore]
        public GameObject GameObject { get; protected set; }

        [BsonIgnore][HideInInspector]
        protected bool isFromPool;

        [BsonIgnore][HideInInspector]
        public bool IsFromPool
        {
            get
            {
                return isFromPool;
            }
            set
            {
                isFromPool = value;
                if (!this.isFromPool) return;
                if(InstanceId == 0)
                    InstanceId = IdGenerater.GenerateInstanceId();
            }
        }

        [BsonIgnore]
        public bool IsDisposed
        {
            get
            {
                return this.InstanceId == 0;
            }
        }

        private Component parent;

        [BsonIgnore]
        public Component Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                parent = value;
                if(parent == null)
                {
                    this.GameObject.transform.parent = Global.transform;
                    return;
                }
                if(this.GameObject != null && this.parent.GameObject != null)
                {
                    //this.GameObject.transform.parent = parent.GameObject.transform;
                    GameObject.transform.SetParent(parent.GameObject.transform);
                }
            }
        }

      

        public T GetParent<T>() where T : Component
        {
            return this.Parent as T;
        }

        [BsonIgnore]
        public Entity Entity
        {
            get
            {
                return this.Parent as Entity;
            }
        }

        protected Component()
        {
            this.InstanceId = IdGenerater.GenerateInstanceId();
            if(!this.GetType().IsDefined(typeof(HideInHierarchy) , true))
            {
                this.GameObject = new GameObject();
                this.GameObject.name = this.GetType().Name;
                //this.GameObject.layer = LayerNames.GetLayerInt(LayerNames.HIDDEN);
                this.GameObject.transform.parent = Global.transform;
                this.GameObject.AddComponent<ComponentView>().Component = this;
            }
        }

        public virtual void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            // 触发Destroy事件
            Game.EventSystem.Destroy(this);

            Game.EventSystem.Remove(this.InstanceId);

            this.InstanceId = 0;

            if (this.IsFromPool)
            {
                Game.ObjectPool.Recycle(this);
            }
            else
            {
                if(this.GameObject != null)
                {
                    UnityEngine.Object.Destroy(this.GameObject);
                }
            }
        }

        public override void EndInit()
        {
            Game.EventSystem.Deserialize(this);
        }

        public override string ToString()
        {
            return MongoHelper.ToJson(this);
        }
    }
}
