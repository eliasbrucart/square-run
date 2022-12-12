using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using TMPro;

public class PlayGames : MonoBehaviour
{
    string leaderboardID = "CgkIqfmmyPsTEAIQAg";
    string achievementID = "CgkIqfmmyPsTEAIQAQ";
    public static PlayGamesPlatform platform;

    static public PlayGames instancePlayGames;

    static public PlayGames GetInstancePlayGames { get { return instancePlayGames; } }

    private GameManager gameManager;

    private void Awake()
    {
        if (instancePlayGames != null && instancePlayGames != this)
            Destroy(this.gameObject);
        else
            instancePlayGames = this;
    }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            platform = PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate(success =>
        {
            if (success)
            {
                Debug.Log("Logged in successfully");
            }
            else
            {
                Debug.Log("Login Failed");
            }
        });
    }

    public void AddScoreToLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportScore(gameManager.score, leaderboardID, success => { });
        }
    }

    public void ShowLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowLeaderboardUI();
        }
    }

    public void ShowAchievements()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowAchievementsUI();
        }
    }

    public void UnlockAchievement()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(achievementID, 100f, success => { });
        }
    }
}