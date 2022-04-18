using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileTool
{
    /// <summary>
    /// 读取文件内容
    /// </summary>
    /// <param name="filePath">文件带后缀完全路径</param>
    /// <returns></returns>
    public static string ReadFile(string filePath)
    {
        FileStream   fileStream = new FileStream(filePath, FileMode.Open);
        StreamReader sw         = new StreamReader(fileStream);
        string       readTxt    = sw.ReadToEnd();
        fileStream.Close();
        sw.Close();
        return readTxt;
    }
    /// <summary>
    /// 写入文件
    /// </summary>
    /// <param name="filePath">文件带后缀完全路径</param>
    /// <param name="fileContent">文件内容</param>
    public static void WriteFile(string filePath, string fileContent)
    {
        FileStream   fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
        StreamWriter sw         = new StreamWriter(fileStream);
        sw.Write(fileContent);
        sw.Close();
        fileStream.Close();
    }

    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="filePath">文件带后缀完全路径</param>
    public static void DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        else
        {
            Debug.LogWarning($"位于{filePath}的文件不存在");
        }
    }

    /// <summary>
    /// 是否存在文件
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static bool FileExist(string filePath) {
        return File.Exists(filePath);
    }
}
