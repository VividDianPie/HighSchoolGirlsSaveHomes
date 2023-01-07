using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//最基础的类（可能会被继承）
public class ActionState//管理 状态 进入 退出 动画 开始 与 退出  碰撞相关 与状态运行（可能会被覆写）
{


    //父节点
    protected ActionState mParent;

    //子节点
    protected ActionState mChild;

    //状态的类型
    protected EActionType mType;

    //所属游戏物体
    protected GameObject mMaster;

    //所属游戏物体 动画控制器
    protected Animator mAt;
   
    //所属游戏物体 刚体
    protected Rigidbody mRb;

    //角色状态机
    protected ActionMachine mAm;


    public ActionState Parent
    {
        get
        {
            return mParent;
        }
        protected set
        {
            mParent = value;
        }
    }


    public ActionState Child
    {
        get
        {
            return mChild;
        }
        protected set
        {
            mChild = value;
        }
    }


    public EActionType Type
    {
        get
        {
            return mType;
        }
        protected set
        {
            mType = value;
        }
    }


    //构造
    public ActionState(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
    {
        mType = type;
        mAm = am;
        mMaster = master;
        Parent = pnt;
        Child = cld;
        mRb = mMaster.GetComponent<Rigidbody>();
        mAt = mMaster.GetComponent<Animator>();

    
    }


    //进入状态
    virtual public void Enter()
    {

    }


    //在这个状态运行
    virtual public void Update()
    {
       
    }


    //退出这个状态
    virtual public void Exit()
    {

    }


    //动画开始
    virtual public void OnAnimationStart()
    {

    }


    //攻击动作点
    virtual public void OnAnimationHit(int i)
    {

    }


    //动画结束
    virtual public void OnAnimationEnd()
    {
        
    }


    //碰撞开始的时候
    virtual public void OnCollisionEnter(Collision collision)
    {

    }


    //碰撞持续的时候
    virtual public void OnCollisionStay(Collision collision)
    {

    }


    //碰撞结束的时候
    virtual public void OnCollisionExit(Collision collision)
    {

    }

    virtual public void Anima1stage()
    {
     
    }

    virtual public void Anima2stage()
    {

    }

    virtual public void OnTriggerEnter(Collider other)
    { 
    
    }

    virtual public void OnTriggerStay(Collider other)
    {

    }


    virtual public void OnTriggerExit(Collider other)
    {

    }




}

