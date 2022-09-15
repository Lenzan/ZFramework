using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFramework
{
    public sealed class Scene : Entity
    {
        public string Name { get; set; }

        public Scene()
        {
        }

        public Scene(long id) : base(id)
        {
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            base.Dispose();
        }
    }
}
