using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AI�� 
public class AIMstRun : BehaviorState
{

    //���ι���
    public AIMstRun(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {

    }


    // �������״̬��ʱ��
    override public void OnEnter()
    {
        //�����л��� 
        mActionMachine.ChangeAction(EActionType.MosnterRun);
        TimerMgr.Instance.OneShot("MonsterAngerIsFalse", 30, MonsterAngerIsFalse);

        //�ȵ�������

    }



    //����idle���µ�ʱ��
    override public void Update()
    {
        ////�жϵ�ǰ�Ķ���״̬����
        //if ((mActionMachine.Current as BehaviorActionBase).StateFinish == true)
        //{

        //}
        // mMaster.transform.LookAt(Hero0.heroActor.position);
        mMaster.transform.forward = (new Vector3(Hero0.heroActor.position.x, mMaster.transform.position.y, Hero0.heroActor.position.z) - mMaster.transform.position).normalized;
        mMaster.transform.position += mMaster.transform.forward * mMaster.GetComponent<MonsterData>().monsterRunSpeed * Time.deltaTime;
        //����Ŀ��
        GameObject heroObj = GameObject.FindGameObjectWithTag("Hero");
        //���
        float disToHero = Vector3.Distance(mMaster.transform.position, heroObj.transform.position);
        if (disToHero < 1.5f)
        {
            mTree.ChangeState("AIMstAttack");
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
        if (other.tag == "����֮��_�þ�" || other.tag == "������_Ѫӣ����" || other.tag == "Bullet")
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
