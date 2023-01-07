using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//AI中idle
public class AIBOSSDie : BehaviorState//管理  状态 切 状态 运行时循环切不同 状态
{
    //带参构造
    public AIBOSSDie(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {
    } 


    // 进入这个状态的时候
    override public void OnEnter()
    {
        // 切换至idle状态
        mActionMachine.ChangeAction(EActionType.BOSSDie);

        //先调整朝向

    }



    //怪物idle更新的时候
    override public void Update()
    {

        //判断当前的动作状态结束

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

    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }
}
