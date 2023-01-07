using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSBeHit : BehaviorActionBase//�� ���� ����״̬ ��� ���� 
{

    //���캯��
    public BOSSBeHit(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
         : base(type, am, master, pnt, cld)
    {

    }


    override public void Enter()
    {
        base.Enter();
        //������Ź����ܻ���Ч
        int r = Random.Range(0, 3);
        if (r == 0)
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
        mAt.speed = 1;

        //�л�������idle
        mAt.CrossFade("BeHit", 0.05f);
        mRb.velocity = new Vector3();
        mRb.angularVelocity = new Vector3();
    }


    override public void Exit()
    {
        mAt.speed = 1;

    }

    //�����״̬����
    override public void Update()
    {

    }



    override public void OnAnimationEnd()
    {
        base.OnAnimationEnd();
        mAt.speed = 1;
        //todo
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
