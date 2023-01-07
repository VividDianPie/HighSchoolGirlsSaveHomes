using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config;
using Newtonsoft.Json;

public class TalkChapter
{

    //�������汾�½ڵĶԻ�����
    Dictionary<int, Talk> mTalks;

    //��ǰ�����Ǿ�Ի�
    int mCurrent;

    //�Ի����е�id
    int[] mIds;

    //����
    public string ChapterName { get; protected set; }


    //���캯��
    public TalkChapter(string chapterCfg)
    {

        //��������
        TextAsset txt = Resources.Load<TextAsset>($"Configs/Scripts/{chapterCfg}");
        if (txt == null)
        {
            throw new System.Exception("�籾��ְ�����Ų߻�С��!");
        }

        //��ֵ����
        ChapterName = txt.name;

        //�����л�
        mTalks = JsonConvert.DeserializeObject<Dictionary<int, Talk>>(txt.text);

        InitTalk();
    }


    public void InitTalk()
    {
        //��ȡ�Ի�id
        mIds = new int[mTalks.Count];
        mTalks.Keys.CopyTo(mIds, 0);
        Array.Sort(mIds);

        //���ó�ʼ��
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
