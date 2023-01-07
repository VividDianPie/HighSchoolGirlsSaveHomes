using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSIdle : BehaviorActionBase//切站立动画 调用状态 完成 结束 
{

    //构造函数
    public BOSSIdle(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
         : base(type, am, master, pnt, cld)
    {

    }


    override public void Enter()
    {
        base.Enter();
        mAt.speed = 2;

        //切换动画到idle
        mAt.CrossFade("Idle", 0.05f);
        mRb.velocity = new Vector3();
        mRb.angularVelocity = new Vector3();
    }


    override public void Exit()
    {
        mAt.speed = 1;

    }

    //在这个状态运行
    override public void Update()
    {

    }



    override public void OnAnimationEnd()
    {
        base.OnAnimationEnd();
        mAt.speed = 1;
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

    override public void OnTriggerEnter(Collider other)
    {
    }

    override public void OnTriggerStay(Collider other)
    {


    }


    override public void OnTriggerExit(Collider other)
    {



    }


}
