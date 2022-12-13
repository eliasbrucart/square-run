using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareLoggerImpl : MonoBehaviour
{
#if UNITY_ANDROID
    const string PACK_NAME = "com.example.squarelogger";
    const string LOGGER_CLASS_NAME = "SquareManager";

    static AndroidJavaClass SLoggerClass = null;
    static AndroidJavaObject SLoggerInstance = null;
    AndroidJavaObject _pluginInstance;

    static public SquareLoggerImpl instanceSquareLoggerImpl;
    public static SquareLoggerImpl GetInstance()
    {
        return instanceSquareLoggerImpl;
    }

    private void Awake()
    {
        if (instanceSquareLoggerImpl != null)
        {
            Destroy(gameObject);
            return;
        }
        instanceSquareLoggerImpl = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Init();
    }

    static public void Init()
    {
        SLoggerClass = new AndroidJavaClass(PACK_NAME + "." + LOGGER_CLASS_NAME);
        Debug.Log("SLoggerclass " + SLoggerClass);
        SLoggerInstance = SLoggerClass.CallStatic<AndroidJavaObject>("GetInstance");
        Debug.Log("Logger instance" + SLoggerInstance);
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
                Debug.Log("activity: " + activity);
                SLoggerClass.SetStatic("activity", activity);
            }
            return SLoggerClass;
        }
    }

    static public AndroidJavaObject PluginInstance
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

    static public void SendLog(string log)
    {
        if (SLoggerInstance == null)
            Init();
        SLoggerInstance.Call("SendLog", log);
    }

    static public void SaveMaxScore(int score)
    {
        PluginInstance.Call("SaveScore", score);
    }

    static public int GetMaxScore()
    {
        return PluginInstance.Call<int>("GetScore");
    }

    private void OnDestroy()
    {
        if (instanceSquareLoggerImpl == this)
            instanceSquareLoggerImpl = null;
    }
#endif
}
