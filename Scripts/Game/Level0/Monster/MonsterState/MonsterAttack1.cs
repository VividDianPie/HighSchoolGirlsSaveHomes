using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack1 : BehaviorActionBase//敌人攻击切状态与敌人攻击
{
    //构造函数
    public MonsterAttack1(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
         :
        base(type, am, master, pnt, cld)
    {

    }


    override public void Enter()
    {
        //赋值mIsStateFinish false
        base.Enter();

        mAt.CrossFade("Atk1", 0.05f);
        mRb.velocity = new Vector3();
        mRb.angularVelocity = new Vector3();
    }

    override public void Exit()
    {
        base.Exit();
    }



    override public void OnAnimationEnd()
    {
        //赋值mIsStateFinish true
        base.OnAnimationEnd();

        //todo
    }
    //动画开始
    override public void OnAnimationStart()
    {

    }


    //攻击动作点
    override public void OnAnimationHit(int i)
    {
        mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled = true;
        TimerMgr.Instance.OneShot("BangbangEnabledFalse", 0.5f, BangbangEnabledFalse);
    }
    void BangbangEnabledFalse()
    {
        mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled = false;
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
