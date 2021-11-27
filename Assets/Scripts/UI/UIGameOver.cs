using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    public TMP_Text maxTime;
    public TMP_Text maxScore;
    private GameManager gm;
    void Start()
    {
        gm = GameManager.instanceGameManager;
        SquareLoggerImpl.GetInstance().SaveMaxScore(gm.score);
    }

    void Update()
    {
        maxTime.text = "Max time " + gm.timer.ToString("F0");
        maxScore.text = "Max score: " + gm.score.ToString("F0");
    }
}
