using UnityEngine;
using TMPro;

public class UIGameplay : MonoBehaviour
{
    public TMP_Text timerText;
    private GameManager gm;
    void Start()
    {
        gm = GameManager.instanceGameManager;
    }

    void Update()
    {
        timerText.text = "" + gm.timer.ToString("F0");
    }
}
