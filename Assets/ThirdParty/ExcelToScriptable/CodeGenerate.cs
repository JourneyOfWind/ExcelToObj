#if UNITY_EDITOR
using Excel;
using System.Data;
using System.IO;
using System.Text;
using UnityEditor;

public class CodeGenerate
{

    private static string mPropertyFormat = "    /// <summary>\n"  +
                                            "    /// {0}\n"        +
                                            "    /// </summary>\n" +
                                            "    public {1} {2};\n";

    private static string mPropertyValuationFormat = "        {0} = DataProcess.TurnTo{1}(contents[{2}]);\n";

    public static void GenerateAll() {
        FileStream stream = File.Open(ExcelPathConst.ExcelPos, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        DataSet dataSet = excelDataReader.AsDataSet();
        for (int i = 0; i < dataSet.Tables.Count; i++)
        {
            EditorUtility.DisplayProgressBar("代码生成中",dataSet.Tables[i].TableName,(float)i/dataSet.Tables.Count);

            if (dataSet.Tables[i].TableName.StartsWith(GenerateConst.IgnoreSign))
                continue;
            CreateScripts(dataSet.Tables[i]);
        }
        stream.Close();
        excelDataReader.Close();
        EditorUtility.ClearProgressBar();
        AssetDatabase.Refresh();
        LogTool.Log("全部代码生成完毕", LogColor.Yellow);
    }

    public static void GenerateOne(string tableName) {
        FileStream       stream          = File.Open(ExcelPathConst.ExcelPos, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        DataSet          dataSet         = excelDataReader.AsDataSet();
        for (int i = 0; i < dataSet.Tables.Count; i++)
        {
            EditorUtility.DisplayProgressBar("代码生成中", dataSet.Tables[i].TableName, (float)i / dataSet.Tables.Count);

            if (!dataSet.Tables[i].TableName.Equals(tableName)) continue;
            CreateScripts(dataSet.Tables[i]);
            
            break;
        }
        stream.Close();
        excelDataReader.Close();
        EditorUtility.ClearProgressBar();
        AssetDatabase.Refresh();
    }

    private static void CreateScripts(DataTable collection) {
        DataRowCollection rowCollect = collection.Rows;
        StringBuilder propertySb = new StringBuilder();
        StringBuilder propertyValuationSb = new StringBuilder();

        for (int i = 0; i < collection.Columns.Count; i++)
        {
            string singleProperty = string.Format(mPropertyFormat, rowCollect[0][i], rowCollect[2][i], rowCollect[1][i]);
            propertySb.Append(singleProperty);

            string singlePropertyValuation = GetSinglePropertyValuation(rowCollect[1][i].ToString(), rowCollect[2][i].ToString(), i);
            propertyValuationSb.Append(singlePropertyValuation);
        }


        string dataInfoName = collection.TableName + GenerateConst.DataInfo + GenerateConst.CsSuffix;
        string dataInfoCodePath = ExcelPathConst.GenerateScripts + "/" + dataInfoName;


        StringBuilder totalSb = new StringBuilder();
        string dataInfo = FileTool.ReadFile(ExcelPathConst.DataInfoTemplate);
        string dataClassName = collection.TableName + GenerateConst.Data;
        dataInfo = dataInfo.Replace("ExcelData", dataClassName);
        totalSb.Append(dataInfo);

        string data = FileTool.ReadFile(ExcelPathConst.DataTemplate);
        data = data.Replace("ExcelData", dataClassName);
        data = data.Replace("Property", propertySb.ToString());
        data = data.Replace("PropertiesStr", propertyValuationSb.ToString());
        totalSb.Append(data);

        FileTool.DeleteFile(dataInfoCodePath);

        DirectoryTool.CreateDirectorIfNotExist(ExcelPathConst.GenerateScripts);
        FileTool.WriteFile(dataInfoCodePath, totalSb.ToString());

        LogTool.Log($"生成代码{collection.TableName}成功", LogColor.Green);

        DirectoryTool.CreateDirectorIfNotExist(ExcelPathConst.ExtentionCode);
        //写入拓展文件
        string extensionCodePath = ExcelPathConst.ExtentionCode + "/" + collection.TableName + GenerateConst.DataInfoExtension + GenerateConst.CsSuffix;
        if (FileTool.FileExist(extensionCodePath))
            return;

        string extension = FileTool.ReadFile(ExcelPathConst.DataInfoExtensionTemplate);
        extension = extension.Replace("Excel", collection.TableName);
        FileTool.WriteFile(extensionCodePath, extension);

    }

    
    private static string GetSinglePropertyValuation(string propertyName,string type,int index) {

        string typeStr = string.Empty;
        if (type.StartsWith("List"))
        {
            typeStr += DataType.List;
        }

        type = type.Replace("List", "");
        type = type.Replace("<", "");
        type = type.Replace(">", "");

        typeStr += GetTypeStr(type);
        return string.Format(mPropertyValuationFormat, propertyName,typeStr, index);
    }

    private static string GetTypeStr(string type) {
        string typeStr = string.Empty;
        switch (type)
        {
            case "int":
                typeStr = DataType.Int.ToString();
                break;
            case "string":
                typeStr = DataType.String.ToString();
                break;
            case "float":
                typeStr = DataType.Float.ToString();
                break;
            case "bool":
                typeStr = DataType.Bool.ToString();
                break;
            case "double":
                typeStr = DataType.Double.ToString();
                break;
            case "Vector2":
                typeStr = DataType.Vector2.ToString();
                break;
            case "Vector2Int":
                typeStr = DataType.Vector2Int.ToString();
                break;
            case "Vector3":
                typeStr = DataType.Vector3.ToString();
                break;
            case "Vector3Int":
                typeStr = DataType.Vector3Int.ToString();
                break;
            case "Color":
                typeStr = DataType.Color.ToString();
                break;
        }

        return typeStr;
    }
}
#endif






