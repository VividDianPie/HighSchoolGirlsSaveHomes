using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AI中 
public class AIMstRun : BehaviorState
{

    //带参构造
    public AIMstRun(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {

    }


    // 进入这个状态的时候
    override public void OnEnter()
    {
        //怪物切换至 
        mActionMachine.ChangeAction(EActionType.MosnterRun);
        TimerMgr.Instance.OneShot("MonsterAngerIsFalse", 30, MonsterAngerIsFalse);

        //先调整朝向

    }



    //怪物idle更新的时候
    override public void Update()
    {
        ////判断当前的动作状态结束
        //if ((mActionMachine.Current as BehaviorActionBase).StateFinish == true)
        //{

        //}
        // mMaster.transform.LookAt(Hero0.heroActor.position);
        mMaster.transform.forward = (new Vector3(Hero0.heroActor.position.x, mMaster.transform.position.y, Hero0.heroActor.position.z) - mMaster.transform.position).normalized;
        mMaster.transform.position += mMaster.transform.forward * mMaster.GetComponent<MonsterData>().monsterRunSpeed * Time.deltaTime;
        //搜索目标
        GameObject heroObj = GameObject.FindGameObjectWithTag("Hero");
        //测距
        float disToHero = Vector3.Distance(mMaster.transform.position, heroObj.transform.position);
        if (disToHero < 1.5f)
        {
            mTree.ChangeState("AIMstAttack");
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
        if (other.tag == "天殛之境_裁决" || other.tag == "魂妖刀_血樱寂灭" || other.tag == "Bullet")
        {
            mTree.ChangeState("AIMstBeHit");
        }
    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }

    void MonsterAngerIsFalse()
    {
        if (mMaster == true)
        {
            mMaster.GetComponent<MonsterData>().monsterAnger = false;
        }
        mTree.ChangeToRoot();
    }
}
