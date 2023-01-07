using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMstAttack1 : BehaviorState//管理怪物攻击 进入当前状态 运行时 判断 切 状态
{
    //带参构造
    public AIMstAttack1(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {

    }


    //刚进入这个状态的时候
    override public void OnEnter()
    {
        mActionMachine.ChangeAction(EActionType.MosnterAttack1);
    }



    //更新的时候
    override public void Update()
    {
        //当前怪物攻击状态结束判断
        if ((mActionMachine.Current as BehaviorActionBase).StateFinish == true)
        {
            if (mMaster.GetComponent< MonsterData >().monsterAnger /*MonsterData.Instance.monsterAnger*/ == false)
            {
                mTree.ChangeToRoot();
                //如果切monster切换状态后 其武器任然有攻击帧的话那么 使其失效
                if (mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled == true)
                {
                    mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled = false;
                }
            }
            else
            {
                mTree.ChangeState("AIMstRun");
                //如果切monster切换状态后 其武器任然有攻击帧的话那么 使其失效
                if (mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled == true)
                {
                    mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled = false;
                }
            }
        }
    }



    //状态退出的时候
    override public void OnExit()
    {

    }

    //碰撞开始
    override public void OnCollisionEnter(Collision collision)
    {

    }


    //持续碰撞
    override public void OnCollisionStay(Collision collision)
    {

    }


    //碰撞退出时
    override public void OnCollisionExit(Collision collision)
    {

    }

    //触发器
    override public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "天殛之境_裁决" || other.tag == "魂妖刀_血樱寂灭")
        {
            mTree.ChangeState("AIMstBeHit");
            //如果切monster切换状态后 其武器任然有攻击帧的话那么 使其失效
            if (mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled == true)
            {
                mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }
}
