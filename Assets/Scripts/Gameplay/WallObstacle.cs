using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObstacle : Obstacle
{
    public override void Move()
    {
        if (canMove)
            transform.position += Vector3.down * speed * Time.deltaTime;
    }

    public override void UpdatePosition(int newPositionInX)
    {
        //Pensar aca como pasarlo a cada uno
    }

    public override void Reposition(float posX, float posY)
    {
        transform.position = new Vector3(posX, posY, 0.0f);
    }
}
