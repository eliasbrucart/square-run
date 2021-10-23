using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SquareLoggerImpl
{
    const string PACK_NAME = "com.example.squarelogger";
    const string LOGGER_CLASS_NAME = "SquareManager";

    static AndroidJavaClass SLoggerClass = null;
    static AndroidJavaObject SLoggerInstance = null;

    static void Init()
    {
        SLoggerClass = new AndroidJavaClass(PACK_NAME + "." + LOGGER_CLASS_NAME);
        SLoggerInstance = SLoggerClass.CallStatic<AndroidJavaObject>("GetInstance");
    }

    public static void SendLog(string log)
    {
        if (SLoggerInstance == null)
            Init();
        SLoggerInstance.Call("SendLog", log);
    }
}
