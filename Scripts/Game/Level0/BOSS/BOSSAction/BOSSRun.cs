using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSRun : BehaviorActionBase//切站立动画 调用状态 完成 结束 
{

    //构造函数
    public BOSSRun(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
         : base(type, am, master, pnt, cld)
    {

    }


    override public void Enter()
    {
        base.Enter();

        //切换动画到 
        mAt.CrossFade("Run", 0.05f);
    }


    override public void Exit()
    {


    }

    //在这个状态运行
    override public void Update()
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

    }


    //碰撞持续的时候
    override public void OnCollisionStay(Collision collision)
    {

    }


    //碰撞结束的时候
    override public void OnCollisionExit(Collision collision)
    {

    }

    //触发器
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
