using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AI��idle
public class AIMstIdle1 : BehaviorState//���� ����ilde״̬ ��idle״̬ ����ʱѭ���в�ͬidle״̬
{

    //���ι���
    public AIMstIdle1(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {

    }


    //idle�������״̬��ʱ��
    override public void OnEnter()
    {
        //�����л���idle״̬
        mActionMachine.ChangeAction(EActionType.MonsterIdle1);

        //�ȵ�������

    }



    //����idle���µ�ʱ��
    override public void Update()
    {
        ////�ɻ�׹��ȫ����ﱩŭ
        if (FlyMachine.FlyMachineActive == false)
        {
            mMaster.GetComponent<MonsterData>().monsterAnger = true;
        }

        //�жϵ�ǰ�Ķ���״̬����
        if ((mActionMachine.Current as BehaviorActionBase).StateFinish == true)
        {
            if (mMaster.GetComponent<MonsterData>().monsterAnger == true)
            {
                mTree.ChangeState("AIMstRun");
            }
            else
            {
                mTree.ChangeState("AIMstWalk");
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
}
