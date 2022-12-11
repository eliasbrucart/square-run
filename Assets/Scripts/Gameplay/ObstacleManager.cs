using UnityEngine;
using System.Collections.Generic;


public class ObstacleManager : MonoBehaviour
{
    //[SerializeField] public float speed;
    [SerializeField] private float maxPosY;
    [SerializeField] private float minPosY;
    [SerializeField] private float minPosX;
    [SerializeField] private float maxPosX;
    [SerializeField] private List<WallObstacle> wallObstacles = new List<WallObstacle>();
    private const float possiblePosXOne = 1.34f;
    private const float possiblePosXTwo = 1.7f;
    private const float possiblePosXThree = 1.49f;
    private const float possiblePosXFour = -1.37f;
    private const float possiblePosXFive = -1.7f;
    private const float possiblePosXSix = -1.53f;

    public List<WallObstacle> GetWallObstacles { get { return wallObstacles; } }

    //public bool canMove;
    //private Vector3 direction;

    private void Start()
    {
        //canMove = false;
        //int randomInitialDirection = Random.Range(0, 2);
        //if (randomInitialDirection == 1)
        //    direction = transform.right;
        //else
        //    direction = -transform.right;
    }

    void Update()
    {
        for(int i = 0; i < wallObstacles.Count; i++)
        {
            wallObstacles[i].Move();
            CheckPositionOfObstacles(i);
            UpdatePosition(i);
            //wallObstacles[i].UpdatePosition();
        }
        //UpdatePosition();
    }

    //Llamar al metodo re posicion de los obsatuculos o algo parecido.
    private void CheckPositionOfObstacles(int indexOfObstacle)
    {
        if (wallObstacles[indexOfObstacle].canMove)
        {
            //transform.position += Vector3.down * speed * Time.deltaTime;
            if (wallObstacles[indexOfObstacle].gameObject.tag == "Obstacle4")
                wallObstacles[indexOfObstacle].transform.position += wallObstacles[indexOfObstacle].direction * wallObstacles[indexOfObstacle].speed * Time.deltaTime;
            if (wallObstacles[indexOfObstacle].gameObject.tag == "Obstacle4" && wallObstacles[indexOfObstacle].transform.position.x >= maxPosX)
            {
                wallObstacles[indexOfObstacle].transform.position = new Vector3(maxPosX, wallObstacles[indexOfObstacle].transform.position.y, 0.0f);
                wallObstacles[indexOfObstacle].direction *= -1;
            }
            else if (wallObstacles[indexOfObstacle].gameObject.tag == "Obstacle4" && wallObstacles[indexOfObstacle].transform.position.x <= minPosX)
            {
                wallObstacles[indexOfObstacle].transform.position = new Vector3(minPosX, wallObstacles[indexOfObstacle].transform.position.y, 0.0f);
                wallObstacles[indexOfObstacle].direction *= -1;
            }
        }
    }

    //Mejorar este metodo y mejorar el metodo de la clase que los overraidea.
    private void UpdatePosition(int indexOfObstacle)
    {
        int random = Random.Range(1, 3);

        if(wallObstacles[indexOfObstacle].transform.position.y <= minPosY)
        {
            float posX = 1.0f;
            switch (random)
            {
                case 1:
                    if (wallObstacles[indexOfObstacle].gameObject.tag == "Obstacle1")
                        posX = possiblePosXOne;
                    else if (wallObstacles[indexOfObstacle].gameObject.tag == "Obstacle2")
                        posX = possiblePosXTwo;
                    else if (wallObstacles[indexOfObstacle].gameObject.tag == "Obstacle3")
                        posX = possiblePosXThree;
                    break;
                case 2:
                    if (wallObstacles[indexOfObstacle].gameObject.tag == "Obstacle1")
                        posX = possiblePosXFour;
                    else if (wallObstacles[indexOfObstacle].gameObject.tag == "Obstacle2")
                        posX = possiblePosXFive;
                    else if (wallObstacles[indexOfObstacle].gameObject.tag == "Obstacle3")
                        posX = possiblePosXSix;
                    break;
                default:
                    break;
            }
            if (wallObstacles[indexOfObstacle].gameObject.tag != "Obstacle4")
                wallObstacles[indexOfObstacle].Reposition(posX, maxPosY);
            else
                wallObstacles[indexOfObstacle].Reposition(0.0f, maxPosY);
        }

        //if (transform.position.y <= minPosY)
        //{
        //    float posX = 1.0f;
        //    switch (random)
        //    {
        //        case 1:
        //            if (gameObject.tag == "Obstacle1")
        //                posX = possiblePosXOne;
        //            else if (gameObject.tag == "Obstacle2")
        //                posX = possiblePosXTwo;
        //            else if (gameObject.tag == "Obstacle3")
        //                posX = possiblePosXThree;
        //            break;
        //        case 2:
        //            if (gameObject.tag == "Obstacle1")
        //                posX = possiblePosXFour;
        //            else if (gameObject.tag == "Obstacle2")
        //                posX = possiblePosXFive;
        //            else if (gameObject.tag == "Obstacle3")
        //                posX = possiblePosXSix;
        //            break;
        //        default:
        //            break;
        //    }
        //    if(gameObject.tag != "Obstacle4")
        //        Reposition(posX, maxPosY);
        //    else
        //        Reposition(0.0f, maxPosY);
        //}
    }

    private void Reposition(float posX, float maxPosY)
    {
        transform.position = new Vector3(posX, maxPosY, 0.0f);
    }
}
