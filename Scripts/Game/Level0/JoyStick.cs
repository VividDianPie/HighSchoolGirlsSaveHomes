using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MyVec2
{
    public float x, y;

    public MyVec2()
    {
        x = y = 0f;
    }

    public MyVec2(Vector2 vec)
    {
        x = vec.x;
        y = vec.y;
    }

    public Vector2 ToVector2()
    {
        return new Vector2(x, y);
    }
}


public class JoyStick : MonoBehaviour, IDragHandler,IPointerDownHandler,IPointerUpHandler
{

    //摇杆的背景图
    public GameObject JoyStickBG;

    //中间的杆
    public GameObject Stick;

    //中间杆儿
    Vector2 mSrcPos;

    void Start()
    {
        mSrcPos = Stick.GetComponent<RectTransform>().anchoredPosition;
    }

    
    void Update()
    {
        
    }


    //正在拖动的时候
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = GetRelativePos(eventData.position);
        Stick.GetComponent<RectTransform>().anchoredPosition = pos;

        pos = GetInput(pos);
        EventManager.Instance.DispatchEvent(new Event(EEventType.JoyStickDrag, new MyVec2(pos)));
    }


    //鼠标按下的时候
    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 pos = GetRelativePos(eventData.position);
        Stick.GetComponent<RectTransform>().anchoredPosition = pos;

        pos = GetInput(pos);
        EventManager.Instance.DispatchEvent(new Event(EEventType.JoyStickDown, new MyVec2(pos)));
    }


    //鼠标抬起的时候
    public void OnPointerUp(PointerEventData eventData)
    {
        Stick.GetComponent<RectTransform>().anchoredPosition = mSrcPos;
        EventManager.Instance.DispatchEvent(new Event(EEventType.JoyStickUp, null));
    }


    //获取屏幕坐标相对于背景的坐标
    public Vector2 GetRelativePos(Vector2 ScreenPos)
    {
        Vector2 relativePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(JoyStickBG.GetComponent<RectTransform>(),
            ScreenPos,
            null,
            out relativePos
            );

        //计算相对的偏移
        Vector2 dir = relativePos - mSrcPos;
        float len = Mathf.Clamp(dir.magnitude, 0, 350 / 2);

        //偏移向量
        dir.Normalize();
        dir = dir * len;

        relativePos = mSrcPos + dir;

        return relativePos;
    }


    public Vector2 GetInput(Vector2 relativePos)
    {
        Vector2 inp = new Vector2(relativePos.x / 350 * 2, relativePos.y / 350 * 2);
        return inp;
    }
}
