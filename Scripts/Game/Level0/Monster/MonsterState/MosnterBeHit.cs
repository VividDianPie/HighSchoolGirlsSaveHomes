using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosnterBeHit : BehaviorActionBase//��վ������ ����״̬ ��� ���� 
{

    //���캯��
    public MosnterBeHit(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
         : base(type, am, master, pnt, cld)
    {

    }


    override public void Enter()
    {
        base.Enter();
        //������Ź����ܻ���Ч
        int r = Random.Range(0, 3);
        if (r  == 0)
        {
            SoundMgr.Instance.PlayEffect("Music/EffectMusic/MonsterBehit0");
        }
        if (r == 1)
        { 
            SoundMgr.Instance.PlayEffect("Music/EffectMusic/MonsterBehit1");
        }
        if (r == 2)
        { 
            SoundMgr.Instance.PlayEffect("Music/EffectMusic/MonsterBehit2");
        }
        //�л������� 
        mAt.CrossFade("BeHit", 0.05f);
        mRb.velocity = new Vector3();
        mRb.angularVelocity = new Vector3();
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


    }


    //��ײ��ʼ��ʱ��
    override public void OnCollisionEnter(Collision collision)
    {

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
        //mAm.ChangeAction(EActionType.MosnterBeHit1);
    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }

}
