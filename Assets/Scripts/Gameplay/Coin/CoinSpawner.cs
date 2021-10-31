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
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int timeToSpawnCoin;
    private float timerToSpawnCoin;
    void Start()
    {
        timerToSpawnCoin = 0.0f;
        Player.PlayerGetCoin += RandomTimeSpawn;
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
        if (coinPrefab != null)
            Instantiate(coinPrefab, new Vector3(startPosX, startPosY, 0.0f), transform.rotation);
    }

    private void RandomTimeSpawn()
    {
        int newTimeToSpawnCoin = Random.Range(5, 12);
        if(timeToSpawnCoin != newTimeToSpawnCoin)
            timeToSpawnCoin = newTimeToSpawnCoin;
        timerToSpawnCoin = 0.0f;
    }

    private void OnDisable()
    {
        Player.PlayerGetCoin -= RandomTimeSpawn;
    }
}
