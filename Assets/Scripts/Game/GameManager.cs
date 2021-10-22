using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    private ScenesManager sc;
    void Start()
    {
        sc = ScenesManager.instanceScenesManager;
        Player.PlayerDie += CheckGameOver;
    }

    void Update()
    {
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if(player.isDead)
            sc.ChangeScene("GameOver");
    }

    private void OnDisable()
    {
        Player.PlayerDie -= CheckGameOver;
    }
}
