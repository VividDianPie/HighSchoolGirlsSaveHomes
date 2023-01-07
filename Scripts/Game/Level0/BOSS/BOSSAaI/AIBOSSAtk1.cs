using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//AI中 
public class AIBOSSAtk1 : BehaviorState//管理   状态 切 状态 运行时循环切不同 状态
{
    //带参构造
    public AIBOSSAtk1(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {
    }


    //进入这个状态的时候
    override public void OnEnter()
    {
        // 切换至idle状态
        mActionMachine.ChangeAction(EActionType.BOSSAtk1);

        //先调整朝向
        //偏移修复
        //mMaster.transform.Rotate(Vector3.up, 50);
    }



    //怪物 更新的时候
    override public void Update()
    {
        //判断当前的动作状态结束
        if ((mActionMachine.Current as BehaviorActionBase).StateFinish == true)
        {
            mTree.ChangeState("AIBOSSRun");
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
            mTree.ChangeState("AIBOSSBeHit");
        }
    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }
}
