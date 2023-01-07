using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AI中 
public class AIMstBeHit : BehaviorState
{

    //带参构造
    public AIMstBeHit(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {

    }


    // 进入这个状态的时候
    override public void OnEnter()
    {
        mMaster.GetComponent<Monster0>().healthBar.SetActive(true);

        //怪物切换至 
        mActionMachine.ChangeAction(EActionType.MosnterBeHit);
        //激怒怪物  
        mMaster.GetComponent<MonsterData>().monsterAnger = true;
        mMaster.GetComponent<MonsterData>().monsterHp -= HeroData.Instance.heroAd;

        //Debug.Log(mMaster.name);
        //Debug.Log(mMaster.GetComponent<MonsterData>().monsterHp);

        if (mMaster.GetComponent<MonsterData>().monsterHp <= 0)
        {
            mMaster.GetComponent<Monster0>().healthBar.SetActive(false);
            mMaster.GetComponent<CapsuleCollider>().enabled = false;
            mMaster.GetComponent<MonsterData>().monsterHp = 0;
            mMaster.GetComponent<Monster0>().IsDead = true;
            mTree.ChangeState("AIMstDie");
        }




    }



    //怪物idle更新的时候
    override public void Update()
    {
        //判断当前的动作状态结束
        if ((mActionMachine.Current as BehaviorActionBase).StateFinish == true)
        {
            if (mMaster.GetComponent<MonsterData>().monsterAnger == false)
            {
                mTree.ChangeToRoot();
            }
            else
            {
                mTree.ChangeState("AIMstRun");
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
        if (other.tag == "天殛之境_裁决" || other.tag == "魂妖刀_血樱寂灭" || other.tag == "Bullet")
        {
            mTree.ChangeState("AIMstBeHit1");
        }

    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }


}
