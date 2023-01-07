using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//行为树
public class BehaviorTree //管理 添加 删除子节点 进入 运行（条件切换）退出 切换（子状态）根状态切换
{

    //如何表示这棵数 (行为树根)
    BehaviorState mRoot;

    //当前状态
    BehaviorState mCurrent;


    //所属的游戏对象
    GameObject mMaster;


    //动作状态管理器
    ActionMachine mAm;


    //保存所有的子树 （随时切换状态 随时切换根状态）
    List<BehaviorState> mAll;



    public BehaviorState Root
    {
        get
        {
            return mRoot;
        }
    }


    public BehaviorState Current
    {
        get
        {
            return mCurrent;
        }
    }


    public GameObject Master
    {
        get
        {
            return mMaster;
        }
    }


    public ActionMachine Am
    {
        get
        {
            return mAm;
        }
    }


    //构造函数
    public BehaviorTree(GameObject master, ActionMachine am, BehaviorState root)
    {
        mCurrent = null;
        mAll = new List<BehaviorState>();

        mMaster = master;
        mAm = am;
        //mRoot = root;

        //if (root == null)
        //{
        //    throw new Exception("BehaviorTree root is null!");
        //}
        //else
        //{
        //    mAll.Add(root);
        //    mCurrent = root;
        //}
    }


    //添加子节点
    public bool AddChild(BehaviorState parentRoot, BehaviorState c)
    {
        if (parentRoot == null || c == null || !mAll.Contains(parentRoot) || mAll.Contains(c))
        {
            return false;
        }
        //添加子节点
        parentRoot.AddChild(c);
        //子节点挂载于父节点
        c.Parent = parentRoot;
        //添加至子树链表
        mAll.Add(c);

        return true;
    }


    ////删除子节点
    //public bool DltChild(BehaviorState c)
    //{
    //    if (c == null || !mAll.Contains(c))
    //    {
    //        return false;
    //    }

    //    c.Parent.DltChild(c);
    //    mAll.Remove(c);

    //    return true;

    //}

    //刚进入这个状态的时候
    public void OnEnter()
    {
        Current.OnEnter();
    }

    //更新的时候
    public void Update()
    {
        Current.Update();

        //判断哪个子状态的条件是满足
        if (Current.Children.Count == 0)
        {
            int i;
            i = 10;
        }

        for (int i = 0; i < Current.Children.Count; i++)
        {
            //某一个子状态条件满足，进入子条件
            if (Current.Children[i].Condition.Result()) 
            {
                //当前状态退出
                Current.OnExit();

                //新状态进入(子状态)
                Current.Children[i].OnEnter();

                //子状态设置为当前状态
                mCurrent = Current.Children[i];
                break;
            }
        }
    }

    //状态退出的时候
    public void OnExit()
    {
        Current.OnExit();
    }

    //切换子状态
    public bool ChangeState(string stateName)
    {
        BehaviorState bs = null;
        //遍历所有子树
        for (int i = 0; i < mAll.Count; i++)
        {
            //找到当前状态并赋值 (类名于状态名相等)
            if (mAll[i].GetType().Name.Equals(stateName))
            {
                bs = mAll[i];
            }
        }

        if (bs == null)
        {
            return false;
        }
        //当前状态退出
        Current.OnExit();
        //新状态进入
        bs.OnEnter();
        mCurrent = bs;

        return false;
    }


    //切换根状态（idle为根）
    public void ChangeToRoot()
    {
        //当前状态退出
        Current.OnExit();

        //新状态进入
        mRoot.OnEnter();

        //设置为当前状态
        mCurrent = mRoot;
    }

    //碰撞开始
    virtual public void OnCollisionEnter(Collision collision)
    {
        mCurrent.OnCollisionEnter(collision);
    }


    //持续碰撞
    virtual public void OnCollisionStay(Collision collision)
    {
        mCurrent.OnCollisionStay(collision);
    }


    //碰撞退出时
    virtual public void OnCollisionExit(Collision collision)
    {
        mCurrent.OnCollisionExit(collision);
    }

    //触发器
    virtual public void OnTriggerEnter(Collider other)
    {
        mCurrent.OnTriggerEnter(other);
    }

    virtual public void OnTriggerStay(Collider other)
    {
        mCurrent.OnTriggerStay(other);
    }


    virtual public void OnTriggerExit(Collider other)
    {
        mCurrent.OnTriggerExit(other);
    }

    //行为树种
    public void BehaviorOfTreeSpecies(BehaviorState root)
    {
        mRoot = root;
        if (root == null)
        {
            throw new Exception("BehaviorTree root is null!");
        }
        else
        {
            mAll.Add(root);
            mCurrent = root;
        }
    }



}
