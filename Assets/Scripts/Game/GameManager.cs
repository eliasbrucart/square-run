using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer { get; set; }
    public int score { get; set; }
    [SerializeField] private float waitTime;
    [SerializeField] private int coinValue;
    [SerializeField] private Player player;
    [SerializeField] private Coin coin;
    [SerializeField] private List<Obstacles> obstaclesInMap = new List<Obstacles>();
    private ScenesManager sc;
    private bool startGame;
    public float timerWaitTime;

    static public GameManager instanceGameManager;
    static public GameManager Instance { get { return instanceGameManager; } }

    private const int firstScoreToIncreaseSpeed = 5;
    private const int secondScoreToIncreaseSpeed = 10;
    private const int thirdScoreToIncreaseSpeed = 15;
    private const int fourthScoreToIncreaseSpeed = 20;
    private const float increaseSpeedValue = 0.5f;

    //static public event Action<Color> ChangePlayerColor;

    private void Awake()
    {
        if (instanceGameManager != null && instanceGameManager != this)
            Destroy(this.gameObject);
        else
            instanceGameManager = this;
    }

    void Start()
    {
        sc = ScenesManager.instanceScenesManager;
        Player.PlayerDie += CheckGameOver;
        Player.PlayerGetCoin += IncreasePoints;
        timer = 0.0f;
        timerWaitTime = 0.0f;
        startGame = false;
        SquareLoggerImpl.SendLog("Holi");
    }

    void Update()
    {
        if (timerWaitTime <= waitTime)
        {
            timerWaitTime += Time.deltaTime;
        }
        else
        {
            timerWaitTime = 0.0f;
            startGame = true;
            player.canMove = true;
            for (int i = 0; i < obstaclesInMap.Count; i++)
                obstaclesInMap[i].canMove = true;
        }
        if (startGame)
        {
            timer += Time.deltaTime;
        }
        CheckGameOver();
    }

    private void IncreaseGameplaySpeed()
    {
        for (int i = 0; i < obstaclesInMap.Count; i++)
        {
            if (obstaclesInMap[i] != null)
                obstaclesInMap[i].speed += increaseSpeedValue;
        }
    }

    private void IncreasePoints()
    {
        score += coinValue;
        if (score == firstScoreToIncreaseSpeed || score == secondScoreToIncreaseSpeed || score == thirdScoreToIncreaseSpeed || score == fourthScoreToIncreaseSpeed)
        {
            IncreaseGameplaySpeed();
            RandomPlayerColor();
        }
        //agregar otro timer para que la moneda dependiendo del tiempo spawnee mas veces
    }

    private void CheckGameOver()
    {
        if (player.isDead)
            sc.ChangeScene("GameOver");
    }

    private void RandomPlayerColor()
    {
        int randomColor = Random.Range(1, 3);
        if (randomColor == 1)
            player.ChangeColor(Color.blue);
        else if (randomColor == 2)
            player.ChangeColor(Color.cyan);
        else if (randomColor == 3)
            player.ChangeColor(Color.magenta);
    }

    private void OnDisable()
    {
        Player.PlayerDie -= CheckGameOver;
        Player.PlayerGetCoin -= IncreasePoints;
    }
}
