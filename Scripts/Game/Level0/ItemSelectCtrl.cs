using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Config;

//装备选择控制
public class ItemSelectCtrl : MonoBehaviour//按键拾取道具 显示道具信息
{

    //图标
    public Image Icon;

    //名字
    public Text Name;

    //数量
    public Text Count;

    //物品配置信息
    protected Item mCfg;
    protected int mCount;

    //是否已经拾取
    //protected bool mFlag;


    protected void Awake()
    {
        mCfg = null;
        mCount = -1;
        //mFlag = false;
    }


    protected void Start()
    {

    }


    protected void Update()
    {
        
    }


    //点击按钮添加物品至背包
    public void OnSelectBtn()
    {
        if (mCount > 0 /*&& !mFlag*/)
        {
            BagSystem.Instance.AddItem(mCfg.Id, mCount);
            //mFlag = true;
        }
    }

    //获得道具的详细信息并显示
    public void SetData(int id, int count)
    {
        mCfg = ItemHelp.Instance.Find(id);
        mCount = count;
        Refresh();
    }


    public void Refresh()
    {
        if (mCfg != null)
        {
            //显示物品的名字
            Name.text = mCfg.Name;

            //显示物品的数量
            Count.text = mCount.ToString();

            //显示物品的图标
            Sprite sp = Resources.Load<Sprite>("Pic/" + mCfg.Icon);
            Icon.sprite = sp;
        }
    }
}
