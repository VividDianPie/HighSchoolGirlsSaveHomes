using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config;
using Newtonsoft.Json;

public class ItemHelp //得到道具信息
{
    static ItemHelp sInstance = null;
    public static ItemHelp Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = new ItemHelp();
            }
            return sInstance;
        }
    }


    //所有的配置
    Dictionary<int, Item> mAllCfg;


    //构造函数
    ItemHelp()
    {
        //mAllCfg = new Dictionary<int, Item>();

        //加载配置
        TextAsset txt = Resources.Load<TextAsset>("Configs/Item");

        //反序列化
        mAllCfg = JsonConvert.DeserializeObject<Dictionary<int, Item>>(txt.text);
    }

    //得到指定道具信息
    public Item Find(int id)
    {
        Item ret = null;
        mAllCfg.TryGetValue(id, out ret);
        return ret;
    }
}
