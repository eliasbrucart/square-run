﻿using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinSpawner coinSpawner;
    [SerializeField] private float speed;
    void Start()
    {
        coinSpawner = FindObjectOfType<CoinSpawner>();
        Player.PlayerGetCoin += DestroyActualInstance;
    }

    void Update()
    {
        Move();
        Reposition();
    }

    private void Move()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void Reposition()
    {
        if (transform.position.y <= coinSpawner.endPosY)
            transform.position = new Vector3(coinSpawner.startPosX, coinSpawner.startPosY, 0.0f);
    }

    private void DestroyActualInstance()
    {
        Destroy(this.gameObject);
    }

    private void OnDisable()
    {
        Player.PlayerGetCoin -= DestroyActualInstance;
    }
}
