using UnityEngine;

public class LogTool
{
    public static void Init(bool openLog = true) {
        LogOpen = openLog;
        Log("打印工具初始化完成");
    }
    public static bool LogOpen = true;
    public static void LogError(string logMsg) {
        if (!LogOpen)
        {
            return;
        }
        Debug.LogError(logMsg);
    }

    public static void LogWarning(string logMsg) {
        if (!LogOpen)
        {
            return; 
        }

        Debug.LogWarning(logMsg);
    }

    public static void Log(string logMsg) {
        Log(logMsg,LogColor.White);
    }

    public static void Log(string logMsg, LogColor color = LogColor.White) {
        if (!LogOpen)
        {
            return;
        }
        Debug.Log(string.Format("<color=#{0}>{1}</color>",GetColorText(color), logMsg)); 
    }

    private static string GetColorText(LogColor color) {
        switch (color)
        {
            case LogColor.White:
                return "FFFFFF";
            case LogColor.Green:
                return "00FF1B";
            case LogColor.Red:
                return "FF0016";
            case LogColor.Yellow:
                return "FFD400";
            default:
                return "FFFFFF";
        }
    }

    public static void LogGreen(string logMsg) {
        Log(logMsg,LogColor.Green);
    }

    public static void LogYellow(string logMsg) {
        Log(logMsg,LogColor.Yellow);
    }
}

public enum LogColor
{
    White,
    Green,
    Red,
    Yellow,
}
