using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AI��idle
public class AIMstWalk : BehaviorState//���� ����ilde״̬ ��idle״̬ ����ʱѭ���в�ͬidle״̬
{

    //���ι���
    public AIMstWalk(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
        : base(master, am, tree, type, cdn, parent)
    {

    }


    override public void OnEnter()
    {
        mActionMachine.ChangeAction(EActionType.MosnterWalk);

        //�ȵ�������

    }



    override public void Update()
    {
        if ((mActionMachine.Current as BehaviorActionBase).StateFinish == true)
        {
            //�л�Ϊ��״̬
            mTree.ChangeToRoot();
        }



        RaycastHit hitinfo;
        bool isCollider = Physics.Raycast(mMaster.transform.position + Vector3.up * 0.5f, mMaster.transform.forward, out hitinfo, 0.5f);
        //ɫ�߼��û����ײ ��ô���ƶ�
        if (isCollider == false)
        {
            mMaster.transform.position = mMaster.transform.position + mMaster.transform.forward * mMaster.GetComponent<MonsterData>().monsterWalkSpeed * Time.deltaTime;
            //Debug.Log(Time.deltaTime);
        }
        else
        {
            float temp = 0.0f;
            if (UnityEngine.Random.value > 0.9f)
            {
                mMaster.transform.forward = -mMaster.transform.forward;
            }
            else
            {
                mMaster.transform.forward = new Vector3(UnityEngine.Random.value, 0, UnityEngine.Random.value);
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
