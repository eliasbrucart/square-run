using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareLoggerImpl : MonoBehaviour
{
#if UNITY_ANDROID
    const string PACK_NAME = "com.example.squarelogger";
    const string LOGGER_CLASS_NAME = "SquareManager";

    class AlertViewCallback : AndroidJavaProxy
    {
        private System.Action<int> alertHandler;

        public AlertViewCallback(System.Action<int>alertHandlerIn) : base (PACK_NAME + "." + LOGGER_CLASS_NAME + "$AlertViewCallback")
        {
            alertHandler = alertHandlerIn;
        }
        public void OnButtonTapped(int index)
        {
            Debug.Log("Button tapped: " + index);
            if (alertHandler != null)
            {
                alertHandler(index);
            }
        }
    }

    static AndroidJavaClass SLoggerClass = null;
    static AndroidJavaObject SLoggerInstance = null;

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
        // Init();
    }

    private void Update()
    {
        //if(Input.GetMouseButtonDown(0)){
        //    ShowAlertDialog(new string[] { "Atencion!", "Esta seguro que quiere borrar los registros del juego?", "Si", "No" }, (int obj) =>
        //    {
        //        Debug.Log("Local Handler called: " + obj);
        //    });
        //}
    }

    public void Init()
    {
        //SLoggerClass = new AndroidJavaClass("");
        //unityClass = new AndroidJavaObject("com.unity3d.player.UnityPlayer");
        //unityActivity = unityClass.CallStatic<AndroidJavaObject>("currentActivity");
        //_pluginInstance = new AndroidJavaObject(pluginName);
        //if(_pluginInstance == null)
        //{
        //    Debug.Log("Plugin instance error");
        //}
        //_pluginInstance.CallStatic("receiveUnityActivity", unityActivity);


        //SLoggerClass = new AndroidJavaClass(PACK_NAME + "." + LOGGER_CLASS_NAME);
        //Debug.Log("SLoggerclass " + SLoggerClass);
        //SLoggerInstance = SLoggerClass.CallStatic<AndroidJavaObject>("GetInstance");
        //Debug.Log("Logger instance" + SLoggerInstance);
    }

    public static AndroidJavaClass PluginClass
    {
        get
        {
            if (SLoggerClass == null)
            {
                SLoggerClass = new AndroidJavaClass(PACK_NAME + "." + LOGGER_CLASS_NAME);
                AndroidJavaClass unityJava = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject activity = unityJava.GetStatic<AndroidJavaObject>("currentActivity");
                Debug.Log("activity: " + activity);
                SLoggerClass.CallStatic("receiveUnityActivity", activity);
            }
            return SLoggerClass;
        }
    }

    static public AndroidJavaObject PluginInstance
    {
        get
        {
            if (SLoggerInstance == null)
            {
                SLoggerInstance = PluginClass.CallStatic<AndroidJavaObject>("GetInstance");
            }
            return SLoggerInstance;
        }
    }

    public void SendLog(string log)
    {
        PluginInstance.Call("SendLogs", log);
    }

    public void WriteFile(string a)
    {
        PluginInstance.CallStatic("WriteFile", a);
    }

    public string ReadFile(string a)
    {
        return PluginInstance.CallStatic<string>("ReadFile", a);
    }

    public string GetLogs()
    {
        return PluginInstance.Call<string>("GetAllLogs");
    }

    public void ShowAlertDialog(string[] strings, System.Action<int>handler = null)
    {
        if (strings.Length < 3)
        {
            Debug.LogError("AlertView requires at least 3 strings");
            return;
        }

        if (Application.platform == RuntimePlatform.Android)
            PluginInstance.Call("ShowAlertView", new object[] { strings, new AlertViewCallback(handler) });
        else
            Debug.LogWarning("AlertView not supported on this platform");
    }

    public void ShowAlert()
    {
        ShowAlertDialog(new string[] { "Atencion!", "Esta seguro que quiere borrar los registros del juego?", "Si", "No" }, (int obj) =>
        {
            Debug.Log("Local Handler called: " + obj);
        });
    }

    static public void SaveLastScore(int score)
    {
        //if(_pluginInstance != null)
        //{
        //    var result = _pluginInstance.Call<int>("SaveScore", score);
        //    Debug.Log("Save Max Score!");
        //}
    }

    private void OnDestroy()
    {
        if (instanceSquareLoggerImpl == this)
            instanceSquareLoggerImpl = null;
    }
#endif
}
