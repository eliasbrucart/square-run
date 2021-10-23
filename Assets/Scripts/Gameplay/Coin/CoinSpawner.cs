using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public int score;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float startPosX;
    [SerializeField] private float startPosY;
    [SerializeField] private int timeToSpawnCoin;
    private float timerToSpawnCoin;
    void Start()
    {
        timerToSpawnCoin = 0.0f;
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
}
