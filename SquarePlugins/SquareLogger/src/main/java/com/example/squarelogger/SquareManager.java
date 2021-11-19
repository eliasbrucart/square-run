package com.example.squarelogger;

import java.io.File;
import android.app.Activity;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

import android.util.Log;

public class SquareManager {
    public static final SquareManager _instance = new SquareManager();
    public static Activity activity;

    public static SquareManager GetInstance(){
        Log.d("SquareLogger->", "Esta funcionando GetInstance");
        return _instance;
    }

    public void SendLog(String msg){
        Log.d("SM=>", msg);
    }

    public void SaveLogs(){
        File file;
    }

    public void SaveScore(int score){
        File path = activity.getFilesDir();
        File file = new File(path, "score.txt");

        try{
            FileOutputStream stream = new FileOutputStream(file);
            try
            {
                stream.write(Integer.toString(score).getBytes());
            }
            finally {
                stream.close();
            }
        }
        catch(IOException e){
            Log.e("Exception", "Error: the file could not be recorded" + e.toString());
        }
    }
}
