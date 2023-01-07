using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//AI��idle
public class AIBOSSIdle : BehaviorState//����  ilde״̬ ��idle״̬ ����ʱѭ���в�ͬidle״̬
{
    //���ι���
    public AIBOSSIdle(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {
    }


    //idle�������״̬��ʱ��
    override public void OnEnter()
    {
        // �л���idle״̬
        mActionMachine.ChangeAction(EActionType.BOSSIdle);

        //�ȵ�������

    }



    //����idle���µ�ʱ��
    override public void Update()
    {

        //�жϵ�ǰ�Ķ���״̬����
        if (MonsterData.BOSSAnger == true)
        {
            mMaster.GetComponent<BOSS>().transform.parent = null;

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
