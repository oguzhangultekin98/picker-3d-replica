using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerMovementController : MonoBehaviour
{
    private bool isActive;
    [SerializeField] private float inputOverflow;
    [SerializeField] private Camera followerCamera;

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
    }

    private Vector3 firstClickMouseWorldPos = Vector3.zero;
    private void LateUpdate()
    {
        if (!isActive)
            return;

        MoveTo(Vector3.forward, 5.5f);
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 20f;
        if (Input.GetMouseButtonDown(0))
        {
            firstClickMouseWorldPos = followerCamera.ScreenToWorldPoint(mousePos);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 lastClickMouseWorldPos = followerCamera.ScreenToWorldPoint(mousePos);

            float diffrenceBetweenMousePosX = firstClickMouseWorldPos.x - lastClickMouseWorldPos.x;
            
            if (Mathf.Abs(diffrenceBetweenMousePosX) < inputOverflow)
                return;
            if (diffrenceBetweenMousePosX < 0f)
            {
                MoveTo(Vector3.right, 3.5f);
            }
            else
            {
                MoveTo(Vector3.left, 3.5f);
            }
        }
    }

    public void MoveTo(Vector3 direction, float speedMultiplier)
    {
        direction.Normalize();
        direction *= (speedMultiplier * Time.deltaTime);

        transform.Translate(direction);
    }

    public void OnGameStateChangeEvent(int gameState)
    {
        GameState changedGameState = (GameState)gameState;
        if (changedGameState == GameState.InGame)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }
}
