using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using TMPro;

public class PlayGames : MonoBehaviour
{
    public static PlayGamesPlatform platform;

    static public PlayGames instancePlayGames;

    static public PlayGames GetInstancePlayGames { get { return instancePlayGames; } }

    private GameManager gameManager;

    private static string achievement1ID = GPGSIds.achievement_beginner;
    private static string leaderboardID = GPGSIds.leaderboard_score_table;

    private void Awake()
    {
        if (instancePlayGames != null && instancePlayGames != this)
            Destroy(this.gameObject);
        else
            instancePlayGames = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void Init()
    {
        PlayGamesPlatform.Instance.Authenticate((callback) => { UnlockAchievement(achievement1ID); });
    }

    static public void AddScoreToLeaderboard(int score)
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            PlayGamesPlatform.Instance.ReportScore(score, leaderboardID, success => { Debug.Log("Se subio al leaderboard"); });
        }
    }

    static public void ShowLeaderboard()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
    }

    static public void ShowAchievements()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
    }

    static public void UnlockAchievement(string a)
    {

        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            Debug.Log("LLamdo a desbloquear logro");
            PlayGamesPlatform.Instance.ReportProgress(a, 100f, success => { });
        }
    }
}