using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//AI中 
public class AIBOSSRun : BehaviorState
{
    bool debugAgentBool;
    //带参构造
    public AIBOSSRun(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {

    }


    // 进入这个状态的时候
    override public void OnEnter()
    {
        // 切换至 
        mActionMachine.ChangeAction(EActionType.BOSSRun);
        //寻路组件设置跟随目标
        mMaster.GetComponent<NavMeshAgent>().enabled = true;


        //先调整朝向

    }



    //怪物idle更新的时候
    override public void Update()
    {
        if (mMaster.GetComponent<NavMeshAgent>().isOnNavMesh ==true)
        {
            Debug.Log("statr Way-finding");
            mMaster.GetComponent<BOSS>().Agent.destination = Hero0.heroActor.transform.position;
        }
        else
        {
            Debug.Log("NO statr Way-finding");
            mMaster.transform.position += mMaster.transform.forward * mMaster.GetComponent<MonsterData>().BOSSRunSpeed * Time.deltaTime;


        }

        mMaster.transform.forward = (new Vector3(Hero0.heroActor.position.x, mMaster.transform.position.y, Hero0.heroActor.position.z) - mMaster.transform.position).normalized;
        //搜索目标
        GameObject heroObj = GameObject.FindGameObjectWithTag("Hero");
        //测距
        float disToHero = Vector3.Distance(mMaster.transform.position, heroObj.transform.position);
        if (disToHero < 1.5f)
        {
            float angle = Vector3.Angle(heroObj.transform.forward, mMaster.transform.forward);
            if (angle >= 145f)
            {
                mTree.ChangeState("AIBOSSBnanaJump");
                mMaster.GetComponent<NavMeshAgent>().enabled = false;
            }
            else
            {
                mTree.ChangeState("AIBOSSAtk0");
                mMaster.GetComponent<NavMeshAgent>().enabled = false;
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
        if (other.tag == "天殛之境_裁决")
        {
            //mTree.ChangeState("AIMstBeHit");
        }
    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }
}
