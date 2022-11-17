using System.Collections;
using System.Collections.Generic;
using ScriptableEvents.Events;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameState state;
    public GameState State => state;

    [SerializeField] private IntScriptableEvent intScriptableEvent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        state = GameState.PreStart;
    }

    public void ChangeGameState(GameState targetState)
    {
        state = targetState;
        intScriptableEvent.Raise((int)targetState);
    }
}
