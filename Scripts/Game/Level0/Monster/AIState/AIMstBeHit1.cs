using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AI�� 
public class AIMstBeHit1 : BehaviorState
{

    //���ι���
    public AIMstBeHit1(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {

    }


    // �������״̬��ʱ��
    override public void OnEnter()
    {
        mMaster.GetComponent<Monster0>().healthBar.SetActive(true);

        //�����л��� 
        mActionMachine.ChangeAction(EActionType.MosnterBeHit1);
        //��ŭ����  
        mMaster.GetComponent<MonsterData>().monsterAnger = true;
        mMaster.GetComponent<MonsterData>().monsterHp -= HeroData.Instance.heroAd;
        if (mMaster.GetComponent<MonsterData>().monsterHp <= 0)
        {
            mMaster.GetComponent<Monster0>().healthBar.SetActive(false);

            //������ײ��ʧЧ
            mMaster.GetComponent<CapsuleCollider>().enabled = false;

            mMaster.GetComponent<MonsterData>().monsterHp = 0;
            mMaster.GetComponent<Monster0>().IsDead = true;
            mTree.ChangeState("AIMstDie");
        }

        //�ȵ�������

    }



    //����idle���µ�ʱ��
    override public void Update()
    {
        //�жϵ�ǰ�Ķ���״̬����
        if ((mActionMachine.Current as BehaviorActionBase).StateFinish == true)
        {
            if (mMaster.GetComponent<MonsterData>().monsterAnger == false)
            {
                mTree.ChangeToRoot();
            }
            else
            {
                mTree.ChangeState("AIMstRun");
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
