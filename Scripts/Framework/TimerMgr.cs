using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ETimerType
{
    OneShot,//���μ�ʱ��
    Repeated,//�ظ���ʱ��
}


public class Timer//��� ���ѵ��� ��ָ����ɾ����ʱ��  
{

    //��ǰ�����ʱ�������Ψһ��ʶ��
    public string key;


    //��ʱʱ��
    public float time;


    //��ǰ������ʱ��
    public float curTime;


    //��ʱ�������ͣ�OneShot(�������͵Ķ�ʱ��ֻʹ��һ�ξ��Զ�����)  Repeated(�ظ���ʱ��)
    public ETimerType type;


    //�ص�����
    public Action action;

    public bool isDead;


    public Timer(string key, float time, ETimerType type, Action action)
    {
        curTime = 0;
        this.key = key;
        this.time = time;
        this.type = type;
        this.action = action;
        isDead = false;
    }
}



public class TimerMgr
{
    static TimerMgr sInstance = null;
    public static TimerMgr Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = new TimerMgr();
            }
            return sInstance;
        }
    }
    //�������еĶ�ʱ��
    Dictionary<string, Timer> mDicTimer;
    TimerMgr()
    {
        mDicTimer = new Dictionary<string, Timer>();
    }


    //��
    public bool AddTimer(Timer timer)
    {
        //�ظ��ж�
        if (mDicTimer.ContainsKey(timer.key))
        {
            return false;
        }

        mDicTimer.Add(timer.key, timer);

        return true;
    }


    //ɾ
    public bool DeleteTimer(string key)
    {
        //if (!mAll.ContainsKey(key))
        //{
        //    return false;
        //}

        //mAll.Remove(key);

        Timer t = null;
        //�п�
        if (!mDicTimer.TryGetValue(key, out t))
        {
            return false;
        }

        t.isDead = true;

        return true;
    }


    //OneShot���δ���
    public bool OneShot(string key, float time, Action action)
    {
        return AddTimer(new Timer(key, time, ETimerType.OneShot, action));
    }


    //Repeated�ظ�����
    public bool Repeated(string key, float time, Action action)
    {
        return AddTimer(new Timer(key, time, ETimerType.Repeated, action));
    }


    //update
    public void Update()
    {
        float dt = Time.deltaTime;
        //�ȼ�ʱ��
        List<string> needDel = new List<string>();
        foreach (var kv in mDicTimer)
        {
            if (kv.Value.isDead)
            {
                continue;
            }
            //ȡ����ʱ���ۼ�ʱ��
            kv.Value.curTime += dt;

            //��ʱ����ʱ�䵽��
            if (kv.Value.curTime >= kv.Value.time)
            {
                kv.Value.curTime = 0f;
                //���ö�ʱ���ķ���
                kv.Value.action();

                //�����ʱ����ֻ��һ��
                if (kv.Value.type == ETimerType.OneShot)
                {
                    //��ǰ��ʱ��ʧЧ
                    kv.Value.isDead = true;
                }
            }

            if (kv.Value.isDead)
            {
                //ѭ��������ʧЧ�ĵ��μ�ʱ��������
                needDel.Add(kv.Key);
            }
        }
        //���ݼ��µ�����������ʧЧ�ĵ��ζ�ʱ��
        for (int i = 0; i < needDel.Count; i++)
        {
            mDicTimer.Remove(needDel[i]);
        }
    }
}
