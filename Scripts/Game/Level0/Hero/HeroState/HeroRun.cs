using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRun : ActionState//跑运行时按键切状态 动画三金刚（攻击帧）
{
    public HeroRun(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
        : base(type, am, master, pnt, cld)
    {
        //添加 游戏事件监听者 摇杆的按下与拖动
        EventManager.Instance.AddListener(EEventType.JoyStickDown, OnJoyStickDown);
        EventManager.Instance.AddListener(EEventType.JoyStickDrag, OnJoyStickDrag);
    }


    void start()
    {

    }

    override public void Enter()
    {
        mAt.CrossFade("Run", 0.05f);
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
            //判断相机x轴朝向象限
            if (CamForward.x < 0)
            {
                angle = -angle;
            }
            mRb.transform.Rotate(Vector3.up, angle);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                mAm.ChangeAction(EActionType.Jump);
            }
            else if (Input.GetMouseButtonDown(1)/*&& HeroData.Instance.anima1stageIsEndHeroEvadeexclusive==true*/&& HeroData.Instance.isheroEvadeCooling ==false)
            {
                HeroData.Instance.isheroEvadeCooling = true;
                TimerMgr.Instance.OneShot("IsheroEvadeCoolingIsFalse", 0.1f, IsheroEvadeCoolingIsFalse);
                mAm.ChangeAction(EActionType.Evade);
                return;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                mAm.ChangeAction(EActionType.Attack0);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                mAm.ChangeAction(EActionType.SkillE);
            }
            mMaster.transform.position += mMaster.transform.forward * HeroData.Instance.runSpeed * Time.deltaTime;
        }
        else
        {
            mAm.ChangeAction(EActionType.Idle);
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

    }

    override public void Anima1stage()
    {
        SoundMgr.Instance.PlayEffect("Music/EffectMusic/HeroStepLeft");
    }
    override public void Anima2stage()
    {
        SoundMgr.Instance.PlayEffect("Music/EffectMusic/HeroStepRight");
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

    void IsheroEvadeCoolingIsFalse()
    {
        HeroData.Instance.isheroEvadeCooling = false;
    }

    public void OnJoyStickDown(Event evt)
    {
        MyVec2 pos = evt.data as MyVec2;
        if (pos != null)
        {
            mAm.ChangeAction(EActionType.Run);
            if (pos.x < 0f)
            {
                //mMaster.GetComponent<Hero0>().Dir = MoveDir.Left;
            }
            else if (pos.x > 0f)
            {
                //mMaster.GetComponent<Hero0>().Dir = MoveDir.Right;
            }
        }
    }


    public void OnJoyStickDrag(Event evt)
    {
        MyVec2 pos = evt.data as MyVec2;
        if (pos != null)
        {
            if (pos.x > 0f)
            {
                mRb.velocity = mMaster.transform.forward.normalized * 7f;
            }
            else if (pos.x < 0f)
            {
                mRb.velocity = mMaster.transform.forward.normalized * 7f;
            }
        }
    }
}
