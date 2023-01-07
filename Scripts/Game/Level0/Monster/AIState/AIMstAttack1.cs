using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMstAttack1 : BehaviorState//������﹥�� ���뵱ǰ״̬ ����ʱ �ж� �� ״̬
{
    //���ι���
    public AIMstAttack1(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {

    }


    //�ս������״̬��ʱ��
    override public void OnEnter()
    {
        mActionMachine.ChangeAction(EActionType.MosnterAttack1);
    }



    //���µ�ʱ��
    override public void Update()
    {
        //��ǰ���﹥��״̬�����ж�
        if ((mActionMachine.Current as BehaviorActionBase).StateFinish == true)
        {
            if (mMaster.GetComponent< MonsterData >().monsterAnger /*MonsterData.Instance.monsterAnger*/ == false)
            {
                mTree.ChangeToRoot();
                //�����monster�л�״̬�� ��������Ȼ�й���֡�Ļ���ô ʹ��ʧЧ
                if (mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled == true)
                {
                    mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled = false;
                }
            }
            else
            {
                mTree.ChangeState("AIMstRun");
                //�����monster�л�״̬�� ��������Ȼ�й���֡�Ļ���ô ʹ��ʧЧ
                if (mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled == true)
                {
                    mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled = false;
                }
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
            mTree.ChangeState("AIMstBeHit");
            //�����monster�л�״̬�� ��������Ȼ�й���֡�Ļ���ô ʹ��ʧЧ
            if (mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled == true)
            {
                mMaster.GetComponent<Monster0>().bangBang.GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }
}
