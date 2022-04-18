using System.Collections.Generic;
using UnityEngine;
using System;
public partial class BlockDataInfo:ScriptableObject,IDataInfo
{
    public List<BlockData> mBlockDataList = new List<BlockData>();

    private Dictionary<int, BlockData> mBlockDataDict = new Dictionary<int, BlockData>();
    public BlockData GetDataByID(int id)
    {
        if (mBlockDataDict.ContainsKey(id))
        {
            return mBlockDataDict[id];
        }

        return null;
    }

    public void AddDataToDict()
    {
        foreach (var data in mBlockDataList)
        {
            mBlockDataDict.Add(data.ID, data);
        }
    }

    public void AddData(BaseData data) {     
        mBlockDataList.Add((BlockData)data);
    }
}
[Serializable]
public class BlockData:BaseData
{
    /// <summary>
    /// 木块ID
    /// </summary>
    public int ID;
    /// <summary>
    /// 形状
    /// </summary>
    public List<Vector2Int> Shape;
    /// <summary>
    /// 占据格数
    /// </summary>
    public int Value;
    /// <summary>
    /// 旋转后ID
    /// </summary>
    public int Block_rotate;
    /// <summary>
    /// 所有变体ID
    /// </summary>
    public List<int> Chain;
   
    public void ProcessContent(object[] contents)
    {
        ID = DataProcess.TurnToInt(contents[0]);
        Shape = DataProcess.TurnToListVector2Int(contents[1]);
        Value = DataProcess.TurnToInt(contents[2]);
        Block_rotate = DataProcess.TurnToInt(contents[3]);
        Chain = DataProcess.TurnToListInt(contents[4]);

    }
}
