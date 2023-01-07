using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//行为条件
public class BehaviorCondition 
{
    //与类型  或类型
    public enum EType
    {
        And,
        Or,
    }


    //我自己条件的类型
    EType mType;


    //子条件 //无参 返回值为bool的函数指针
    List<Func<bool>> mSubConditions;


    //构造函数
    public BehaviorCondition(EType type, Func<bool> cdn = null)
    {
        mType = type;
        mSubConditions = new List<Func<bool>>();

        if (cdn != null)
        {
            mSubConditions.Add(cdn);
        }
    }


    //添加子条件
    public bool AddSub(Func<bool> cdn)
    {
        //判重复
        if (mSubConditions.Contains(cdn))
        {
            return false;
        }

        mSubConditions.Add(cdn);

        return true;
    }


    //删除子条件
    public bool DltSub(Func<bool> cdn)
    {
        //判空
        int index = mSubConditions.LastIndexOf(cdn);
        if (index < 0)
        {
            return false;
        }
        
        mSubConditions.RemoveAt(index);

        return true;
    }


    //得到条件的结果
    public bool Result()
    {

        if(mSubConditions.Count == 0)
        {
            return false;
        }

        //bool ret = mType == EType.And ? true : false;
        bool ret = false;
        if (mType == EType.And)
        {
            ret = true;
        }
        else if (mType == EType.Or)
        {
            ret = false;
        }
        for (int i = 0; i < mSubConditions.Count; i++)
        {
            if (mType == EType.And)
            {
                ret = ret && mSubConditions[i]();
            }
            else
            {
                ret = ret || mSubConditions[i]();
            }
        }

        return ret;
    }
}
