using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorExtend
{
    [MenuItem("��񹤾�/���ɴ���")]
    private static void GenerateCoed() {
        CodeGenerate.GenerateAll();
    }
    [MenuItem("��񹤾�/���������ļ�")]
    private static void GenerateConfig() {
        ConfigGenerate.GenerateAll();
    }
}
