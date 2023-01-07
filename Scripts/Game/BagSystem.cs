using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config;

//����ϵͳ
public class BagSystem //��� ���� ���� ����
{

    //key:��Ʒid value:����
    Dictionary<int, int> mItems;
    //�׳�����
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
        //���ر���
        mItems = GameCfgMgr.Instance.BagItems;
        if (mItems == null)
        {
            mItems = new Dictionary<int, int>();
        }
    }


    //��ӱ�����Ʒ
    public void AddItem(int id, int count)
    {
        //��������û����Ӧ��Ʒ������
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
            throw new System.Exception($"û��id: {id} ������!");
        }

        SaveCfg();
    }


    //�洢����
    public void SaveCfg()
    {
        GameCfgMgr.Instance.SaveBag(mItems);
    }

}
