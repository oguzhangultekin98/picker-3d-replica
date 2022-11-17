using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateChangeTrigger : MonoBehaviour
{
    [SerializeField] GameState targetGameState;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PickerMovementController>() != null)
            GameManager.instance.ChangeGameState(targetGameState);
    }
}
