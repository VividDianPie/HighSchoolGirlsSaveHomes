using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour//加载 初始化ui根节点 游戏场景根节点 游戏音量初始化 运行监听者 消费事件 调用定时器
{
    //ui根节点
    GameObject mUIRoot;
    //游戏根节点
    GameObject mGameRoot;
  
    void Start()
    {
        mUIRoot = GameObject.Find("UI");
        mGameRoot = GameObject.Find("Game");

        //初始化ui根节点 游戏根节点
        GameManager.Instance.init(mUIRoot, mGameRoot);

        //切换场景时不销毁ui
        GameObject.DontDestroyOnLoad(mUIRoot);

        //加载存档
        GameCfgMgr ins = GameCfgMgr.Instance;

        //加载音乐设置初始音量
        SoundMgr.Instance.Set();


        //初始化物品配置
         ItemHelp ih = ItemHelp.Instance;

    }


    void Update()
    {
        //调用监听函数
        EventManager.Instance.Update();
        //调用定时器
        TimerMgr.Instance.Update();
        //播放音乐控制
        PlayMusic.Instance.Run();
    }




}
