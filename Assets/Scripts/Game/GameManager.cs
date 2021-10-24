﻿using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer { get; set; }
    public int score { get; set; }
    [SerializeField] private float waitTime;
    [SerializeField] private int coinValue;
    [SerializeField] private Player player;
    [SerializeField] private Coin coin;
    [SerializeField] private List<Obstacles> obstaclesInMap = new List<Obstacles>();
    private ScenesManager sc;
    private bool startGame;
    private float timerWaitTime;

    static public GameManager instanceGameManager;
    static public GameManager Instance { get { return instanceGameManager; } }

    private void Awake()
    {
        if (instanceGameManager != null && instanceGameManager != this)
            Destroy(this.gameObject);
        else
            instanceGameManager = this;
    }

    void Start()
    {
        sc = ScenesManager.instanceScenesManager;
        Player.PlayerDie += CheckGameOver;
        Player.PlayerGetCoin += IncreasePoints;
        timer = 0.0f;
        timerWaitTime = 0.0f;
        startGame = false;
        SquareLoggerImpl.SendLog("Holi");
    }

    void Update()
    {
        if(timerWaitTime <= waitTime)
        {
            timerWaitTime += Time.deltaTime;
        }
        else
        {
            timerWaitTime = 0.0f;
            startGame = true;
            player.canMove = true;
            for (int i = 0; i < obstaclesInMap.Count; i++)
                obstaclesInMap[i].canMove = true;
        }
        if (startGame)
            timer += Time.deltaTime;
        Debug.Log(timerWaitTime);
        CheckGameOver();
    }

    private void IncreasePoints()
    {
        score += coinValue;
    }

    private void CheckGameOver()
    {
        if(player.isDead)
            sc.ChangeScene("GameOver");
    }

    private void OnDisable()
    {
        Player.PlayerDie -= CheckGameOver;
        Player.PlayerGetCoin -= IncreasePoints;
    }
}
