using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//延时销毁
public class DelayDestory : MonoBehaviour//创建一个有 限定时间的 单次 触发定时器 其 方法为 立即销毁当前对象
{

    [Header("倒计时时间")]
    [Min(0.1f)]  //设置编辑器中最小可以给这个变咯情设置的值
    public float time;
    //public float curTime;

    
    void Start()
    {                                                                     //返回一个非负随机整数
        TimerMgr.Instance.OneShot(new System.Random().Next().ToString(), time, TimerCall);
    }


    void Update()
    {

    }


    void TimerCall()
    {
        GameObject.DestroyImmediate(this.gameObject);//立即销毁当前游戏对象
    }
}
