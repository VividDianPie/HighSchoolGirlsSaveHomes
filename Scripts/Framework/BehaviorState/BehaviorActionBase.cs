using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//行为动作基础
public class BehaviorActionBase: ActionState//覆写了 进入状态 与 动画结束 这两个函数分别控制 mIsStateFinish 的真假
{

    public bool StateFinish
    {
        get
        {
            return mIsStateFinish;
        }
    }

    //状态完成
    bool mIsStateFinish;


    public BehaviorActionBase(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
        :base(type, am, master, pnt, cld)
    {
        mIsStateFinish = false;
    }

    //进入状态 
    override public void Enter()
    {
        //状态完成 假
        mIsStateFinish = false;
    }
    //退出这个状态
    override public void Exit()
    {
        //状态完成 真
        mIsStateFinish = true;
    }
    //动画结束 
    override public void OnAnimationEnd()
    {
        //状态完成 真
        mIsStateFinish = true;
    }
}
