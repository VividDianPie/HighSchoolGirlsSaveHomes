using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Monster0 : MonoBehaviour//行为条件 死亡事件 碰撞六金刚 动画三金刚 动画运行 判断条件 更新状态
{
    //怪物动画师
    public Animator At;

    //怪物刚体
    public Rigidbody Rb;
    //血条
    public GameObject healthBar;

    protected ActionMachine mAm;
    protected BehaviorTree mBehaviorTree;
    public Transform bangBang { get; set; }
    //对象右手
    public GameObject RightHand;
    static int goOut50Monster;

    //true表示死 false活着
    protected bool mIsDead;
    public bool IsDead
    {
        get
        {
            return mIsDead;
        }
        set
        {
            mIsDead = value;
            if (mIsDead == true)
            {
                //mAm.ChangeAction(EActionType.MonsterDie);

                //延迟一定的时间产生宝箱和让自己销毁   
                Debug.Log(DateTime.Now.Ticks.ToString());
                //TimerMgr.Instance.OneShot(DateTime.Now.Ticks.ToString(), 3f, MonsterDieAndCreateBox);
                MonsterDieAndCreateBox();
            }
        }
    }


    void Awake()
    {
        mIsDead = false;
        //状态机
        mAm = new ActionMachine(this.gameObject);
        //种植行为树  
        mBehaviorTree = new BehaviorTree(this.gameObject, mAm, null);
        //生成行为树根
        AIMstIdle root = new AIMstIdle(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And);
        //播种行为树种
        mBehaviorTree.BehaviorOfTreeSpecies(root);
        //行为树开始生长
        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIMstIdle(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIMstIdle1(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIMstAttack(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And, IsHeroCloseTo));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIMstAttack1(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And, null));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIMstWalk(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And, MonsterWalkIsEnd));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIMstBeHit(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And, null));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIMstBeHit1(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And, null));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIMstRun(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And, null));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIMstDie(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And, null));

        //Monster
        mAm.AddAction(new MonsterIdle(EActionType.MonsterIdle, mAm, this.gameObject));

        mAm.AddAction(new MonsterIdle1(EActionType.MonsterIdle1, mAm, this.gameObject));

        mAm.AddAction(new MonsterAttack(EActionType.MosnterAttack, mAm, this.gameObject));

        mAm.AddAction(new MonsterAttack1(EActionType.MosnterAttack1, mAm, this.gameObject));

        mAm.AddAction(new MonsterWalk(EActionType.MosnterWalk, mAm, this.gameObject));

        mAm.AddAction(new MonsterDie(EActionType.MonsterDie, mAm, this.gameObject));

        mAm.AddAction(new MosnterBeHit(EActionType.MosnterBeHit, mAm, this.gameObject));

        mAm.AddAction(new MosnterBeHit1(EActionType.MosnterBeHit1, mAm, this.gameObject));

        mAm.AddAction(new MonsterRun(EActionType.MosnterRun, mAm, this.gameObject));


        //加载 Bangbang
        bangBang = GameObject.Instantiate(Resources.Load<Transform>("Prefab/Bangbang"));
        bangBang.parent = RightHand.transform;
        bangBang.transform.localPosition = RightHand.transform.localPosition;
        bangBang.localPosition = new Vector3(0.091f, 0.005f, -0.152f);
        bangBang.localRotation = Quaternion.Euler(-75.233f, 124.862f, -120.967f);
        //bangBang.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }


    void Start()
    {
        //AI行为的Enter
        mBehaviorTree.OnEnter();
    }

    static bool mosterAinSpeed=true;
    void Update()
    {
        mAm.Update();

        //角色死亡AI就没有必要更新
        if (mIsDead == false)
        {
            //判断条件更新状态
            mBehaviorTree.Update();
        }
        //限制怪物总数
        GameObject[] monsters0 = GameObject.FindGameObjectsWithTag("Monster");
        if (monsters0.Length <= 200 && FlyMachine.FlyMachineActive == true)
        {
            TimerMgr.Instance.OneShot("MonsterMultiply", 2f, MonsterMultiply);
        }
        //test
      // FlyMachine.FlyMachineActive = false;
        ///飞机坠毁生成50只怪物
        if (FlyMachine.FlyMachineActive == false)
        {
            for (int i = 0; (i < 50) && (goOut50Monster < 50); i++)
            {
                goOut50Monster += 1;
                MonsterMultiply();
            }
            
        }
        //怪物下界则死
        float y = this.gameObject.transform.position.y;
        if (y < -60)
        {
            Destroy(this.gameObject);
        }
        //变色棒棒
        //TimerMgr.Instance.Repeated("ChangeBangbangColour", 1f, ChangeBangbangColour);




        //if (Input.GetKeyDown(KeyCode.Keypad2))
        //{
        //    mosterAinSpeed = !mosterAinSpeed;
        //}
        //if (mosterAinSpeed == false)
        //{
        //    At.speed = 0;
        //}
        //else { At.speed = 1; }

    }
    //怪物延迟繁殖
    void MonsterMultiply()
    {

        GameObject monsters = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefab/Monster"));
        //GameObjectmonsters = GameObject.Instantiate<GameObject>(this.gameObject);
        monsters.transform.position = new Vector3(FlyMachine.flyMachinePos.x, FlyMachine.flyMachinePos.y + 1, FlyMachine.flyMachinePos.z);
       // monsters.transform.position = Hero0.heroActor.position;
        monsters.SetActive(true);


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
        //mAm.OnCollisionEnter(collision);
        mBehaviorTree.OnCollisionEnter(collision);
    }


    public void OnCollisionStay(Collision collision)
    {
        // mAm.OnCollisionStay(collision);
        mBehaviorTree.OnCollisionStay(collision);
    }


    public void OnCollisionExit(Collision collision)
    {
        //mAm.OnCollisionExit(collision);
        mBehaviorTree.OnCollisionExit(collision);
    }

    virtual public void OnTriggerEnter(Collider other)
    {
        //mAm.OnTriggerEnter(other);
        mBehaviorTree.OnTriggerEnter(other);
    }

    virtual public void OnTriggerStay(Collider other)
    {
        //mAm.OnTriggerStay(other);
        mBehaviorTree.OnTriggerStay(other);
    }


    virtual public void OnTriggerExit(Collider other)
    {
        //mAm.OnTriggerExit(other);
        mBehaviorTree.OnTriggerExit(other);
    }

    //死亡产生宝箱
    public void MonsterDieAndCreateBox()
    {
        if (gameObject == null)
        {
            return;
        }
        Vector3 pos = gameObject.transform.position;



        //产生宝箱
        GameObject obj = Resources.Load<GameObject>("Prefab/魂妖刀_血樱寂灭");
        obj = GameObject.Instantiate<GameObject>(obj);
        obj.transform.rotation = Quaternion.Euler(0f, 0f, 30f);
        pos.y += 0.5f;
        obj.transform.position = pos;

        //让本游戏物体消失
        GameObject.Destroy(this.gameObject, 8f);
        //Destroy(this);
    }



    //行为条件函数
    public bool IsHeroCloseTo()
    {
        //搜索目标
        GameObject heroObj = GameObject.FindGameObjectWithTag("Hero");
        //测距
        float disToHero = Vector3.Distance(gameObject.transform.position, heroObj.transform.position);
        if (disToHero < 1.5f)
        {
            return true;
        }
        return false;
    }




    bool MonsterWalkIsEnd()
    {

        //判断当前的动作状态结束
        if ((mAm.Current as BehaviorActionBase).StateFinish == true)
        {
            mAm.ChangeAction(EActionType.MosnterWalk);
            return true;
        }
        return false;
    }

    bool AiMstBeHitTest()
    {

        return true;
    }

    //变色
    void ChangeBangbangColour()
    {
        if (bangBang == true)
        {
          //  bangBang.GetChild(0).GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}
