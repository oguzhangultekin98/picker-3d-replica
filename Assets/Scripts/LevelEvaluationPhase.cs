using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEvaluationPhase : MonoBehaviour
{
    public GameObject ballBasket;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.ChangeGameState(GameState.InControll);
            ballBasket.SetActive(true);
        }
    }
}
