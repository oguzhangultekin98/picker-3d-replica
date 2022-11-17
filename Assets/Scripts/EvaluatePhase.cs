using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class EvaluatePhase : MonoBehaviour
{
    [SerializeField]private int targetBallCount;
    [SerializeField] private TextMeshProUGUI ballcountText;
    [SerializeField] private GameObject Bridge;
    [SerializeField] private GameObject RightGate;
    [SerializeField] private GameObject LeftGate;
    [SerializeField] private GameObject Red;
    [SerializeField] private GameObject Green;
    [SerializeField] private float GateAngle;
    [SerializeField] private float WaitTime;

    private int ballCounter = 0;

    private void OnEnable()
    {
        StartCoroutine(Wait());
        ballcountText.text = (ballCounter + " / " + targetBallCount).ToString();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(WaitTime / 2);
        bool isLevelSuccsesfull = EvaluateLevel();
        if (isLevelSuccsesfull)
        {
            RightGate.transform.DORotate(new Vector3(0f, 0f, -(GateAngle)), 0.5f);
            LeftGate.transform.DORotate(new Vector3(0f, 0f, (GateAngle)), 0.5f);
            Bridge.transform.DOMoveY(1, 0.5f,true);
            Red.SetActive(false);
            Green.SetActive(true);
            Bridge.SetActive(true);

            yield return new WaitForSeconds(WaitTime / 2);
            GameManager.instance.ChangeGameState(GameState.InGame);
            gameObject.SetActive(false);
        }
        else
        {
            GameManager.instance.ChangeGameState(GameState.GameOver);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CollectableBase>() != null)
        {
            ballCounter++;
            ballcountText.text = (ballCounter + " / " + targetBallCount.ToString());
        }
    }

    private bool EvaluateLevel()
    {
        return ballCounter >= targetBallCount;
    }
}
