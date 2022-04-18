using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigToolTest:MonoBehaviour
{
    private void Awake() {
        LoadAsset();
    }
    private void LoadAsset() {
        BlockDataInfo dataInfo = ConfigManager.Load<BlockDataInfo>();
        var           dataList = dataInfo.mBlockDataList;
        for (int i = 0; i < dataList.Count; i++)
        {
            LogTool.Log(dataList[i].ID.ToString());   
        }
    }
}
