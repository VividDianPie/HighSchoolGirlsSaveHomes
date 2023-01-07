using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack1 : BehaviorActionBase//���˹�����״̬����˹���
{
    //���캯��
    public MonsterAttack1(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
         :
        base(type, am, master, pnt, cld)
    {

    }


    override public void Enter()
    {
        //��ֵmIsStateFinish false
        base.Enter();

        mAt.CrossFade("Atk1", 0.05f);
        mRb.velocity = new Vector3();
        mRb.angularVelocity = new Vector3();
    }

    override public void Exit()
    {
        base.Exit();
    }



    override public void OnAnimationEnd()
    {
        //��ֵmIsStateFinish true
        base.OnAnimationEnd();

        //todo
    }
    //������ʼ
    override public void OnAnimationStart()
    {

    }


    //����������
    override public void OnAnimationHit(int i)
    {
        mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled = true;
        TimerMgr.Instance.OneShot("BangbangEnabledFalse", 0.5f, BangbangEnabledFalse);
    }
    void BangbangEnabledFalse()
    {
        mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled = false;
    }

    //��ײ��ʼ��ʱ��
    override public void OnCollisionEnter(Collision collision)
    {

    }


    //��ײ������ʱ��
    override public void OnCollisionStay(Collision collision)
    {

    }


    //��ײ������ʱ��
    override public void OnCollisionExit(Collision collision)
    {

    }

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
