using System.Collections.Generic;

namespace ZFramework
{
    /// <summary>
    /// 管理所有UI
    /// </summary>
    public class UIComponent : Component
    {
        //public GameObject Camera;

        public Dictionary<string, UI> uis = new Dictionary<string, UI>();

        public void Add(UI ui)
        {
            this.uis.Add(ui.Name, ui);
            ui.Parent = this;
        }

        public void Remove(string name)
        {
            if (!this.uis.TryGetValue(name, out UI ui))
            {
                return;
            }
            this.uis.Remove(name);
            ui.Dispose();
        }

        public UI Get(string name)
        {
            UI ui = null;
            this.uis.TryGetValue(name, out ui);
            return ui;
        }
    }
}
