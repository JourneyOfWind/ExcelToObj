using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcelPathConst
{
    /// <summary>
    /// Excel文件夹
    /// </summary>
    public static string ExcelDirectory = Application.dataPath + "/Excel";

    /// <summary>
    /// 配置文件所在文件夹
    /// </summary>
    public static string ScriptableObjectDirectory = Application.dataPath + "/Resources/ScriptableObjs";

    /// <summary>
    /// Excel文件所在位置
    /// </summary>
    public static string ExcelPos = Application.dataPath + "/Excel/AllPuzzle.xlsm";

    /// <summary>
    /// DataInfo模板所在位置
    /// </summary>
    public static string DataInfoTemplate = Application.dataPath + "/ThirdParty/ExcelToScriptable/Template/DataInfoTemplate.txt";

    /// <summary>
    /// Data模板所在位置
    /// </summary>
    public static string DataTemplate = Application.dataPath + "/ThirdParty/ExcelToScriptable/Template/DataTemplate.txt";

    /// <summary>
    /// DataInfo拓展模板所在位置
    /// </summary>
    public static string DataInfoExtensionTemplate = Application.dataPath + "/ThirdParty/ExcelToScriptable/Template/DataInfoExtensionTemplate.txt";

    /// <summary>
    /// 生成数据代码的文件夹
    /// </summary>
    public static string GenerateScripts = Application.dataPath + "/Scripts/GenerateCode/DataCode";

    /// <summary>
    /// 生成数据拓展代码的文件夹
    /// </summary>
    public static string ExtentionCode = Application.dataPath + "/Scripts/GenerateCode/ExtensionCode";

    /// <summary>
    /// 生成的配置文件所在位置
    /// </summary>
    public static string ScriptableObject = "Assets/Resources/ScriptableObjs";
}
