using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private float maxPosY;
    [SerializeField] private float minPosY;
    private const float possiblePosXOne = 2.006f;
    private const float possiblePosXTwo = 1.5081f;
    private const float possiblePosXThree = 2.0056f;
    private const float possiblePosXFour = -1.9972f;
    private const float possiblePosXFive = -1.495f;
    private const float possiblePosXSix = -1.995f;
    public bool canMove;

    private void Start()
    {
        canMove = false;
    }

    void Update()
    {
        Move();
        UpdatePosition();
    }

    private void Move()
    {
        if(canMove)
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
                        posX = possiblePosXOne;
                    else if (gameObject.tag == "Obstacle2")
                        posX = possiblePosXTwo;
                    else if (gameObject.tag == "Obstacle3")
                        posX = possiblePosXThree;
                    break;
                case 2:
                    if(gameObject.tag == "Obstacle1")
                        posX = possiblePosXFour;
                    else if (gameObject.tag == "Obstacle2")
                        posX = possiblePosXFive;
                    else if (gameObject.tag == "Obstacle3")
                        posX = possiblePosXSix;
                    break;
                default:
                    break;
            }
            transform.position = new Vector3(posX, maxPosY, 0.0f);
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

}
