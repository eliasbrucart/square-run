using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    public TMP_Text maxTime;
    private GameManager gm;
    void Start()
    {
        gm = GameManager.instanceGameManager;
    }

    void Update()
    {
        maxTime.text = "Max time " + gm.timer.ToString("F0");
    }
}
