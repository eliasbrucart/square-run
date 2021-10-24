using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer { get; set; }
    public int score { get; set; }
    [SerializeField] private int coinValue;
    [SerializeField] private Player player;
    [SerializeField] private Coin coin;
    private ScenesManager sc;

    static public GameManager instanceGameManager;
    static public GameManager Instance { get { return instanceGameManager; } }

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
        SquareLoggerImpl.SendLog("Holi");
    }

    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        CheckGameOver();
    }

    private void IncreasePoints()
    {
        score += coinValue;
    }

    private void CheckGameOver()
    {
        if(player.isDead)
            sc.ChangeScene("GameOver");
    }

    private void OnDisable()
    {
        Player.PlayerDie -= CheckGameOver;
        Player.PlayerGetCoin -= IncreasePoints;
    }
}
