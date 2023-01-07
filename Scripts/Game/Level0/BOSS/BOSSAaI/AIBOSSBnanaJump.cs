using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AI中 
public class AIBOSSBnanaJump : BehaviorState//管理   状态 切 状态 运行时循环切不同 状态
{
    //带参构造
    public AIBOSSBnanaJump(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {
    }


    // 进入这个状态的时候
    override public void OnEnter()
    {
        // 切换至idle状态
        mActionMachine.ChangeAction(EActionType.BOSSBnanaJump);

        mMaster.GetComponent<CapsuleCollider>().enabled = false;
        //先调整朝向

    }



    //怪物 更新的时候
    override public void Update()
    {
        mMaster.GetComponent<Animator>().MatchTarget(Hero0.heroActor.position - Hero0.heroActor.forward * 2 + Hero0.heroActor.up*2, //匹配目标（坐标点）
            Hero0.heroActor.transform.rotation, //匹配目标旋转
            AvatarTarget.RightHand,//对象匹配
            new MatchTargetWeightMask(new Vector3(1, 1, 1), //匹配权重 坐标百分百匹配
            0.0f),//匹配 权重 旋转 百分零匹配
            0.3f,//匹配开始动画帧 
            0.6f);//匹配结束动画帧
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

    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }
}

