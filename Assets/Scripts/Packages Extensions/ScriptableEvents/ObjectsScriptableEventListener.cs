using System.Collections.Generic;
using UnityEngine;

namespace ScriptableEvents.Events
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameCustom + "/Objects Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderCustom + 0
    )]
    public class ObjectsScriptableEventListener : BaseScriptableEventListener<List<System.Object>>{}
}