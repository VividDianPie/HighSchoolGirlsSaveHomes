using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager//���� ��� ɾ�������� ���� �����ߺ��� ����¼�
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


    //�����¼�
    List<Event> mEvents;

    //����Ȥ���¼�:  �¼�����  List<ί��>   ��һ����������ΪEvent  �޷���ֵ�� ί��
    Dictionary<EEventType, List<Action<Event>>> mListeners;

    //����
    EventManager()
    {
        mEvents = new List<Event>();
        mListeners = new Dictionary<EEventType, List<Action<Event>>>();
    }


    //���һ���¼�
    public void DispatchEvent(Event evt)
    {
        mEvents.Add(evt);
    }


    //��Ӽ�����
    public void AddListener(EEventType type, Action<Event> call)
    {
        List<Action<Event>> litns = null;
        //����ö���¼����� ��ȡ�¼�ί������
        if (mListeners.TryGetValue(type, out litns))
        {
            //�п�
            if (litns.IndexOf(call) < 0)
            {
                litns.Add(call);
            }
        }
        else
        {
             
            litns = new List<Action<Event>>();
            litns.Add(call);

            //��ӵ��ֵ���
            mListeners.Add(type, litns);
        }
    }


    //ɾ��������
    public void DeleteListener(EEventType type, Action<Event> call)
    {
        List<Action<Event>> litns = null;
        //���ֵ��в����¼�����
        if (mListeners.TryGetValue(type, out litns))
        {
            //���¼�������ɾ����Ӧ���¼�ί��
            litns.Remove(call);
        }
    }


    //�����¼�
    public void Update()
    {
        //����ȥ������Щ����������¼�����Ȥ
        for (int i = 0; i < mEvents.Count; i++)
        {
            List<Action<Event>> litns = null;
            //����ί������Ѱ���¼�����
            if (mListeners.TryGetValue(mEvents[i].type, out litns))
            {
                //���¼�������ѭ�������¼�ί��
                for (int j = 0; j < litns.Count; j++)
                {
                    litns[j](mEvents[i]);
                }
            }
        }
        //����¼�����
        mEvents.Clear();
    }


}
