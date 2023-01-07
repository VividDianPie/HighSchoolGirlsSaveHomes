using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//行为状态
public class BehaviorState//管理 (初始化 父 子 obj 状态机 条件 行为树）添加删除子状态 添加 删除子条件       状态进入运行退出（可能会被覆写）
{

    //父节点
    protected BehaviorState mParent;


    //子节点 （以树的生命流向形式 遍历子树 顺序遍历）
    protected List<BehaviorState> mChildren;


    //所属游戏物体
    protected GameObject mMaster;


    //状态机
    protected ActionMachine mActionMachine;


    //进入本状态的条件
    protected BehaviorCondition mCondition;


    //行为树
    public BehaviorTree mTree;


    public BehaviorState Parent
    {
        get
        {
            return mParent;
        }
        set
        {
            mParent = value;
        }
    }


    public List<BehaviorState> Children
    {
        get
        {
            return mChildren;
        }
    }


    public BehaviorCondition Condition
    {
        get
        {
            return mCondition;
        }
    }


    //构造函数
    public BehaviorState(GameObject master, ActionMachine am, BehaviorTree tree, BehaviorCondition.EType type,
        Func<bool> cdn = null,
        BehaviorState parent = null)
    {
        mMaster = master;
        mActionMachine = am;
        mParent = parent;

        mTree = tree;

        mChildren = new List<BehaviorState>();
        mCondition = new BehaviorCondition(type, cdn);
    }


    //添加状态
    public bool AddChild(BehaviorState child)
    {
        //判重复
        if (mChildren.LastIndexOf(child) >= 0)
        {
            return false;
        }

        mChildren.Add(child);

        return true;
    }


    ////删除子状态
    //public bool DltChild(BehaviorState child)
    //{
    //    //判重复
    //    int index = mChildren.LastIndexOf(child);
    //    if (index < 0)
    //    {
    //        return false;
    //    }
    //    //传入对应下标 删除 链表中的 BehaviorState
    //    mChildren.RemoveAt(index);

    //    return true;
    //}


    //添加子条件(封装)
    public bool AddSub(Func<bool> cdn)
    {
        return mCondition.AddSub(cdn);
    }


    //删除子条件(行为条件中)（封装）
    public bool DltSub(Func<bool> cdn)
    {
        return mCondition.DltSub(cdn);
    }


    //刚进入这个状态的时候
    virtual public void OnEnter()
    {

    }



    //更新的时候
    virtual public void Update()
    {

    }



    //状态退出的时候
    virtual public void OnExit()
    {

    }


    //碰撞开始
    virtual public void OnCollisionEnter(Collision collision)
    {

    }


    //持续碰撞
    virtual public void OnCollisionStay(Collision collision)
    {

    }


    //碰撞退出时
    virtual public void OnCollisionExit(Collision collision)
    {

    }

    //触发器
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
