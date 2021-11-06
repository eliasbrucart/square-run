using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public int score;
    public float startPosX;
    public float startPosY;
    public float endPosX;
    public float endPosY;
    public Coin actualInstance;
    [SerializeField] private int countMaxCoinInstance;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int timeToSpawnCoin;
    private int maxCoinInstance;
    private float timerToSpawnCoin;
    private bool canInstanceOneCoin;
    void Start()
    {
        timerToSpawnCoin = 0.0f;
        Player.PlayerGetCoin += RandomTimeSpawn;
        Player.PlayerGetCoin += DecreaseMaxCoinInstance;
        maxCoinInstance = 0;
        canInstanceOneCoin = true;
    }
    void Update()
    {
        if(timerToSpawnCoin <= timeToSpawnCoin)
            timerToSpawnCoin += Time.deltaTime;
        else
        {
            Spawn();
            timerToSpawnCoin = 0.0f;
        }
    }

    private void Spawn()
    {
        if (coinPrefab != null && canInstanceOneCoin)
        {
            GameObject GO = Instantiate(coinPrefab, new Vector3(startPosX, startPosY, 0.0f), transform.rotation);
            actualInstance = GO.GetComponent<Coin>();
            maxCoinInstance++;
            MaxCoinInstanceAlive();
            Debug.Log("Max coin instance: " + maxCoinInstance);
        }
    }

    private void RandomTimeSpawn()
    {
        int newTimeToSpawnCoin = Random.Range(5, 12);
        if(timeToSpawnCoin != newTimeToSpawnCoin)
            timeToSpawnCoin = newTimeToSpawnCoin;
        timerToSpawnCoin = 0.0f;
    }

    private void MaxCoinInstanceAlive()
    {
        if (maxCoinInstance == countMaxCoinInstance)
            canInstanceOneCoin = false;
    }

    private void DecreaseMaxCoinInstance()
    {
        if(maxCoinInstance > 0 && maxCoinInstance <= countMaxCoinInstance)
        {
            maxCoinInstance--;
            canInstanceOneCoin = true;
        }
    }

    private void OnDisable()
    {
        Player.PlayerGetCoin -= RandomTimeSpawn;
        Player.PlayerGetCoin -= DecreaseMaxCoinInstance;
    }
}
