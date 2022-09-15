using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ZFramework
{
    /// <summary>
    ///应用程序外部资源路径存放路径
    /// </summary>
    public static class PathHelper
    {

        /// <summary>
        /// 应用程序内部资源路径存放路径
        /// </summary>
        public static string AppResPath
        {
            get
            {
                return Application.streamingAssetsPath;
            }
        }
        
        public const string ElementLibrary = "Assets/Elements";
        
        public const string EntityElementPath = "Assets/Elements/Entities";
        
        public const string WorldElementPath = "Assets/Elements/Worlds";
        
        public const string SceneElementPath = "Assets/Elements/Scenes";
        
        public const string TaskElementPath = "Assets/Elements/Tasks";
        
        public const string TaskStepElementPath = "Assets/Elements/TaskSteps";
        
        public const string ToolElementPath = "Assets/Elements/Tools";

        public const string ShowElementRootName = "Show";

    }
}
