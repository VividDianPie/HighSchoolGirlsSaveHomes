﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack2 : ActionState//角色攻击切动画 退出切idle 攻击判定
{
    bool whetherTheCombo;
    public HeroAttack2(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
    : base(type, am, master, pnt, cld)
    {

    }


    override public void Enter()
    {
        //mAt.CrossFade("Atk2", 0.05f);
        mAt.Play("Atk2");
        whetherTheCombo = false;


        //切换动作更新朝向
        float ph = Input.GetAxis("Horizontal");
        float pv = Input.GetAxis("Vertical");
        if (ph != 0 || pv != 0f)
        {
            Vector3 hv = new Vector3(ph, 0f, pv);
            mRb.transform.forward = hv.normalized;
            // 旋转到摄像机方向
            Vector3 CamForward = Camera.main.transform.forward;
            CamForward.y = 0;
            float angle = Vector3.Angle(CamForward, Vector3.forward);
            //判断相机x轴朝向象限
            if (CamForward.x < 0)
            {
                angle = -angle;
            }
            mRb.transform.Rotate(Vector3.up, angle);
        }
        SoundMgr.Instance.PlayEffect("Music/EffectMusic/HeroAtk2");
        mRb.velocity = new Vector3();
        mRb.angularVelocity = new Vector3();
    }


    override public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            whetherTheCombo = true;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            mAm.ChangeAction(EActionType.Evade);
        }
    }

    override public void Exit()
    {

    }


    override public void OnAnimationStart()
    {

    }



    override public void OnAnimationHit(int i)
    { 
        //天殛之境_裁决添加攻击帧
        Hero0.天殛之境_裁决.GetComponent<CapsuleCollider>().enabled = true;
        TimerMgr.Instance.OneShot("天殛之境_裁决CapsuleColliderInActivity", 0.3f, 天殛之境_裁决CapsuleColliderInActivity);
    }
    void 天殛之境_裁决CapsuleColliderInActivity()
    {
        Hero0.天殛之境_裁决.GetComponent<CapsuleCollider>().enabled = false;
    }


    override public void OnAnimationEnd()
    {
        mAm.ChangeAction(EActionType.Idle);
    }

    override public void Anima2stage()
    {
        if (whetherTheCombo == true)
        {
            mAm.ChangeAction(EActionType.Attack3);
        }
    }

    //触发器
    override public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bangbang")
        {
            if (Random.Range(0, 1) == 1)
            {
                mAm.ChangeAction(EActionType.BeHit1);
            }
            else
            {
                mAm.ChangeAction(EActionType.BeHit);
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
