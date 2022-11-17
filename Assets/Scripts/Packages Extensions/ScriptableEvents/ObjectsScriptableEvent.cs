using System.Collections.Generic;
using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ObjectsScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameCustom + "/Objects Scriptable Event",
        order = ScriptableEventConstants.MenuOrderCustom + 0
    )]
    public class ObjectsScriptableEvent : BaseScriptableEvent<List<System.Object>> { }
}