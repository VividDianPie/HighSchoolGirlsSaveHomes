using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFly : ActionState
{
    public HeroFly(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
    : base(type, am, master, pnt, cld)
    {

    }


    override public void Enter()
    {
        mAt.CrossFade("Fly", 0.05f);
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
            mMaster.transform.position += mMaster.transform.forward * HeroData.Instance.FlyMoveSpeed * Time.deltaTime;
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
        
      
 
    }



    override public void OnAnimationEnd()
    {
    }

    override public void OnCollisionEnter(Collision collision)
    {
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
