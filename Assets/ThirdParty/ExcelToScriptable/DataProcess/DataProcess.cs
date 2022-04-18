using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataProcess
{
    /// <summary>
    /// 数组分割符
    /// </summary>
    public const char ArraySplit = '|';

    /// <summary>
    /// 坐标前缀
    /// </summary>
    public const string VectorPrefix = "(";
    /// <summary>
    /// 坐标后缀
    /// </summary>
    public const string VectorSuffix = ")";
    /// <summary>
    /// 坐标内容分割符
    /// </summary>
    public const char VectorSplit = ':';

    /// <summary>
    /// 空字符
    /// </summary>
    public const string Empty = "";
    /// <summary>
    /// True字符
    /// </summary>
    public const string StrTrue = "True";
    /// <summary>
    /// False字符
    /// </summary>
    public const string StrFalse = "False";

    /// <summary>
    /// 转换int
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static int TurnToInt(object content) {
        int.TryParse(content.ToString(),out int intNum);
        return intNum;
    }
    /// <summary>
    /// 转换为string
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static string TurnToString(object content) {
        return content.ToString();
    }

    /// <summary>
    /// 转换为float
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static float TurnToFloat(object content) {
        float.TryParse(content.ToString(), out float floatNum);
        return floatNum;
    }

    /// <summary>
    /// 转换为bool
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static bool TurnToBool(object content) {
        string contentStr = content.ToString();
        if (int.TryParse(contentStr,out int intNum))
            return intNum != 0;

        if (contentStr.Equals(StrTrue))
            return true;

        if (contentStr.Equals(StrFalse))
            return false;

        Debug.LogError("不是Bool类型");
        return false;
    }

    /// <summary>
    /// 转换为double
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static double TurnToDouble(object content) {
        double.TryParse(content.ToString(), out double doubleNum);
        return doubleNum;
    }

    /// <summary>
    /// 转换为Vector2
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static Vector2 TurnToVector2(object content) {
        string[] strArray = ChangeVectorStrToStrArray(content);
        float[] floatArray = ChangeStrArrayToFloatArray(strArray);

        if (floatArray.Length != 2)
        {
            Debug.LogError("数组长度错误");
            return default;
        }
        return new Vector2(floatArray[0],floatArray[1]);
    }

    /// <summary>
    /// 转换为Vector2Int
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static Vector2Int TurnToVector2Int(object content) {

        string[] strArray = ChangeVectorStrToStrArray(content);
        int[] intArray = ChangeStrArrayToIntArray(strArray);


        if (intArray.Length != 2)
        {
            Debug.LogError("数组长度错误");
            return default;
        }
        return new Vector2Int(intArray[0], intArray[1]);
    }

    

    //private static T[] ChangeDataType <T> (string[] strArray)  where T: Object
    //{
    //    T[] array = new T[strArray.Length];
    //    for (int i = 0; i < strArray.Length; i++)
    //    {
    //        array[i] = strArray[i] as T;
    //    }

    //    return array;
    //}

    /// <summary>
    /// 转换为Vector3
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static Vector3 TurnToVector3(object content)
    {
        string[] strArray   = ChangeVectorStrToStrArray(content);
        float[]  floatArray = ChangeStrArrayToFloatArray(strArray);

        if (floatArray.Length != 3)
        {
            Debug.LogError("数组长度错误");
            return default;
        }
        return new Vector3(floatArray[0], floatArray[1],floatArray[2]);
    }

    /// <summary>
    /// 转换为VectorInt
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static Vector3Int TurnToVector3Int(object content)
    {
        string[] strArray = ChangeVectorStrToStrArray(content);
        int[]    intArray = ChangeStrArrayToIntArray(strArray);


        if (intArray.Length != 3)
        {
            Debug.LogError("数组长度错误");
            return default;
        }
        return new Vector3Int(intArray[0], intArray[1],intArray[2]);
    }

    /// <summary>
    /// 转换为Color
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static Color TurnToColor(object content)
    {
        string[] strArray   = ChangeVectorStrToStrArray(content);
        float[]  floatArray = ChangeStrArrayToFloatArray(strArray);

        if (floatArray.Length != 3)
        {
            Debug.LogError("数组长度错误");
            return default;
        }
        return new Color(floatArray[0], floatArray[1], floatArray[2]);
    }

    /// <summary>
    /// 分割坐标类string转为stringArray
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    private static string[] ChangeVectorStrToStrArray(object content)
    {
        string contentStr = content.ToString();
        contentStr = contentStr.Replace(VectorPrefix, Empty);
        contentStr = contentStr.Replace(VectorSuffix, Empty);
        var strArray = contentStr.Split(VectorSplit);
        return strArray;
    }

    /// <summary>
    /// 转换stringArray为floatArray
    /// </summary>
    /// <param name="strArray"></param>
    /// <returns></returns>
    private static float[] ChangeStrArrayToFloatArray(string[] strArray)
    {
        float[] floatArray = new float[strArray.Length];
        for (int i = 0; i < strArray.Length; i++)
        {
            floatArray[i] = TurnToFloat(strArray[i]);
        }

        return floatArray;
    }
    /// <summary>
    /// 转换stringArray为intArray
    /// </summary>
    /// <param name="strArray"></param>
    /// <returns></returns>
    private static int[] ChangeStrArrayToIntArray(string[] strArray)
    {
        int[] intArray = new int[strArray.Length];
        for (int i = 0; i < strArray.Length; i++)
        {
            intArray[i] = TurnToInt(strArray[i]);
        }
        return intArray;
    }

    public static string[] ChangeStrToStrArray(object content) {
        string contentStr = content.ToString();
        var    strArray   = contentStr.Split(ArraySplit);
        return strArray;
    }


    /// <summary>
    /// 转为Int数组
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static List<int> TurnToListInt(object content)
    {
        string[] strArray = ChangeStrToStrArray(content);

        List<int> intList = new List<int>();
        for (int i = 0; i < strArray.Length; i++)
            intList.Add(TurnToInt(strArray[i]));

        return intList;
    }

    /// <summary>
    /// 转换为string数组
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static List<string> TurnToListString(object content) {
        string[] strArray = ChangeStrToStrArray(content);

        List<string> stringList = new List<string>();
        for (int i = 0; i < strArray.Length; i++)
            stringList.Add(strArray[i]);

        return stringList;
    }

    /// <summary>
    /// 转换为float数组
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static List<float> TurnToListFloat(object content)
    {
        string[] strArray = ChangeStrToStrArray(content);

        List<float> floatList = new List<float>();
        for (int i = 0; i < strArray.Length; i++)
            floatList.Add(TurnToFloat(strArray[i]));

        return floatList;
    }


    /// <summary>
    /// 转换为bool数组
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static List<bool> TurnToListBool(object content)
    {
        string[] strArray = ChangeStrToStrArray(content);

        List<bool> boolList = new List<bool>();
        for (int i = 0; i < strArray.Length; i++)
            boolList.Add(TurnToBool(strArray[i]));

        return boolList;
    }

    /// <summary>
    /// 转换为double数组
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static List<double> TurnToListDouble(object content)
    {
        string[] strArray = ChangeStrToStrArray(content);

        List<double> doubleList = new List<double>();
        for (int i = 0; i < strArray.Length; i++)
            doubleList.Add(TurnToDouble(strArray[i]));

        return doubleList;
    }

    /// <summary>
    /// 转为Vector2数组
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static List<Vector2> TurnToListVector2(object content)
    {
        string[] strArray = ChangeStrToStrArray(content);

        List<Vector2> vector2List = new List<Vector2>();
        for (int i = 0; i < strArray.Length; i++)
            vector2List.Add(TurnToVector2(strArray[i]));

        return vector2List;
    }

    /// <summary>
    /// 转为Vector2Int数组
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static List<Vector2Int> TurnToListVector2Int(object content)
    {
        string[] strArray = ChangeStrToStrArray(content);

        List<Vector2Int> vector2IntList = new List<Vector2Int>();
        for (int i = 0; i < strArray.Length; i++)
            vector2IntList.Add(TurnToVector2Int(strArray[i]));

        return vector2IntList;
    }

    /// <summary>
    /// 转为Vector3数组
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static List<Vector3> TurnToListVector3(object content)
    {
        string[] strArray = ChangeStrToStrArray(content);

        List<Vector3> vector3List = new List<Vector3>();
        for (int i = 0; i < strArray.Length; i++)
            vector3List.Add(TurnToVector3(strArray[i]));

        return vector3List;
    }

    /// <summary>
    /// 转为Vector3Int数组
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static List<Vector3Int> TurnToListVector3Int(object content)
    {
        string[] strArray = ChangeStrToStrArray(content);

        List<Vector3Int> vector3IntList = new List<Vector3Int>();
        for (int i = 0; i < strArray.Length; i++)
            vector3IntList.Add(TurnToVector3Int(strArray[i]));

        return vector3IntList;
    }

    /// <summary>
    /// 转为Vector3数组
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static List<Color> TurnToListColor(object content)
    {
        string[] strArray = ChangeStrToStrArray(content);

        List<Color> colorList = new List<Color>();
        for (int i = 0; i < strArray.Length; i++)
            colorList.Add(TurnToColor(strArray[i]));

        return colorList;
    }
}


public enum DataType
{
    Int,
    String,
    Float,
    Bool,
    Double,
    Vector2,
    Vector2Int,
    Vector3,
    Vector3Int,
    Color,
    List
}
