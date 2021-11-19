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

    public void SendLog(string log)
    {
        if (SLoggerInstance == null)
            Init();
        SLoggerInstance.Call("SendLog", log);
    }
}
