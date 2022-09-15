using System;
using UnityEngine;

namespace ZFramework
{
    [Serializable]
    public class ComponentView : MonoBehaviour
    {
        
        public object Component { get; set; }
    }
}