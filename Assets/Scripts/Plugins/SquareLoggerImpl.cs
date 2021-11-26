using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareLoggerImpl : MonoBehaviour
{
    const string PACK_NAME = "com.example.squarelogger";
    const string LOGGER_CLASS_NAME = "SquareManager";

    static AndroidJavaClass SLoggerClass = null;
    static AndroidJavaObject SLoggerInstance = null;

    static public SquareLoggerImpl instanceSquareLoggerImpl;
    static public SquareLoggerImpl GetInstance { get { return instanceSquareLoggerImpl; } }

    private void Awake()
    {
        if (instanceSquareLoggerImpl != null && instanceSquareLoggerImpl != this)
            Destroy(gameObject);
        else
            instanceSquareLoggerImpl = this;
    }

    private void Start()
    {
        Init();
    }

    static void Init()
    {
        SLoggerClass = new AndroidJavaClass(PACK_NAME + "." + LOGGER_CLASS_NAME);
        SLoggerInstance = SLoggerClass.CallStatic<AndroidJavaObject>("GetInstance");
    }

    public static AndroidJavaClass PluginClass
    {
        get
        {
            if(SLoggerClass == null)
            {
                SLoggerClass = new AndroidJavaClass(PACK_NAME + "." + LOGGER_CLASS_NAME);
                AndroidJavaClass unityJava = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject activity = unityJava.GetStatic<AndroidJavaObject>("currentActivity");
                SLoggerClass.SetStatic("activity", activity);
            }
            return SLoggerClass;
        }
    }

    public AndroidJavaObject PluginInstance
    {
        get
        {
            if(SLoggerInstance == null)
            {
                SLoggerInstance = PluginClass.CallStatic<AndroidJavaObject>("GetInstance");
            }
            return SLoggerInstance;
        }
    }

    public void SendLog(string log)
    {
        if (SLoggerInstance == null)
            Init();
        SLoggerInstance.Call("SendLog", log);
    }

    public void SaveMaxScore(int score)
    {
        PluginInstance.Call("SaveScore", score);
    }

    public int GetMaxScore()
    {
        return PluginInstance.Call<int>("GetScore");
    }
}
