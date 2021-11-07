using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxPosX;
    [SerializeField] private float minPosX;
    [SerializeField] private float posY;
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
            float horizontal = Input.GetAxis("Horizontal");
            Vector3 direction = new Vector3(horizontal, 0.0f, 0.0f);
            if(Input.GetAxis("Horizontal") > 0 && transform.position.x <= maxPosX)
                transform.position += direction * speed * Time.deltaTime;
            if(Input.GetAxis("Horizontal") < 0 && transform.position.x >= minPosX)
                transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle1") || collision.gameObject.CompareTag("Obstacle2") || collision.gameObject.CompareTag("Obstacle3") || collision.gameObject.CompareTag("Obstacle4"))
        {
            isDead = true;
            PlayerDie?.Invoke();
            Debug.Log("IsTrigger");
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            PlayerGetCoin?.Invoke();
        }
    }
}
