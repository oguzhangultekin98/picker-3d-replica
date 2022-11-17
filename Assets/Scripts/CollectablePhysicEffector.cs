using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePhysicEffector : MonoBehaviour
{
    private List<CollectableBase> collectables = new List<CollectableBase>();

    public void PushCollectables()
    {
        for (int i = 0; i < collectables.Count; i++)
        {
            collectables[i].Push();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        var collectable = other.GetComponent<CollectableBase>();
        if (collectable != null)
        {
            collectables.Add(collectable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var collectable = other.GetComponent<CollectableBase>();
        if (collectable != null)
        {
            collectables.Remove(collectable);
        }
    }

}
