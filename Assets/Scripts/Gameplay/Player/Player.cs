using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxPosX;
    [SerializeField] private float minPosX;
    public bool isDead;
    public bool canMove;
    static public event Action PlayerDie;
    static public event Action PlayerGetCoin;
    void Start()
    {
        isDead = false;
        canMove = false;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (canMove)
        {
            if (transform.position.x >= 2.68f)
                transform.position = new Vector3(maxPosX, 0.0f, 0.0f);
            if (transform.position.x <= -2.68f)
                transform.position = new Vector3(minPosX, 0.0f, 0.0f);
            float horizontal = Input.GetAxis("Horizontal");
            Vector3 direction = new Vector3(horizontal, 0.0f, 0.0f);
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle1") || collision.gameObject.CompareTag("Obstacle2") || collision.gameObject.CompareTag("Obstacle3"))
        {
            isDead = true;
            PlayerDie?.Invoke();
            Debug.Log("IsTrigger");
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            PlayerGetCoin?.Invoke();
        }
    }
}
