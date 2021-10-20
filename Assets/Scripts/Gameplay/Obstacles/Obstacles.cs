using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxPosY;
    [SerializeField] private float minPosY;
    void Start()
    {
        
    }

    void Update()
    {
        Move();
        UpdatePosition();
    }

    private void Move()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void UpdatePosition()
    {
        int random = Random.Range(1, 3);
        if (transform.position.y <= -7.81f)
        {
            float posX = 1;
            Debug.Log(random);
            switch (random)
            {
                case 1:
                    posX = 2.694f;
                    break;
                case 2:
                    posX = -2.679f;
                    break;
                default:
                    break;
            }
            transform.position = new Vector3(posX, maxPosY, 0.0f);
        }
    }
}
