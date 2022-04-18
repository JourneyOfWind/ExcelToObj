using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorExtend
{
    [MenuItem("表格工具/生成代码")]
    private static void GenerateCoed() {
        CodeGenerate.GenerateAll();
    }
    [MenuItem("表格工具/生成配置文件")]
    private static void GenerateConfig() {
        ConfigGenerate.GenerateAll();
    }
}
