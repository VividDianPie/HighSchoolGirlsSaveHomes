using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Utils;



public class GameCfgMgr //���� ���� �浵 ���� ��Ч���� ���汳����Ʒ
{

    static GameCfgMgr sInstance = null;
    public static GameCfgMgr Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = new GameCfgMgr();
            }
            return sInstance;
        }
    }

    static string sFileName = "GameCfgMgr.Cfg";
    GameCfg mCfg;

    GameCfgMgr()
    {
        mCfg = null;
        Load();
    }

    //���ش浵
    public void Load()
    {
        //�жϴ浵�ļ��Ƿ����            ����һ����ʱ���ݻ���Ŀ¼
        if (FileUtils.IsFileExist(Application.temporaryCachePath + "/" + sFileName))
        {
            //���ļ�
            byte[] buf = null;
            FileUtils.ReadFromFile(Application.temporaryCachePath + "/" + sFileName, out buf);
            if (buf != null)
            {
                //ת������                      ��bufת����utf-8��ʽ�ַ���
                string jsonStr = System.Text.Encoding.UTF8.GetString(buf);
                //�����л���ֵ
                mCfg = JsonConvert.DeserializeObject<GameCfg>(jsonStr);
            }
        }
        else
        {
            mCfg = new GameCfg();
        }
    }

    //�洢�浵
    public void Save()
    {
        if (mCfg == null)
        {
            return;
        }

        //תjson
        string jsonStr = JsonConvert.SerializeObject(mCfg);//�������л�
        //��jsonstrת����utf-8��ʽbite
        byte[] datas = System.Text.Encoding.UTF8.GetBytes(jsonStr);

        //д���ļ�                                   ������ʱ�ļ�·��
        //Debug.Log("CfgPath:" + Application.temporaryCachePath + "/" + sFileName);
        FileUtils.WriteToFile(Application.temporaryCachePath + "/" + sFileName, datas);
    }                                                           //��ʱ����·��


    //���ֿ���
    public bool MusicOn
    {
        get
        {
            return mCfg.MusicOn == 1;
        }
        set
        {
            mCfg.MusicOn = value ? 1 : 0;
            Save();
        }
    }

    //��Ч����
    public bool EffectOn
    {
        get
        {
            return mCfg.EffectOn == 1;
        }
        set
        {
            mCfg.EffectOn = value ? 1 : 0;
            Save();
        }
    }


    //���汳����Ʒ
    public void SaveBag(Dictionary<int, int> bagItems)
    {
        //���汳��
        mCfg.BagItems = bagItems;
        Save();
    }

    //�׳�����
    public Dictionary<int, int> BagItems
    {
        get
        {
            return mCfg.BagItems;
        }
    }
}
