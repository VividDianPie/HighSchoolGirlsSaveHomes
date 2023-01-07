using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//使用导航需要的头文件
public class BOSS : MonoBehaviour//行为条件 死亡事件 碰撞六金刚 动画三金刚 动画运行 判断条件 更新状态
{
    // 动画师
    public Animator At;

    // 刚体
    public Rigidbody Rb;

    protected ActionMachine mAm;
    protected BehaviorTree mBehaviorTree;
    public Transform bangBang { get; set; }
    //对象右手
    public GameObject RightHand;


   

    //NavneshAgent
    public NavMeshAgent Agent;//寻路组件





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
            if (mIsDead)
            {
                mAm.ChangeAction(EActionType.BOSSDie);
                TimerMgr.Instance.OneShot("BOSSDieDelayedDelete", 12f, BOSSDieDelayedDelete);
                //延迟一定的时间产生宝箱和让自己销毁  0.0~1.0之间的随机数
                //TimerMgr.Instance.OneShot((Random.value * 100000).ToString(), 3f, MonsterDieAndCreateBox);
            }
        }
    }
    void BOSSDieDelayedDelete()
    {
        Destroy(this);
        Destroy(this.gameObject);
    }

    void Awake()
    {
        mIsDead = false;
        //状态机
        mAm = new ActionMachine(this.gameObject);
        //种植行为树  
        mBehaviorTree = new BehaviorTree(this.gameObject, mAm, null);
        //生成行为树根
        AIBOSSIdle root = new AIBOSSIdle(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And);
        //播种行为树种
        mBehaviorTree.BehaviorOfTreeSpecies(root);
        //行为树开始生长
        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIBOSSIdle(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIBOSSRun(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIBOSSBnanaJump(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIBOSSAtk0(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIBOSSAtk1(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));

       mBehaviorTree.AddChild(mBehaviorTree.Root, new AIBOSSBeHit(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));

       mBehaviorTree.AddChild(mBehaviorTree.Root, new AIBOSSDie(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));


        //Monster
        mAm.AddAction(new BOSSIdle(EActionType.BOSSIdle, mAm, this.gameObject));

        mAm.AddAction(new BOSSRun(EActionType.BOSSRun, mAm, this.gameObject));

        mAm.AddAction(new BOSSBnanaJump(EActionType.BOSSBnanaJump, mAm, this.gameObject));

        mAm.AddAction(new BOSSAtk0(EActionType.BOSSAtk0, mAm, this.gameObject));

        mAm.AddAction(new BOSSAtk1(EActionType.BOSSAtk1, mAm, this.gameObject));

        mAm.AddAction(new BOSSAtk1(EActionType.BOSSAtk1, mAm, this.gameObject));

        mAm.AddAction(new BOSSBeHit(EActionType.BOSSBeHit, mAm, this.gameObject));

        mAm.AddAction(new BOSSDie(EActionType.BOSSDie, mAm, this.gameObject));




        //加载 Bangbang
        bangBang = GameObject.Instantiate(Resources.Load<Transform>("Prefab/Bangbang"));
        bangBang.parent = RightHand.transform;
        bangBang.transform.localPosition = RightHand.transform.localPosition;
        bangBang.localPosition = new Vector3(0.003f, 0.0055f, 0.005f);
        bangBang.localRotation = Quaternion.Euler(27.492f, -85.569f, 91.641f);
        bangBang.localScale = new Vector3(0.003866859f, 0.005604669f, 0.003866859f);
    }


    void Start()
    {
        //AI行为的Enter
        mBehaviorTree.OnEnter();
    }

    static bool bossAinSpeed=true;
    void Update()
    {
        mAm.Update();

        //角色死亡AI就没有必要更新
        if (mIsDead == false)
        {
            //判断条件更新状态
            mBehaviorTree.Update();
        }


        //if (Input.GetKeyDown(KeyCode.Keypad1))
        //{
        //    bossAinSpeed = !bossAinSpeed;
        //}
        //if (bossAinSpeed == false)
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
        mBehaviorTree.OnCollisionEnter(collision);
    }


    public void OnCollisionStay(Collision collision)
    {
        mBehaviorTree.OnCollisionStay(collision);
    }


    public void OnCollisionExit(Collision collision)
    {
        mBehaviorTree.OnCollisionExit(collision);
    }

    virtual public void OnTriggerEnter(Collider other)
    {
        mBehaviorTree.OnTriggerEnter(other);
    }

    virtual public void OnTriggerStay(Collider other)
    {
        mBehaviorTree.OnTriggerStay(other);
    }


    virtual public void OnTriggerExit(Collider other)
    {
        mBehaviorTree.OnTriggerExit(other);
    }

    //死亡产生宝箱
    public void MonsterDieAndCreateBox()
    {
        Vector3 pos = gameObject.transform.position;

        //让本游戏物体立即消失
        GameObject.Destroy(this.gameObject, 6f);

        //产生宝箱
        GameObject obj = Resources.Load<GameObject>("Prefab/Bangbang");
        obj = GameObject.Instantiate<GameObject>(obj);
        pos.y += 0.5f;
        obj.transform.position = pos;
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
            //mAm.ChangeAction(EActionType.MosnterWalk);
            return true;
        }
        return false;
    }
     

}
