using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoggerEventBroker
{
    public delegate void LogToFileEvent(string logString, string stackTrace, LogType type);
    public static event LogToFileEvent OnLogToFile;


    public static void Log(params object[] args)
    {
        string message = args.Length > 0 ? args[0].ToString() : "";
        Log(new System.Exception(message), args);
    }

    //create log with exception and args
    public static void Log(System.Exception ex, params object[] args)
    {
        string message = string.Empty;
        for (int i = 0; i < args.Length; i++)
        {
            message += string.Format("{0} ", args[i].ToString());
        }

        string dateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string stackTrace = ex.StackTrace;
        string exceptionType = ex.GetType().ToString();
        string exceptionMessage = ex.Message;
        string exceptionSource = ex.Source;
        string exceptionTargetSite = ex.TargetSite.ToString();
        string exceptionData = string.Empty;
        if (ex.Data != null)
        {
            foreach (DictionaryEntry entry in ex.Data)
            {
                exceptionData += string.Format("{0} = {1}\n", entry.Key, entry.Value);
            }
        }
        string exceptionInnerException = string.Empty;
        if (ex.InnerException != null)
        {
            exceptionInnerException = ex.InnerException?.ToString();
        }
        string exceptionHelpLink = ex.HelpLink;
        string exceptionTargetSiteName = ex.TargetSite?.Name;
        string exceptionTargetSiteModule = ex.TargetSite?.Module?.Name;
        string exceptionTargetSiteDeclaringType = ex.TargetSite?.DeclaringType?.ToString();
        string exceptionTargetSiteModuleVersion = ex.TargetSite?.Module?.ModuleVersionId.ToString();
        string exceptionTargetSiteModuleScopeName = ex.TargetSite?.Module?.ScopeName;
        string exceptionTargetSiteModuleFullyQualifiedName = ex.TargetSite?.Module?.FullyQualifiedName;
        string exceptionTargetSiteModuleName = ex.TargetSite?.Module?.Name;



        //create log full message
        string logString = string.Format("===\n");
        logString += string.Format("[{0}]\n", dateTime);
        logString += string.Format("Message: {0}\n", message);
        logString += string.Format("stackTrace: {0}\n", stackTrace);
        logString += string.Format("exceptionType: {0}\n", exceptionType);
        logString += string.Format("exceptionMessage: {0}\n", exceptionMessage);
        logString += string.Format("exceptionSource: {0}\n", exceptionSource);
        logString += string.Format("exceptionTargetSite: {0}\n", exceptionTargetSite);
        logString += string.Format("exceptionData: {0}\n", exceptionData);
        logString += string.Format("exceptionInnerException: {0}\n", exceptionInnerException);
        logString += string.Format("exceptionHelpLink: {0}\n", exceptionHelpLink);
        logString += string.Format("exceptionTargetSiteName: {0}\n", exceptionTargetSiteName);
        logString += string.Format("exceptionTargetSiteModule: {0}\n", exceptionTargetSiteModule);
        logString += string.Format("exceptionTargetSiteDeclaringType: {0}\n", exceptionTargetSiteDeclaringType);
        logString += string.Format("exceptionTargetSiteModuleVersion: {0}\n", exceptionTargetSiteModuleVersion);
        logString += string.Format("exceptionTargetSiteModuleScopeName: {0}\n", exceptionTargetSiteModuleScopeName);
        logString += string.Format("exceptionTargetSiteModuleFullyQualifiedName: {0}\n", exceptionTargetSiteModuleFullyQualifiedName);
        logString += string.Format("exceptionTargetSiteModuleName: {0}\n", exceptionTargetSiteModuleName);
        logString += string.Format("===\n");

        OnLogToFile?.Invoke(logString, stackTrace, LogType.Error);
    }


}
