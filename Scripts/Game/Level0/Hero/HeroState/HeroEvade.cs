using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroEvade : ActionState//角色攻击切动画 退出切idle 攻击判定
{

    //动画一阶段是否结束
    //bool anima1stageIsEnd;
    bool theDerivedAttack;
    public HeroEvade(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
    : base(type, am, master, pnt, cld)
    {

    }


    override public void Enter()
    {
        mAt.Play("Evade");
        //mAt.CrossFade("Evade", 0.05f);
        // anima1stageIsEnd = false;
        HeroData.Instance.anima1stageIsEndHeroEvadeexclusive = false;
        theDerivedAttack = false;


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
        SoundMgr.Instance.PlayEffect("Music/EffectMusic/HeroEvade-剪辑-20220104152953");

    }


    override public void Update()
    {
        //AnimatorStateInfo stateInfo = mAt.GetCurrentAnimatorStateInfo(0);
        //float f = HeroDate.Instance.GetClipLength(mAt, "Evade");
        if (Input.GetMouseButtonDown(0))
        {
            theDerivedAttack = true;
        }
        if (HeroData.Instance.anima1stageIsEndHeroEvadeexclusive == true)
        {
            if (theDerivedAttack == true)
            {
                mAm.ChangeAction(EActionType.EvadeToAttack);
                theDerivedAttack = false;
                return;
            }
            mRb.velocity = new Vector3();
            float ph = Input.GetAxis("Horizontal");
            float pv = Input.GetAxis("Vertical");
            // 转向 并 切换为移动状态
            if (Input.GetMouseButtonDown(0))
            {
                mAm.ChangeAction(EActionType.EvadeToAttack);
            }
            else if (pv != 0 || ph != 0f)
            {
                mAm.ChangeAction(EActionType.Run);
                return;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                mAm.ChangeAction(EActionType.Jump);
            }
        }
        else
        {
            RaycastHit hitinfo;
            bool isCollider = Physics.Raycast(mMaster.transform.position + Vector3.up * 0.5f, mMaster.transform.forward, out hitinfo,0.5f); 
            if (isCollider == false) 
            {
                mMaster.transform.position += mMaster.transform.forward * HeroData.Instance.evadeSpeed * Time.deltaTime;
            }
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
        mAm.ChangeAction(EActionType.Idle);
    }

    override public void Anima1stage()
    {
        // anima1stageIsEnd = true;
        HeroData.Instance.anima1stageIsEndHeroEvadeexclusive = true;
    }
    override public void Anima2stage()
    {

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


