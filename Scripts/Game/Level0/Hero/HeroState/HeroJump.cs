using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroJump : ActionState//角色跳跃动画 遭遇碰撞切动画idle
{
    public HeroJump(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
    : base(type, am, master, pnt, cld)
    {

    }


    override public void Enter()
    {
        //mAt.Play("Jump");
        mAt.CrossFade("Jump", 0.05f);
        //添加刚体向上方向的力
        mRb.velocity = mRb.velocity + new Vector3(0f, HeroData.Instance.jumpPower, 0f);
        //动画速度 
        mAt.speed = 1.5f;
        Hero0.天殛之境_裁决.localPosition = new Vector3(-0.009f, 0.072f, -0.031f);
        Hero0.天殛之境_裁决.localRotation = Quaternion.Euler(79.554f, 39.207f, 139.686f);
    }


    override public void Update()
    {
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
            if (CamForward.x < 0)
            {
                angle = -angle;
            }
            mRb.transform.Rotate(Vector3.up, angle);
            mMaster.transform.position += mMaster.transform.forward * HeroData.Instance.jumpMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //跳
            mAm.ChangeAction(EActionType.Jump1);
        }


    }

    override public void Exit()
    {
        //动画退出 重置动画速度
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
        mAt.speed = 1f;
    }


    override public void OnCollisionEnter(Collision collision)
    {
        //遭遇碰撞切动画idle
        mAm.ChangeAction(EActionType.Idle);
        mAt.speed = 1f;
    }

    //触发器
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
