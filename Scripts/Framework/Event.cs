using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Unity Object 万物皆对象
//Object 默认为 Unity 里的 Object
//使其 Unity 中 Object 等于 C# System 里的 Object
//因为 Unity 中的 Object 与 C# System 里的 Object 是不一样的
using Object = System.Object;


public enum EEventType
{
    None = -1,
    PlayMusic,
    JoyStickDown, //摇杆刚被按中
    JoyStickDrag, //摇杆儿拖动
    JoyStickUp,   //摇杆抬起来
    BagItemSelect,//背包中一个小物品被选中
    Count,
}


public class Event
{
    public EEventType type;
    public Object data;

    //构造
    public Event()
    {
        data = null;
    }

    //带参构造
    public Event(EEventType t, Object datas)
    {
        type = t;
        data = datas;
    }
}
