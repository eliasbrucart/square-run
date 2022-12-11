using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public float speed;
    public bool canMove;
    public Vector3 direction;

    private void Start()
    {
        canMove = false;
    }

    public abstract void Move();

    public abstract void UpdatePosition(int newPositionInX);

    public abstract void Reposition(float posX, float posY);
}
