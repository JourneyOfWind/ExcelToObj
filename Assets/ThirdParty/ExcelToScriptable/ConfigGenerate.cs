#if UNITY_EDITOR
using Excel;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class ConfigGenerate
{
    public static void GenerateAll() {
        FileStream       stream          = File.Open(ExcelPathConst.ExcelPos, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        DataSet          dataSet         = excelDataReader.AsDataSet();
        for (int i = 0; i < dataSet.Tables.Count; i++)
        {
            EditorUtility.DisplayProgressBar("配置文件生成中", dataSet.Tables[i].TableName, (float)i / dataSet.Tables.Count);
            if (dataSet.Tables[i].TableName.StartsWith(GenerateConst.IgnoreSign))
            {
                continue;
            }
            CreateSingleConfig(dataSet.Tables[i]);
        }
        stream.Close();
        excelDataReader.Close();
        EditorUtility.ClearProgressBar();
        AssetDatabase.Refresh();
        LogTool.Log("所有配置文件生成完毕",LogColor.Green);
    }

    public static void GenerateOne(string tableName) {
        FileStream       stream          = File.Open(ExcelPathConst.ExcelPos, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        DataSet          dataSet         = excelDataReader.AsDataSet();
        for (int i = 0; i < dataSet.Tables.Count; i++)
        {
            EditorUtility.DisplayProgressBar("配置文件生成中", dataSet.Tables[i].TableName, (float)i / dataSet.Tables.Count);
            if (dataSet.Tables[i].TableName.Equals(tableName))
            {
                CreateSingleConfig(dataSet.Tables[i]);
                break;
            }
        }
        stream.Close();
        excelDataReader.Close();
        EditorUtility.ClearProgressBar();
        AssetDatabase.Refresh();
        LogTool.Log($"配置文件{tableName}InfoData生成完毕",LogColor.Green);
    }

    /// <summary>
    /// 生成单个配置文件
    /// </summary>
    /// <param name="dataTable"></param>
    private static void CreateSingleConfig(DataTable dataTable) {
        string className = dataTable.TableName + GenerateConst.DataInfo;
        string configPath = ExcelPathConst.ScriptableObject + "/" + className + GenerateConst.AssetSuffix;
        AssetDatabase.DeleteAsset(configPath);

        DirectoryTool.CreateDirectorIfNotExist(ExcelPathConst.ScriptableObject);
        ScriptableObject dataInfoInstance = ScriptableObject.CreateInstance(className);
        AssetDatabase.CreateAsset(dataInfoInstance,configPath);
        Valuation(dataInfoInstance,dataTable);
        EditorUtility.SetDirty(dataInfoInstance);
        AssetDatabase.SaveAssets();
    }

    /// <summary>
    /// 为单个文件赋值
    /// </summary>
    private static void Valuation(ScriptableObject so,DataTable dataTable) {
        Type soType = so.GetType();
        MethodInfo methodAdd = soType.GetMethod("AddData", new Type[] {typeof(BaseData)});

        DataRowCollection rowCollect = dataTable.Rows;
        for (int i = 3; i < rowCollect.Count; i++)
        {
            object[] singleData = new object[dataTable.Columns.Count];
            for (int j = 0; j < dataTable.Columns.Count; j++)
            {
                singleData[j] = rowCollect[i][j];
            }
            
            Type dataType = Type.GetType(dataTable.TableName + GenerateConst.Data);
            object dataInstance = Activator.CreateInstance(dataType);
            MethodInfo method = dataType.GetMethod("ProcessContent", new Type[] {typeof(object[])});
            object[] excelData = new object[]{singleData};
            method.Invoke(dataInstance, excelData);

            methodAdd.Invoke(so, new object[] {dataInstance});
        }
    }
}
#endif
