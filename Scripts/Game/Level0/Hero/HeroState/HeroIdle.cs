using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class HeroIdle : ActionState//角色站立 运行按键切状态 动画三金刚
{
    public HeroIdle(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
        : base(type, am, master, pnt, cld)
    {
        //EventManager.Instance.AddListener(EEventType.JoyStickDown, OnJoyStickDown);
    }
    override public void Enter()
    {
        //mAt.Play("Idle");
        mAt.CrossFade("Idle", 0.05f);
        //归零刚体速度 角速度
        mRb.velocity = new Vector3();
        mRb.angularVelocity = new Vector3();

        Hero0.天殛之境_裁决.localPosition = new Vector3(0.402f, 0.225f, -0.178f);
        Hero0.天殛之境_裁决.localRotation = Quaternion.Euler(40.027f, 88.045f, 29.992f);

    }


    override public void Update()
    {

        //long currentTicks = DateTime.Now.Ticks;
        //Debug.Log("currentTicks"+ DateTime.Now.Ticks);
        //DateTime dtFrom = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        // Debug.Log("dtFrom"+ dtFrom);
        //long currentMillis = (currentTicks - dtFrom.Ticks) / 10000;
        //Debug.Log("currentMillis"+ currentMillis);






        float ph = Input.GetAxis("Horizontal");
        float pv = Input.GetAxis("Vertical");
        // 转向 并 切换为移动状态
        if (pv != 0 || ph != 0f)
        {
            //开场动画禁止移动
            if (PlayMusic.Instance.musicCtrl != 0)
            {
                mAm.ChangeAction(EActionType.Run);//方向控制键有动作 切移动状态
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mAm.ChangeAction(EActionType.Jump);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            mAm.ChangeAction(EActionType.BigSkill);
        }
        else if (Input.GetMouseButtonDown(0) && GameManager.Instance.GetTopUI() == null && PlayMusic.Instance.musicCtrl != 0)
        {
            mAm.ChangeAction(EActionType.Attack0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            mAm.ChangeAction(EActionType.SkillE);
        }
    }


    override public void OnAnimationStart()
    {

    }



    override public void OnAnimationHit(int i)
    {

    }



    override public void OnAnimationEnd()
    {
    }


    public void OnJoyStickDown(Event evt)
    {
        MyVec2 pos = evt.data as MyVec2;
        if (pos != null)
        {
            mAm.ChangeAction(EActionType.Run);
            if (pos.x < 0f)
            {

            }
            else if (pos.x > 0f)
            {

            }
        }
    }

    //触发器
    override public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bangbang" && PlayMusic.Instance.musicCtrl != 0)
        {
            if (UnityEngine.Random.Range(0, 1) == 1)
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
