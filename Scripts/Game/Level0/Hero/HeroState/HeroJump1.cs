


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroJump1 : ActionState//��ɫ��Ծ���� ������ײ�ж���idle
{
    public HeroJump1(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
    : base(type, am, master, pnt, cld)
    {

    }


    override public void Enter()
    {
        //mAt.Play("Jump");
        mAt.CrossFade("Jump1", 0.05f);
        //��Ӹ������Ϸ������
        mRb.velocity = mRb.velocity + new Vector3(0f, HeroData.Instance.jumpPower, 0f);
        //�����ٶ�����
        mAt.speed = 1.6f;
    }


    override public void Update()
    {
        float ph = Input.GetAxis("Horizontal");
        float pv = Input.GetAxis("Vertical");
        if (ph != 0 || pv != 0f)
        {
            Vector3 hv = new Vector3(ph, 0f, pv);
            mRb.transform.forward = hv.normalized;
            // ��ת�����������
            Vector3 CamForward = Camera.main.transform.forward;
            CamForward.y = 0;
            float angle = Vector3.Angle(CamForward, Vector3.forward);
            if (CamForward.x < 0)
            {
                angle = -angle;
            }
            mRb.transform.Rotate(Vector3.up, angle);
            mMaster.transform.position += mMaster.transform.forward * HeroData.Instance.jumpMoveSpeed * Time.deltaTime;
        }



    }

    override public void Exit()
    {
        //�����˳� ���ö����ٶ�
        mAt.speed = 1f;
    }


    override public void OnAnimationStart()
    {

    }



    override public void OnAnimationHit(int i)
    {

    }



    override public void OnAnimationEnd()
    {
        mAm.ChangeAction(EActionType.Fly);
        mAt.speed = 1f;
    }


    override public void OnCollisionEnter(Collision collision)
    {
        //������ײ�ж���idle
        mAm.ChangeAction(EActionType.Idle);
        mAt.speed = 1f;
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
