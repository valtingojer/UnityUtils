using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Logger : MonoBehaviour
{
    public static string basePath;
    public static string DebugLogFilename = "DebugLog";
    public static string ErrorLogFilename = "ErrorLog";

    private void OnEnable()
    {
        basePath = Application.dataPath + "/Logs/";
        Application.logMessageReceived += HandleLog;
        LoggerEventBroker.OnLogToFile += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
        LoggerEventBroker.OnLogToFile -= HandleLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Error)
        {
            WriteToFile( basePath + ErrorLogFilename, logString);
        }
        else
        {
            WriteToFile( basePath + DebugLogFilename, logString);
        }
    }

    private void WriteToFile(string filePath, string message)
    {
        string fileDateTime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

        filePath = string.Format("{0}_[{1}]_{2}.txt", filePath, fileDateTime, typeof(Logger).Name);

        if (!Directory.Exists(basePath))
        {
            Directory.CreateDirectory(basePath);
        }

        if (!File.Exists(filePath))
        {
            var fs = File.Create(filePath);
            fs.Dispose();
        }

        File.AppendAllText(filePath, message + "\n");
    }

}




