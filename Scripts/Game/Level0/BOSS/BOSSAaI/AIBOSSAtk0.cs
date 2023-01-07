using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//AI�� 
public class AIBOSSAtk0 : BehaviorState//����   ״̬ �� ״̬ ����ʱѭ���в�ͬ ״̬
{
    //���ι���
    public AIBOSSAtk0(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {
    }


    //�������״̬��ʱ��
    override public void OnEnter()
    {
        // �л���idle״̬
        mActionMachine.ChangeAction(EActionType.BOSSAtk0);

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
                }
                else
                {
                    mTree.ChangeState("AIBOSSAtk1");
                }
            }
            else
            {
                mTree.ChangeState("AIBOSSRun");
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
