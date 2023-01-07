using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//AI中idle
public class AIMstDie : BehaviorState//管理 怪物ilde状态 切idle状态 运行时循环切不同idle状态
{
    //带参构造
    public AIMstDie(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {
    }


    //idle进入这个状态的时候
    override public void OnEnter()
    {
        //怪物切换至 
        mActionMachine.ChangeAction(EActionType.MonsterDie);
        
        mMaster.GetComponent<Rigidbody>().useGravity = false;


        //先调整朝向

    }



    //怪物idle更新的时候
    override public void Update()
    {
        //判断当前的动作状态结束
        if ((mActionMachine.Current as BehaviorActionBase).StateFinish == true)
        {
           // Destroy(mMaster, 5);
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
    //override public void OnTriggerEnter(Collider other)
    //{
       
    //}

    //override public void OnTriggerStay(Collider other)
    //{

    //}


    //override public void OnTriggerExit(Collider other)
    //{

    //}
}

