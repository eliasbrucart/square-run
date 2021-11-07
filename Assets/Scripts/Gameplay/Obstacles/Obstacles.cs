using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private float maxPosY;
    [SerializeField] private float minPosY;
    [SerializeField] private float minPosX;
    [SerializeField] private float maxPosX;
    private const float possiblePosXOne = 2.006f;
    private const float possiblePosXTwo = 1.5081f;
    private const float possiblePosXThree = 2.0056f;
    private const float possiblePosXFour = -1.9972f;
    private const float possiblePosXFive = -1.495f;
    private const float possiblePosXSix = -1.995f;
    public bool canMove;
    private Vector3 direction;

    private void Start()
    {
        //ObjectPooler.Instance.SpawnFromPool("Obstacle1", transform.position, Quaternion.identity);
        canMove = false;
        int randomInitialDirection = Random.Range(0, 2);
        if (randomInitialDirection == 1)
            direction = transform.right;
        else
            direction = -transform.right;
    }

    void Update()
    {
        Move();
        UpdatePosition();
    }

    private void Move()
    {
        if (canMove)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            if (gameObject.tag == "Obstacle4")
                transform.position += direction * speed * Time.deltaTime;
            if (gameObject.tag == "Obstacle4" && transform.position.x >= maxPosX)
            {
                direction *= -1;
            }
            else if (gameObject.tag == "Obstacle4" && transform.position.x <= minPosX)
            {
                direction *= -1;
            }
        }
    }

    private void UpdatePosition()
    {
        int random = Random.Range(1, 3);
        if (transform.position.y <= -7.81f)
        {
            float posX = 1;
            switch (random)
            {
                case 1:
                    if (gameObject.tag == "Obstacle1")
                        posX = possiblePosXOne;
                    else if (gameObject.tag == "Obstacle2")
                        posX = possiblePosXTwo;
                    else if (gameObject.tag == "Obstacle3")
                        posX = possiblePosXThree;
                    break;
                case 2:
                    if (gameObject.tag == "Obstacle1")
                        posX = possiblePosXFour;
                    else if (gameObject.tag == "Obstacle2")
                        posX = possiblePosXFive;
                    else if (gameObject.tag == "Obstacle3")
                        posX = possiblePosXSix;
                    break;
                default:
                    break;
            }
            if(gameObject.tag != "Obstacle4")
                Reposition(posX, maxPosY);
            else
                Reposition(0.0f, maxPosY);
        }
    }

    private void Reposition(float posX, float maxPosY)
    {
        transform.position = new Vector3(posX, maxPosY, 0.0f);
    }

    public float GetSpeed()
    {
        return speed;
    }

}
