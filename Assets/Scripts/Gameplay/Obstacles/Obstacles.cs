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
                    if(gameObject.tag == "Obstacle1")
                        posX = 2.694f;
                    else if (gameObject.tag == "Obstacle2")
                        posX = 1.5081f;
                    else if (gameObject.tag == "Obstacle3")
                        posX = 2.0056f;
                    break;
                case 2:
                    if(gameObject.tag == "Obstacle1")
                        posX = -2.679f;
                    else if (gameObject.tag == "Obstacle2")
                        posX = -1.495f;
                    else if (gameObject.tag == "Obstacle3")
                        posX = -1.995f;
                    break;
                default:
                    break;
            }
            transform.position = new Vector3(posX, maxPosY, 0.0f);
        }
    }
}
