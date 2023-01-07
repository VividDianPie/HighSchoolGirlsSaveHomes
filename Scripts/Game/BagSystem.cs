using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config;

//背包系统
public class BagSystem //添加 加载 保存 背包
{

    //key:物品id value:数量
    Dictionary<int, int> mItems;
    //抛出背包
    public Dictionary<int, int> Items
    {
        get
        {
            return mItems;
        }
    }


    static BagSystem sInstance = null;
    public static BagSystem Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = new BagSystem();
            }
            return sInstance;
        }
    }


    BagSystem()
    {
        //加载背包
        mItems = GameCfgMgr.Instance.BagItems;
        if (mItems == null)
        {
            mItems = new Dictionary<int, int>();
        }
    }


    //添加背包物品
    public void AddItem(int id, int count)
    {
        //得需检查有没有相应物品的配置
        Item cfg = ItemHelp.Instance.Find(id);
        if (cfg != null)
        {
            if (mItems.ContainsKey(id))
            {
                mItems[id] += count;
            }
            else
            {
                mItems.Add(id, count);
            }

            if (mItems[id] <= 0)
            {
                mItems.Remove(id);
            }
        }
        else
        {
            throw new System.Exception($"没有id: {id} 的配置!");
        }

        SaveCfg();
    }


    //存储数据
    public void SaveCfg()
    {
        GameCfgMgr.Instance.SaveBag(mItems);
    }

}
