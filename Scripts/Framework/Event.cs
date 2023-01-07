using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Unity Object ����Զ���
//Object Ĭ��Ϊ Unity ��� Object
//ʹ�� Unity �� Object ���� C# System ��� Object
//��Ϊ Unity �е� Object �� C# System ��� Object �ǲ�һ����
using Object = System.Object;


public enum EEventType
{
    None = -1,
    PlayMusic,
    JoyStickDown, //ҡ�˸ձ�����
    JoyStickDrag, //ҡ�˶��϶�
    JoyStickUp,   //ҡ��̧����
    BagItemSelect,//������һ��С��Ʒ��ѡ��
    Count,
}


public class Event
{
    public EEventType type;
    public Object data;

    //����
    public Event()
    {
        data = null;
    }

    //���ι���
    public Event(EEventType t, Object datas)
    {
        type = t;
        data = datas;
    }
}
