using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSBnanaJump : BehaviorActionBase//��   ����״̬ ��� ����  (�㽶��)
{

    //���캯��
    public BOSSBnanaJump(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
         : base(type, am, master, pnt, cld)
    {

    }


    override public void Enter()
    {
        base.Enter();
     

        //�л�������idle
        mAt.CrossFade("BnanaJump", 0.05f);
        mRb.velocity = new Vector3();
        mRb.angularVelocity = new Vector3();
    }


    override public void Exit()
    {
        mAt.speed = 1;

    }

    //�����״̬����
    override public void Update()
    {

    }


    //����������
    override public void OnAnimationHit(int i)
    {
        mMaster.GetComponent<CapsuleCollider>().enabled = true;
    }
    override public void OnAnimationEnd()
    {
        base.OnAnimationEnd();
        mAt.speed = 1;
        //todo
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
