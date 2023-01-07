using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ETimerType
{
    OneShot,//单次计时器
    Repeated,//重复计时器
}


public class Timer//添加 消费调用 （指定）删除定时器  
{

    //当前这个定时器对象的唯一标识符
    public string key;


    //超时时间
    public float time;


    //当前数到的时间
    public float curTime;


    //定时器的类型：OneShot(这种类型的定时器只使用一次就自动销毁)  Repeated(重复定时器)
    public ETimerType type;


    //回调函数
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
    //管理所有的定时器
    Dictionary<string, Timer> mDicTimer;
    TimerMgr()
    {
        mDicTimer = new Dictionary<string, Timer>();
    }


    //增
    public bool AddTimer(Timer timer)
    {
        //重复判断
        if (mDicTimer.ContainsKey(timer.key))
        {
            return false;
        }

        mDicTimer.Add(timer.key, timer);

        return true;
    }


    //删
    public bool DeleteTimer(string key)
    {
        //if (!mAll.ContainsKey(key))
        //{
        //    return false;
        //}

        //mAll.Remove(key);

        Timer t = null;
        //判空
        if (!mDicTimer.TryGetValue(key, out t))
        {
            return false;
        }

        t.isDead = true;

        return true;
    }


    //OneShot单次触发
    public bool OneShot(string key, float time, Action action)
    {
        return AddTimer(new Timer(key, time, ETimerType.OneShot, action));
    }


    //Repeated重复触发
    public bool Repeated(string key, float time, Action action)
    {
        return AddTimer(new Timer(key, time, ETimerType.Repeated, action));
    }


    //update
    public void Update()
    {
        float dt = Time.deltaTime;
        //先加时间
        List<string> needDel = new List<string>();
        foreach (var kv in mDicTimer)
        {
            if (kv.Value.isDead)
            {
                continue;
            }
            //取出定时器累加时间
            kv.Value.curTime += dt;

            //定时器的时间到了
            if (kv.Value.curTime >= kv.Value.time)
            {
                kv.Value.curTime = 0f;
                //调用定时器的方法
                kv.Value.action();

                //如果定时器是只响一次
                if (kv.Value.type == ETimerType.OneShot)
                {
                    //当前定时器失效
                    kv.Value.isDead = true;
                }
            }

            if (kv.Value.isDead)
            {
                //循环记下已失效的单次计时器的名字
                needDel.Add(kv.Key);
            }
        }
        //根据记下的名字销毁已失效的单次定时器
        for (int i = 0; i < needDel.Count; i++)
        {
            mDicTimer.Remove(needDel[i]);
        }
    }
}
