using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero0 : MonoBehaviour
{
    //角色动画师
    public Animator At;
    //角色刚体
    public Rigidbody Rb;
    //角色状态机
    protected ActionMachine mAm;
    //对象右手
    public GameObject RightHand;
    //天殛之境-裁决
    static public Transform 天殛之境_裁决 { get; set; }
    static public Transform heroActor { get; set; }
    void Awake()
    {
        heroActor = this.transform;
        //状态机绑定当前角色
        mAm = new ActionMachine(this.gameObject);
        //加载 天殛之境-裁决
        天殛之境_裁决 = GameObject.Instantiate(Resources.Load<Transform>("Prefab/DayElectricityThisKey"));
        天殛之境_裁决.parent = RightHand.transform;
        天殛之境_裁决.transform.localPosition = RightHand.transform.localPosition;
        天殛之境_裁决.localPosition = new Vector3(-0.009f, 0.072f, -0.031f);
        天殛之境_裁决.localRotation = Quaternion.Euler(79.554f, 39.207f, 139.686f);
        天殛之境_裁决.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }


    void Start()
    {
        //添加角色动作
        mAm.AddAction(new HeroIdle(EActionType.Idle, mAm, this.gameObject));
        mAm.AddAction(new HeroRun(EActionType.Run, mAm, this.gameObject));
        mAm.AddAction(new HeroJump(EActionType.Jump, mAm, this.gameObject));
        mAm.AddAction(new HeroJump1(EActionType.Jump1, mAm, this.gameObject));
        mAm.AddAction(new HeroFly(EActionType.Fly, mAm, this.gameObject));
        mAm.AddAction(new HeroEvade(EActionType.Evade, mAm, this.gameObject));
        mAm.AddAction(new HeroEvadeToAttack(EActionType.EvadeToAttack, mAm, this.gameObject));
        mAm.AddAction(new HeroAttack0(EActionType.Attack0, mAm, this.gameObject));
        mAm.AddAction(new HeroAttack1(EActionType.Attack1, mAm, this.gameObject));
        mAm.AddAction(new HeroAttack2(EActionType.Attack2, mAm, this.gameObject));
        mAm.AddAction(new HeroAttack3(EActionType.Attack3, mAm, this.gameObject));
        mAm.AddAction(new HeroBeHit(EActionType.BeHit, mAm, this.gameObject));
        mAm.AddAction(new HeroBeHit1(EActionType.BeHit1, mAm, this.gameObject));
        mAm.AddAction(new HeroBigSkill(EActionType.BigSkill, mAm, this.gameObject));
        mAm.AddAction(new HeroSkillE(EActionType.SkillE, mAm, this.gameObject));


    }
    static bool heroAinSpeed=true;
    //角色运行中
    void Update()
    {
        //运行当前状态
        mAm.Update();

        //if (Input.GetKeyDown(KeyCode.Keypad0))
        //{
        //    heroAinSpeed = !heroAinSpeed;
        //}
        //if (heroAinSpeed==false)
        //{
        //    At.speed = 0;
        //}
        //else { At.speed = 1; }


    }



    public void OnAnimationStart()
    {
        mAm.OnAnimationStart();
    }



    public void OnAnimationHit(int i)
    {
        mAm.OnAnimationHit(i);
    }



    public void OnAnimationEnd()
    {
        mAm.OnAnimationEnd();
    }

        

    public void OnCollisionEnter(Collision collision)
    {
        mAm.OnCollisionEnter(collision);
    }



    public void OnCollisionStay(Collision collision)
    {
        mAm.OnCollisionStay(collision);
    }



    public void OnCollisionExit(Collision collision)
    {
        mAm.OnCollisionExit(collision);
    }

    //触发器
    public void OnTriggerEnter(Collider other)
    {
        mAm.OnTriggerEnter(other);
    }

    public void OnTriggerStay(Collider other)
    {
        mAm.OnTriggerStay(other);
    }


    public void OnTriggerExit(Collider other)
    {
        mAm.OnTriggerExit(other);
    }



    public void Anima1stage()
    {
        mAm.Anima1stage();
    }

    public void Anima2stage()
    {
        mAm.Anima2stage();
    }
}
