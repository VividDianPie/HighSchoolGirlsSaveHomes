using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBeHit1 : ActionState//角色站立 运行按键切状态 动画三金刚
{
    public HeroBeHit1(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
        : base(type, am, master, pnt, cld)
    {
    }
    bool anima1stage;
    override public void Enter()
    {
        mAt.CrossFade("BeHit1", 0.05f);
        //归零刚体速度 角速度
        mRb.velocity = new Vector3();
        mRb.angularVelocity = new Vector3();
        anima1stage = false;
        //受伤扣血
        HeroData.Instance.heroHp -= 30;
        SoundMgr.Instance.PlayEffect("Music/EffectMusic/挺疼的");
        Hero0.天殛之境_裁决.localPosition = new Vector3(-0.009f, 0.072f, -0.031f);
        Hero0.天殛之境_裁决.localRotation = Quaternion.Euler(79.554f, 39.207f, 139.686f);
    }


    override public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            mAm.ChangeAction(EActionType.SkillE);
        }
        if (anima1stage == true)
        {
            float ph = Input.GetAxis("Horizontal");
            float pv = Input.GetAxis("Vertical");
            // 转向 并 切换为移动状态
            if (pv != 0 || ph != 0f)
            {
                mAm.ChangeAction(EActionType.Run);//方向控制键有动作 切移动状态
            }
            if (Input.GetMouseButtonDown(0))
            {
                mAm.ChangeAction(EActionType.Attack0);
            }
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
        mAm.ChangeAction(EActionType.Idle);
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
        if (other.tag == "Bangbang")
        {
            mAm.ChangeAction(EActionType.BeHit);
        }
    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }

    override public void Anima1stage()
    {
        anima1stage = true;
    }

}
