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
    //[SerializeField] private List<WallObstacle> obstaclesInMap = new List<WallObstacle>();
    [SerializeField] private ObstacleManager obstacleManager;
    [SerializeField] private PlayGames playGames;
    private ScenesManager sceneManager;
    //private SquareLoggerImpl squarePluginImpl;
    private bool startGame;
    private float timerToSpeedUpGameplay;

    public float timerWaitTime;
    public int timeToSpeedUpGameplay;

    static public GameManager instanceGameManager;
    static public GameManager Instance { get { return instanceGameManager; } }

    private const int firstScoreToIncreaseSpeed = 5;
    private const int secondScoreToIncreaseSpeed = 10;
    private const int thirdScoreToIncreaseSpeed = 15;
    private const int fourthScoreToIncreaseSpeed = 20;
    private const float increaseSpeedValue = 1.0f;

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
        //squarePluginImpl = SquareLoggerImpl.GetInstance();
        //SquareLoggerImpl.Init();
        sceneManager = ScenesManager.instanceScenesManager;
        Player.PlayerDie += CheckGameOver;
        Player.PlayerGetCoin += IncreasePoints;
        timer = 0.0f;
        timerWaitTime = 0.0f;
        timerToSpeedUpGameplay = 0.0f;
        startGame = false;
        //squarePluginImpl.SendLog("Holi");
    }

    void Update()
    {
        if (timerWaitTime <= waitTime)
            timerWaitTime += Time.deltaTime;
        else
        {
            timerWaitTime = 0.0f;
            startGame = true;
            player.canMove = true;
            for (int i = 0; i < obstacleManager.GetWallObstacles.Count; i++)
                obstacleManager.GetWallObstacles[i].canMove = true;
        }
        if (startGame)
        {
            timer += Time.deltaTime;
            if (timerToSpeedUpGameplay <= timeToSpeedUpGameplay)
                timerToSpeedUpGameplay += Time.deltaTime;
            CheckTimerSpeedUpGameplay();
        }
        CheckGameOver(); //Mover a un evento que se llame cuando el player choca con un obstaculo.
    }

    private void IncreaseGameplaySpeed()
    {
        for (int i = 0; i < obstacleManager.GetWallObstacles.Count; i++)
        {
            if (obstacleManager.GetWallObstacles[i] != null)
                obstacleManager.GetWallObstacles[i].speed += increaseSpeedValue;
        }
    }

    private void IncreasePoints()
    {
        score += coinValue;
        if (score == firstScoreToIncreaseSpeed || score == secondScoreToIncreaseSpeed || score == thirdScoreToIncreaseSpeed || score == fourthScoreToIncreaseSpeed)
            PlayGames.UnlockAchievement(GPGSIds.achievement_beginner);
        //SquareLoggerImpl.instanceSquareLoggerImpl.SaveMaxScore(score);
        //if (score == firstScoreToIncreaseSpeed || score == secondScoreToIncreaseSpeed || score == thirdScoreToIncreaseSpeed || score == fourthScoreToIncreaseSpeed)
        //if(timerToSpeedUpGameplay >= timeToSpeedUpGameplay)
        //{
        //    IncreaseGameplaySpeed();
        //    ResetTimerToSpeedUpGameplay();
        //    RandomPlayerColor();
        //}
        //agregar otro timer para que la moneda dependiendo del tiempo spawnee mas veces
    }

    private void CheckGameOver()
    {
        if (player.isDead)
        {
            SquareLoggerImpl.SaveMaxScore(score);
            sceneManager.ChangeScene("GameOver");
            PlayGames.AddScoreToLeaderboard(score);
        }
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

    private void CheckTimerSpeedUpGameplay()
    {
        if (timerToSpeedUpGameplay >= timeToSpeedUpGameplay)
        {
            ResetTimerToSpeedUpGameplay();
            IncreaseGameplaySpeed();
            RandomPlayerColor();
        }
    }

    private void ResetTimerToSpeedUpGameplay()
    {
        if (timerToSpeedUpGameplay >= timeToSpeedUpGameplay)
            timerToSpeedUpGameplay = 0.0f;
    }

    private void OnDisable()
    {
        Player.PlayerDie -= CheckGameOver;
        Player.PlayerGetCoin -= IncreasePoints;
    }
}
