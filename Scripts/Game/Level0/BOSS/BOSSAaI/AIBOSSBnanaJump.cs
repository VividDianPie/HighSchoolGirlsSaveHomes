using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AI�� 
public class AIBOSSBnanaJump : BehaviorState//����   ״̬ �� ״̬ ����ʱѭ���в�ͬ ״̬
{
    //���ι���
    public AIBOSSBnanaJump(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {
    }


    // �������״̬��ʱ��
    override public void OnEnter()
    {
        // �л���idle״̬
        mActionMachine.ChangeAction(EActionType.BOSSBnanaJump);

        mMaster.GetComponent<CapsuleCollider>().enabled = false;
        //�ȵ�������

    }



    //���� ���µ�ʱ��
    override public void Update()
    {
        mMaster.GetComponent<Animator>().MatchTarget(Hero0.heroActor.position - Hero0.heroActor.forward * 2 + Hero0.heroActor.up*2, //ƥ��Ŀ�꣨����㣩
            Hero0.heroActor.transform.rotation, //ƥ��Ŀ����ת
            AvatarTarget.RightHand,//����ƥ��
            new MatchTargetWeightMask(new Vector3(1, 1, 1), //ƥ��Ȩ�� ����ٷְ�ƥ��
            0.0f),//ƥ�� Ȩ�� ��ת �ٷ���ƥ��
            0.3f,//ƥ�俪ʼ����֡ 
            0.6f);//ƥ���������֡
        if ((mActionMachine.Current as BehaviorActionBase).StateFinish == true)
        {
            mTree.ChangeState("AIBOSSRun");
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

    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }
}

