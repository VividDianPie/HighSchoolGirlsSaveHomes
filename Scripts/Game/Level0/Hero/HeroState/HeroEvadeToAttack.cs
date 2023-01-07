//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Assets.Scripts.Game.Level0.Hero
//{
//    class HeroEvadeToAttack
//    {
//    }
//}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroEvadeToAttack : ActionState//角色跳跃动画 遭遇碰撞切动画idle
{
    bool anima1stageIsEnd;
    bool atkLoop;
    public HeroEvadeToAttack(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
    : base(type, am, master, pnt, cld)
    {

    }


    override public void Enter()
    {
        //mAt.CrossFade("EvadeToAttack", 0.05f);
        mAt.Play("EvadeToAttack");

        //动画速度正常
        mAt.speed = 1f;

        anima1stageIsEnd = false;
        atkLoop = false;


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
        SoundMgr.Instance.PlayEffect("Music/EffectMusic/HeroAtk4");
        mRb.velocity = new Vector3();
        mRb.angularVelocity = new Vector3();
    }


    override public void Update()
    {
        if (atkLoop == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mAm.ChangeAction(EActionType.Attack0);
            }
            else if(Input.GetMouseButtonDown(1))
            {
                mAm.ChangeAction(EActionType.Evade);
            }
        }
        if (anima1stageIsEnd == false)
        {
            mMaster.transform.position += mMaster.transform.forward * HeroData.Instance.evadeAtkSpeed * Time.deltaTime;
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
        TimerMgr.Instance.OneShot("天殛之境_裁决CapsuleColliderInActivity", 1f, 天殛之境_裁决CapsuleColliderInActivity);
    }
    void 天殛之境_裁决CapsuleColliderInActivity()
    {
        Hero0.天殛之境_裁决.GetComponent<CapsuleCollider>().enabled = false;
    }


    override public void OnAnimationEnd()
    {
        mAm.ChangeAction(EActionType.Idle);
        mAt.speed = 1f;
    }


    override public void OnCollisionEnter(Collision collision)
    {
    }
    override public void Anima1stage()
    {
        anima1stageIsEnd = true;
    }

    override public void Anima2stage()
    {
        atkLoop = true;
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


