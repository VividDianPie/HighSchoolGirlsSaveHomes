using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager//管理 场景 UI 加载与销毁
{
    static GameManager sInstance = null;
    public static GameManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = new GameManager();
            }
            return sInstance;
        }
    }

    //ui根节点
    GameObject mUiRoot;
    //游戏根节点
    GameObject mGameRoot;

    //ui链表
    List<GameObject> mUis;

    //当前场景
    GameObject mCurLevel;

    //构造
    GameManager()
    {
        mUis = new List<GameObject>();
        mCurLevel = null;
    }


    public GameObject UIRoot
    {
        get
        {
            return mUiRoot;
        }
    }


    public GameObject GameRoot
    {
        get
        {
            return mGameRoot;
        }
    }

    //初始化ui根节点 游戏根节点
    public void init(GameObject uiRoot, GameObject gameRoot)
    {
        mUiRoot = uiRoot;
        mGameRoot = gameRoot;

        if (uiRoot == null || gameRoot == null)
        {
            //抛出异常
            throw new System.Exception("GameManager初始化失败!");
        }
    }


    //检测UI是否处于链表最后 （游戏最上层）
    public bool CheckIsTop(string uiName)
    {
        if (mUis.Count > 0 && mUis[mUis.Count - 1].name.StartsWith(uiName))//检测字符串是否以指定的前缀开始
        {
            return true;
        }

        return false;
    }


    //获取UI顶层界面
    public GameObject GetTopUI()
    {
        if (mUis.Count == 0)
        {
            return null;
        }
        return mUis[mUis.Count - 1];
    }


    //从预制体中加载UI资源至UI链表
    public bool LoadUI(string uiPath)
    {
        //获取UI名
        int idx = uiPath.LastIndexOf('/');
        string uiName = uiPath.Substring(idx + 1, uiPath.Length - 1 - idx);

        //检测UI是否处于链表最后 （游戏最上层）
        if (CheckIsTop(uiName))
        {
            return false;
        }

        //加载UI预制体
        GameObject obj = Resources.Load<GameObject>(uiPath);
        obj = GameObject.Instantiate<GameObject>(obj);

        //设置矩形组件
        obj.GetComponent<RectTransform>().SetParent(mUiRoot.transform);
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);

        //加入UI链表
        mUis.Add(obj);
        //UI排序
        obj.GetComponent<Canvas>().sortingOrder = mUis.Count;

        return true;
    }


    //删除最顶层的UI
    public bool RemoveUI(GameObject obj)
    {
        int idx = mUis.IndexOf(obj);
        //判断要删除的UI是否为游戏的最顶层
        if (idx < mUis.Count - 1)
        {
            return false;
        }

        //在UI中删除指定的UI对像
        mUis.RemoveAt(idx);

        //销毁游戏物体
        GameObject.Destroy(obj);

        return true;
    }


    //根据指定名字切换场景
    public bool LoadLevel(string levelPath)
    {
        int idx = levelPath.LastIndexOf('/');
        string levelName = levelPath.Substring(idx + 1, levelPath.Length - 1 - idx);

        if (mCurLevel != null && mCurLevel.name.StartsWith(levelName))//检测字符串是否以指定的前缀开始
        {
            return false;
        }
        //删除当前场景
        RemoveLevel();
        //至预制体中加载场景并设置其根节点为游戏根节点
        GameObject obj = Resources.Load<GameObject>(levelPath);
        obj = GameObject.Instantiate<GameObject>(obj);

        obj.transform.parent = mGameRoot.transform;
        //设置当前场景
        mCurLevel = obj;



        return true;
    }


    //删除当前场景
    public void RemoveLevel()
    {
        if (mCurLevel != null)
        {
            GameObject.Destroy(mCurLevel);
            mCurLevel = null;
        }
    }


}


