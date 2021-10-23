package com.example.squarelogger;

import android.util.Log;

public class SquareManager {
    public static final SquareManager _instance = new SquareManager();

    public static SquareManager GetInstance(){
        Log.d("SquareLogger->", "Esta funcionando GetInstance");
        return _instance;
    }

    public void SendLog(String msg){
        Log.d("SM=>", msg);
    }
}
