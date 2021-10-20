using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxPosX;
    [SerializeField] private float minPosX;
    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position.x >= 2.68f)
            transform.position = new Vector3(maxPosX, 0.0f, 0.0f);
        if(transform.position.x <= -2.68f)
            transform.position = new Vector3(minPosX, 0.0f, 0.0f);
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0.0f, 0.0f);
        transform.position += direction * speed * Time.deltaTime;
    }
}
