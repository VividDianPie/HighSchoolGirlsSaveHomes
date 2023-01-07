using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//AI�� 
public class AIBOSSAtk1 : BehaviorState//����   ״̬ �� ״̬ ����ʱѭ���в�ͬ ״̬
{
    //���ι���
    public AIBOSSAtk1(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {
    }


    //�������״̬��ʱ��
    override public void OnEnter()
    {
        // �л���idle״̬
        mActionMachine.ChangeAction(EActionType.BOSSAtk1);

        //�ȵ�������
        //ƫ���޸�
        //mMaster.transform.Rotate(Vector3.up, 50);
    }



    //���� ���µ�ʱ��
    override public void Update()
    {
        //�жϵ�ǰ�Ķ���״̬����
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
        if (other.tag == "����֮��_�þ�" || other.tag == "������_Ѫӣ����")
        {
            mTree.ChangeState("AIBOSSBeHit");
        }
    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }
}