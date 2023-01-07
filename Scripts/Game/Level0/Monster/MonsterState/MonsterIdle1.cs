using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIdle1 : BehaviorActionBase//敌人 切idle动画 判断 动画是否开始 结束
{

    //构造函数
    public MonsterIdle1(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
         : base(type, am, master, pnt, cld)
    {

    }


    override public void Enter()
    {
        base.Enter();

        //切换动画到idle
        mAt.CrossFade("Idle1", 0.05f);
    }


    //在这个状态运行
    override public void Update()
    {

    }

    override public void Exit()
    {

    }


    override public void OnAnimationEnd()
    {
        base.OnAnimationEnd();

        //todo
    }


    //碰撞开始的时候
    override public void OnCollisionEnter(Collision collision)
    {
        Collision test = collision;
        int i = 1;
    }


    //碰撞持续的时候
    override public void OnCollisionStay(Collision collision)
    {

    }


    //碰撞结束的时候
    override public void OnCollisionExit(Collision collision)
    {

    }

    override public void OnTriggerEnter(Collider other)
    {
        //mAm.ChangeAction(EActionType.MosnterBeHit);
    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }
}
