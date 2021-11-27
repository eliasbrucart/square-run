using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxPosX;
    [SerializeField] private float minPosX;
    [SerializeField] private float posY;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color color;
    [SerializeField] [Range(0.1f, 1.0f)] private float colorLerpTime;
    public bool isDead;
    public bool canMove;
    static public event Action PlayerDie;
    static public event Action PlayerGetCoin;
    void Start()
    {
        isDead = false;
        canMove = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        LongClickButton.MovePlayerDirection += MovePlayer;
    }

    private void OnDisable()
    {
        LongClickButton.MovePlayerDirection -= MovePlayer;
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        Move();
#endif
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

    public void MovePlayer(string dir)
    {
        if (canMove)
        {
            Vector3 direction = Vector3.right;
            if(dir == "right")
            {
                if(transform.position.x <= maxPosX)
                    transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                if (transform.position.x >= minPosX)
                    transform.position -= direction * speed * Time.deltaTime;
            }
        }
    }

    public void MovePlayerLeft()
    {
        if (canMove)
        {
            Vector3 direction = Vector3.right;
            if (transform.position.x >= minPosX)
                transform.position -= direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle1") || collision.gameObject.CompareTag("Obstacle2") || collision.gameObject.CompareTag("Obstacle3") || collision.gameObject.CompareTag("Obstacle4"))
        {
            isDead = true;
            //PlayerDie?.Invoke();
            StartCoroutine(WaitForPlayerDie());
#if UNITY_ANDROID
            Handheld.Vibrate();
#endif
            Debug.Log("IsTrigger");
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            AudioManager.instanceAudioManager.sfxSound.Play();
            PlayerGetCoin?.Invoke();
        }
    }

    private IEnumerator WaitForPlayerDie()
    {
        yield return new WaitForSeconds(0.7f);
        PlayerDie?.Invoke();
        yield return null;
    }

    public void ChangeColor(Color changingColor)
    {
        spriteRenderer.material.color = Color.Lerp(color, changingColor, colorLerpTime);
    }
}
