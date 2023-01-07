using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//AI��idle
public class AIBOSSBeHit : BehaviorState//����  ilde״̬ ��idle״̬ ����ʱѭ���в�ͬidle״̬
{
    //���ι���
    public AIBOSSBeHit(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {
    }


    //idle�������״̬��ʱ��
    override public void OnEnter()
    {
        mMaster.GetComponent<MonsterData>().BOSSHp -= HeroData.Instance.heroAd;
        //BOSS�����ж�
        if (mMaster.GetComponent<MonsterData>().BOSSHp <= 0)
        {
            mMaster.GetComponent<MonsterData>().BOSSHp = 0;
            mMaster.GetComponent<BOSS>().IsDead = true;
            return;
        }
        // �л���idle״̬
        mActionMachine.ChangeAction(EActionType.BOSSBeHit);

        //�ȵ�������

    }
  


    //����idle���µ�ʱ��
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

    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }
}
