using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config;
using Newtonsoft.Json;

public class TalkChapter
{

    //用来保存本章节的对话内容
    Dictionary<int, Talk> mTalks;

    //当前处在那句对话
    int mCurrent;

    //对话所有的id
    int[] mIds;

    //节名
    public string ChapterName { get; protected set; }


    //构造函数
    public TalkChapter(string chapterCfg)
    {

        //加载配置
        TextAsset txt = Resources.Load<TextAsset>($"Configs/Scripts/{chapterCfg}");
        if (txt == null)
        {
            throw new System.Exception("剧本卑职错误，张策划小黄!");
        }

        //赋值名字
        ChapterName = txt.name;

        //反序列化
        mTalks = JsonConvert.DeserializeObject<Dictionary<int, Talk>>(txt.text);

        InitTalk();
    }


    public void InitTalk()
    {
        //读取对话id
        mIds = new int[mTalks.Count];
        mTalks.Keys.CopyTo(mIds, 0);
        Array.Sort(mIds);

        //设置初始话
        mCurrent = 0;
    }


    public Talk Current()
    {
        if (mTalks == null)
        {
            return null;
        }

        return mTalks[mIds[mCurrent]];
    }


    public void Next()
    {
        if (mCurrent >= mIds.Length - 1)
        {
            return;
        }

        mCurrent++;
    }


    public void Reset()
    {
        mCurrent = 0;
    }


    public bool IsFinish
    {
        get
        {
            return mCurrent == mIds.Length - 1;
        }
    }
}
