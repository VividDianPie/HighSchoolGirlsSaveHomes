using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager//管理 添加 删除监听者 调用 监听者函数 添加事件
{

    static EventManager sInstance;
    public static EventManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = new EventManager();
            }
            return sInstance;
        }
    }


    //管理事件
    List<Event> mEvents;

    //感兴趣的事件:  事件类型  List<委托>   有一个参数类型为Event  无返回值的 委托
    Dictionary<EEventType, List<Action<Event>>> mListeners;

    //构造
    EventManager()
    {
        mEvents = new List<Event>();
        mListeners = new Dictionary<EEventType, List<Action<Event>>>();
    }


    //添加一个事件
    public void DispatchEvent(Event evt)
    {
        mEvents.Add(evt);
    }


    //添加监听者
    public void AddListener(EEventType type, Action<Event> call)
    {
        List<Action<Event>> litns = null;
        //根据枚举事件类型 获取事件委托链表
        if (mListeners.TryGetValue(type, out litns))
        {
            //判空
            if (litns.IndexOf(call) < 0)
            {
                litns.Add(call);
            }
        }
        else
        {
             
            litns = new List<Action<Event>>();
            litns.Add(call);

            //添加到字典中
            mListeners.Add(type, litns);
        }
    }


    //删除监听者
    public void DeleteListener(EEventType type, Action<Event> call)
    {
        List<Action<Event>> litns = null;
        //至字典中查找事件链表
        if (mListeners.TryGetValue(type, out litns))
        {
            //至事件链表中删除对应的事件委托
            litns.Remove(call);
        }
    }


    //消费事件
    public void Update()
    {
        //遍历去访问哪些函数对这个事件感兴趣
        for (int i = 0; i < mEvents.Count; i++)
        {
            List<Action<Event>> litns = null;
            //根据委托类型寻找事件链表
            if (mListeners.TryGetValue(mEvents[i].type, out litns))
            {
                //至事件链表中循环调用事件委托
                for (int j = 0; j < litns.Count; j++)
                {
                    litns[j](mEvents[i]);
                }
            }
        }
        //清空事件链表
        mEvents.Clear();
    }


}
