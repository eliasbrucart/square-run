using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIGameplay : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text waitTimer;
    public Button leftButton;
    public Button rigthButton;
    private GameManager gm;
    void Start()
    {
        gm = GameManager.instanceGameManager;
    }

    void Update()
    {
        timerText.text = "" + gm.timer.ToString("F0");
        scoreText.text = "" + gm.score.ToString("F0");
        waitTimer.text = "" + gm.timerWaitTime.ToString("F0");
        DisbleWaitTimer();
    }

    private void DisbleWaitTimer()
    {
        if (gm.timerWaitTime >= 3.0f)
            waitTimer.gameObject.SetActive(false);
    }
}
