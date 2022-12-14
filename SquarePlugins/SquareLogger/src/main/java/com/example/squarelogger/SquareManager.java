package com.example.squarelogger;

import java.io.File;
import android.app.Activity;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

import android.util.Log;
import android.widget.Toast;

public class SquareManager {
    public static final SquareManager _instance = new SquareManager();
    public static Activity activity;

    private static final String LOGTAG = "CWGTech";

    public static SquareManager GetInstance(){
        Log.d("SquareLogger->", "Esta funcionando GetInstance");
        return _instance;
    }

    public void SendLog(String msg){
        Log.d("SM=>", msg);
    }

    public static void receiveUnityActivity(Activity tactivity){
        activity = tactivity;
    }

    public void SaveLogs(){

    }

    public void SaveScore(int score){
        File path = activity.getFilesDir();
        File file = new File(path, "score.txt");

        try{
            FileOutputStream stream = new FileOutputStream(file);
            try {
                stream.write(Integer.toString(score).getBytes());
                Log.i(LOGTAG, "Test!");
                //Toast.makeText(activity, "Saved Score!", Toast.LENGTH_SHORT).show();
            }
            finally {
                stream.close();
            }
        }
        catch(IOException e){
            Log.e("Exception", "Error: the file could not be recorded" + e.toString());
        }
    }

    public int GetScore(){
        File path = activity.getFilesDir();

        File file = new File(path, "score.txt");
        if (!file.exists()) return 0;

        int length = (int) file.length();
        byte[] bytes = new byte[length];

        try
        {
            FileInputStream stream = new FileInputStream(file);
            try
            {
                stream.read(bytes);
            }
            finally
            {
                stream.close();
            }
        }
        catch (IOException e)
        {
            Log.e("Exception", "File write failed: " + e.toString());
        }

        String maxScore = new String(bytes);
        return Integer.parseInt(maxScore);
    }
}