using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config;
using Newtonsoft.Json;

public class ItemHelp //�õ�������Ϣ
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


    //���е�����
    Dictionary<int, Item> mAllCfg;


    //���캯��
    ItemHelp()
    {
        //mAllCfg = new Dictionary<int, Item>();

        //��������
        TextAsset txt = Resources.Load<TextAsset>("Configs/Item");

        //�����л�
        mAllCfg = JsonConvert.DeserializeObject<Dictionary<int, Item>>(txt.text);
    }

    //�õ�ָ��������Ϣ
    public Item Find(int id)
    {
        Item ret = null;
        mAllCfg.TryGetValue(id, out ret);
        return ret;
    }
}
