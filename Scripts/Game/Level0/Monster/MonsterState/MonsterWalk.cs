using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWalk : BehaviorActionBase//��վ������ ����״̬ ��� ���� 
{

    //���캯��
    public MonsterWalk(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
         : base(type, am, master, pnt, cld)
    {

    }


    override public void Enter()
    {
        base.Enter();

        //�л�������idle
        mAt.CrossFade("Walk", 0.05f);
    }


    override public void Exit()
    {


    }

    //�����״̬����
    override public void Update()
    {

    }



    override public void OnAnimationEnd()
    {
        base.OnAnimationEnd();

        //todo
    }


    //��ײ��ʼ��ʱ��
    override public void OnCollisionEnter(Collision collision)
    {
        Collision test = collision;
        int i = 1;
    }


    //��ײ������ʱ��
    override public void OnCollisionStay(Collision collision)
    {

    }   


    //��ײ������ʱ��
    override public void OnCollisionExit(Collision collision)
    {

    }

    //������
    override public void OnTriggerEnter(Collider other)
    {
        //mAm.ChangeAction(EActionType.MosnterBeHit);
    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }

}