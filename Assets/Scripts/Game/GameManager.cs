﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    public float timer { get; set; }
    private ScenesManager sc;
    void Start()
    {
        sc = ScenesManager.instanceScenesManager;
        Player.PlayerDie += CheckGameOver;
    }

    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
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
