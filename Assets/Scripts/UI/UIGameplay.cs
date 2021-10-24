using UnityEngine;
using TMPro;

public class UIGameplay : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text scoreText;
    private GameManager gm;
    void Start()
    {
        gm = GameManager.instanceGameManager;
    }

    void Update()
    {
        timerText.text = "" + gm.timer.ToString("F0");
        scoreText.text = "" + gm.score.ToString("F0");
    }
}
