using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMachine //状态类 添加 删除 切换 运行 进入 退出 开始 结束 攻击帧判定 与 碰撞三大金刚
{
    //动作机主人
    GameObject mMaster;

    //当前动作状态
    ActionState mCurrent;

    //动作状态容器<字典>
    Dictionary<EActionType, ActionState> mActs;


    public ActionState Current
    {
        get
        {
            return mCurrent;
        }
    }

    //构造
    public ActionMachine(GameObject master)
    {
        mMaster = master;
        mCurrent = null;
        mActs = new Dictionary<EActionType, ActionState>();
    }


    //添加动作状态    第一次则初始状态
    public bool AddAction(ActionState action)
    {
        //判重复
        if (mActs.ContainsKey(action.Type))
        {
            return false;
        }

        mActs.Add(action.Type, action);

        if (mCurrent == null)
        {
            mCurrent = action;
            mCurrent.Enter();
        }

        return true;
    }


    ////删除指定状态
    //public bool DeleteAction(EActionType type)
    //{
    //    if (!mActs.ContainsKey(type))
    //    {
    //        return false;
    //    }
    //    //如果删除的是当前动画状态
    //    if (mCurrent == mActs[type])
    //    {
    //        mCurrent.Exit();
    //    }
    //    //于字典中删除对应的状态
    //    mActs.Remove(type);

    //    //当前状态为字典中的首个状态
    //    EActionType[] keys = new EActionType[mActs.Keys.Count];
    //    mActs.Keys.CopyTo(keys, 0);
    //    mCurrent = mActs[keys[0]];

    //    return true;
    //}


    //切换状态
    public bool ChangeAction(EActionType type)
    {
        if (!mActs.ContainsKey(type))
        {
            return false;
        }

        //当前状态退出
        mCurrent.Exit();

        //新状态进入
        mCurrent = mActs[type];
        mCurrent.Enter();
      
        return true;
    }



    //当前状态进入
    virtual public void Enter()
    {
        mCurrent.Enter();
    }


    //当前状态运行
    virtual public void Update()
    {
        if (mCurrent != null)
        {
            mCurrent.Update();
        }
    }


    //当前状态退出
    virtual public void Exit()
    {
        mCurrent.Exit();
    }


    //动画开始
    virtual public void OnAnimationStart()
    {
        mCurrent.OnAnimationStart();
    }


    //动画攻击判定
    virtual public void OnAnimationHit(int i)
    {
        mCurrent.OnAnimationHit(i);
    }


    //动作动画结束
    virtual public void OnAnimationEnd()
    {
        mCurrent.OnAnimationEnd();
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




    virtual public void Anima1stage()
    {
        mCurrent.Anima1stage();
    }

    virtual public void Anima2stage()
    {
        mCurrent.Anima2stage();
    }

}
