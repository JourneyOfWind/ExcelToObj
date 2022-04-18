using System.Collections.Generic;
using UnityEngine;
using System;
public partial class PurChaseDataInfo:ScriptableObject,IDataInfo
{
    public List<PurChaseData> mPurChaseDataList = new List<PurChaseData>();

    private Dictionary<int, PurChaseData> mPurChaseDataDict = new Dictionary<int, PurChaseData>();
    public PurChaseData GetDataByID(int id)
    {
        if (mPurChaseDataDict.ContainsKey(id))
        {
            return mPurChaseDataDict[id];
        }

        return null;
    }

    public void AddDataToDict()
    {
        foreach (var data in mPurChaseDataList)
        {
            mPurChaseDataDict.Add(data.ID, data);
        }
    }

    public void AddData(BaseData data) {     
        mPurChaseDataList.Add((PurChaseData)data);
    }
}
[Serializable]
public class PurChaseData:BaseData
{
    /// <summary>
    /// 唯一标识
    /// </summary>
    public int ID;
    /// <summary>
    /// 物品名称
    /// </summary>
    public string Name;
    /// <summary>
    /// 安卓Key
    /// </summary>
    public string AndroidKey;
    /// <summary>
    /// 物品ID
    /// </summary>
    public int ItemID;
    /// <summary>
    /// 物品数量
    /// </summary>
    public int ItemCount;
    /// <summary>
    /// Pr价格
    /// </summary>
    public double Price;
    /// <summary>
    /// 折扣
    /// </summary>
    public int Discount;
   
    public void ProcessContent(object[] contents)
    {
        ID = DataProcess.TurnToInt(contents[0]);
        Name = DataProcess.TurnToString(contents[1]);
        AndroidKey = DataProcess.TurnToString(contents[2]);
        ItemID = DataProcess.TurnToInt(contents[3]);
        ItemCount = DataProcess.TurnToInt(contents[4]);
        Price = DataProcess.TurnToDouble(contents[5]);
        Discount = DataProcess.TurnToInt(contents[6]);

    }
}
