package com.example.squarelogger;

import java.io.File;
import android.app.Activity;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

import android.app.Application;
import android.content.Context;
import android.util.Log;

import android.widget.Toast;

import java.io.InputStream;
import java.io.OutputStreamWriter;
import java.io.InputStreamReader;
import java.io.BufferedReader;
import java.io.FileNotFoundException;

public class SquareManager extends Application {
    public static final SquareManager _instance = new SquareManager();
    public static Activity activity;

    private static final String LOGTAG = "CWGTech";

    public static SquareManager GetInstance(){
        Log.d(LOGTAG, "Esta funcionando GetInstance");
        return _instance;
    }

    public static void receiveUnityActivity(Activity tactivity){
        activity = tactivity;
        Log.i(LOGTAG, "Entro en ReceiveUnityActivity");
    }

    public void SendLogs(String logs){
        Log.i(LOGTAG, logs);
        File path = activity.getFilesDir();
        File file = new File(path, "log.txt");

        try{
            Log.i(LOGTAG, "Llego al primer try");
            FileOutputStream stream = new FileOutputStream(file);
            try {
                stream.write(Integer.parseInt(logs));
                Log.i(LOGTAG, "Llego al segundo try");
                //Toast.makeText(activity, "Saved Score!", Toast.LENGTH_SHORT).show();
            }
            finally {
                stream.close();
                Log.i(LOGTAG, "Cerro el archivo!");
            }
        }
        catch(IOException e){
            Log.e("Exception", "Error: the file could not be recorded" + e.toString());
        }
    }

    public String GetAllLogs(){
        File path = activity.getFilesDir();

        File file = new File(path, "log.txt");
        if (!file.exists())
            Log.i(LOGTAG, "No se encontro el archivo!");

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

        String logs = new String(bytes);
        return logs;
    }

    public static void WriteFile(String a){
        Context mycontext = activity.getApplicationContext();
        try {
            OutputStreamWriter outputStreamWriter= new OutputStreamWriter(mycontext.openFileOutput("logs", Context.MODE_APPEND));

            outputStreamWriter.write(a + "\n");
            outputStreamWriter.close();

            Log.d(LOGTAG, "Se escribio el archive exitosamente");
        }
        catch (IOException e) {
            Log.e(LOGTAG, "error: " +e.toString());
        }
    }

    public static String ReadFile(String a){
        Context context = activity.getApplicationContext();

        String ret = "";

        try {
            InputStream inputStream = context.openFileInput("logs");

            if ( inputStream != null ) {
                InputStreamReader inputStreamReader = new InputStreamReader(inputStream);
                BufferedReader bufferedReader = new BufferedReader(inputStreamReader);
                String receiveString = "";
                StringBuilder stringBuilder = new StringBuilder();

                while ( (receiveString = bufferedReader.readLine()) != null ) {
                    stringBuilder.append("\n").append(receiveString);
                }

                inputStream.close();
                ret = stringBuilder.toString();
            }

            Log.d(LOGTAG, "Se lee el archive");
        }
        catch (FileNotFoundException e) {
            Log.e(LOGTAG, "Error: " + e.toString());
        } catch (IOException e) {
            Log.e(LOGTAG, "Error: " + e.toString());
        }

        return ret;
    }

    public static void ClearFile(String a){
        Context context = activity.getApplicationContext();
        context.deleteFile("logs");
        WriteFile("");
    }
}