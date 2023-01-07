using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Utils;



public class GameCfgMgr //加载 储存 存档 音乐 音效开关 保存背包物品
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

    //加载存档
    public void Load()
    {
        //判断存档文件是否存在            返回一个临时数据缓存目录
        if (FileUtils.IsFileExist(Application.temporaryCachePath + "/" + sFileName))
        {
            //读文件
            byte[] buf = null;
            FileUtils.ReadFromFile(Application.temporaryCachePath + "/" + sFileName, out buf);
            if (buf != null)
            {
                //转换数据                      将buf转换成utf-8格式字符串
                string jsonStr = System.Text.Encoding.UTF8.GetString(buf);
                //反序列化赋值
                mCfg = JsonConvert.DeserializeObject<GameCfg>(jsonStr);
            }
        }
        else
        {
            mCfg = new GameCfg();
        }
    }

    //存储存档
    public void Save()
    {
        if (mCfg == null)
        {
            return;
        }

        //转json
        string jsonStr = JsonConvert.SerializeObject(mCfg);//对象序列化
        //将jsonstr转换成utf-8格式bite
        byte[] datas = System.Text.Encoding.UTF8.GetBytes(jsonStr);

        //写入文件                                   申请临时文件路径
        //Debug.Log("CfgPath:" + Application.temporaryCachePath + "/" + sFileName);
        FileUtils.WriteToFile(Application.temporaryCachePath + "/" + sFileName, datas);
    }                                                           //临时缓存路径


    //音乐开关
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

    //音效开关
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


    //保存背包物品
    public void SaveBag(Dictionary<int, int> bagItems)
    {
        //保存背包
        mCfg.BagItems = bagItems;
        Save();
    }

    //抛出背包
    public Dictionary<int, int> BagItems
    {
        get
        {
            return mCfg.BagItems;
        }
    }
}
