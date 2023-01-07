using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//AI�� 
public class AIBOSSRun : BehaviorState
{
    bool debugAgentBool;
    //���ι���
    public AIBOSSRun(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {

    }


    // �������״̬��ʱ��
    override public void OnEnter()
    {
        // �л��� 
        mActionMachine.ChangeAction(EActionType.BOSSRun);
        //Ѱ·������ø���Ŀ��
        mMaster.GetComponent<NavMeshAgent>().enabled = true;


        //�ȵ�������

    }



    //����idle���µ�ʱ��
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
        //����Ŀ��
        GameObject heroObj = GameObject.FindGameObjectWithTag("Hero");
        //���
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




    //״̬�˳���ʱ��
    override public void OnExit()
    {
    }

    //��ײ��ʼ
    override public void OnCollisionEnter(Collision collision)
    {

    }


    //������ײ
    override public void OnCollisionStay(Collision collision)
    {

    }


    //��ײ�˳�ʱ
    override public void OnCollisionExit(Collision collision)
    {

    }

    //������
    override public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "����֮��_�þ�")
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
