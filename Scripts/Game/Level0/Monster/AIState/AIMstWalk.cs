using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AI中idle
public class AIMstWalk : BehaviorState//管理 怪物ilde状态 切idle状态 运行时循环切不同idle状态
{

    //带参构造
    public AIMstWalk(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {

    }


    override public void OnEnter()
    {
        mActionMachine.ChangeAction(EActionType.MosnterWalk);

        //先调整朝向

    }



    override public void Update()
    {
        if ((mActionMachine.Current as BehaviorActionBase).StateFinish == true)
        {
            //切换为根状态
            mTree.ChangeToRoot();
        }



        RaycastHit hitinfo;
        bool isCollider = Physics.Raycast(mMaster.transform.position + Vector3.up * 0.5f, mMaster.transform.forward, out hitinfo, 0.5f);
        //色线检测没有碰撞 那么可移动
        if (isCollider == false)
        {
            mMaster.transform.position = mMaster.transform.position + mMaster.transform.forward * mMaster.GetComponent<MonsterData>().monsterWalkSpeed * Time.deltaTime;
            //Debug.Log(Time.deltaTime);
        }
        else
        {
            float temp = 0.0f;
            if (UnityEngine.Random.value > 0.9f)
            {
                mMaster.transform.forward = -mMaster.transform.forward;
            }
            else
            {
                mMaster.transform.forward = new Vector3(UnityEngine.Random.value, 0, UnityEngine.Random.value);
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
            mTree.ChangeState("AIMstBeHit");
        }
    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }
}
