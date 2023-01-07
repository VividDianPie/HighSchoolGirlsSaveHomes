//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using Config;


//public class TalkUI : MonoBehaviour
//{
//    //设置需要操作的控件
//    public Image LeftHead;
//    public Image RightHead;
//    public Text Txt;


//    //对话数据
//    TalkChapter mTalk;

//    //对话显示需要的缓冲的字符串
//    string mTalkStr;


//    void Awake()
//    {
//        mTalk = null;
//        mTalkStr = null;
//    }


//    void Start()
//    {
//        //test
//        SetChapter("Chapter0");
//        //test
//    }

    
//    void Update()
//    {
        
//    }


//    public void SetChapter(string cn)
//    {
//        mTalk = new TalkChapter(cn);

//        //播放第一句对话
//        Refresh();
//    }


//    public void Refresh()
//    {
//        Talk tl = mTalk.Current();
//        if (tl != null)
//        {
//            //刷新对话文字
//            //Txt.text = tl.Text;
//            if (mTalkStr == null)
//            {
//                int i = tl.Text.IndexOf(":");
//                mTalkStr = tl.Text.Substring(0, i + 1);

//                //启动定时器
//                TimerMgr.Instance.Repeated("feowihfuieb3862478", 1f / 3, TimerCall);
//            }

//            Txt.text = mTalkStr;

//            //刷新对话头像
//            Sprite sp = null;
//            if (tl.UseSide == 1)
//            {
//                LeftHead.gameObject.SetActive(true);
//                RightHead.gameObject.SetActive(false);

//                sp = Resources.Load<Sprite>("Pics/" + tl.LeftHead);
//                LeftHead.sprite = sp;
//            }
//            else
//            {
//                LeftHead.gameObject.SetActive(false);
//                RightHead.gameObject.SetActive(true);

//                sp = Resources.Load<Sprite>("Pics/" + tl.RightHead);
//                RightHead.sprite = sp;
//            }
//        }
//    }


//    public void OnBgClick()
//    {
//        Talk tl = mTalk.Current();
//        if (mTalkStr.Length < tl.Text.Length)
//        {
//            mTalkStr = tl.Text;
//            Txt.text = mTalkStr;
//            TimerMgr.Instance.DeleteTimer("feowihfuieb3862478");
//        }
//        else
//        { 
//            mTalkStr = null;
//            mTalk.Next();
//            Refresh();
//        }
//    }


//    public void TimerCall()
//    {
//        Talk tl = mTalk.Current();
//        if (mTalkStr != null && mTalkStr.Length < tl.Text.Length)
//        {
//            mTalkStr = tl.Text.Substring(0, mTalkStr.Length + 1);
//            Txt.text = mTalkStr;
//        }
//        else
//        {
//            TimerMgr.Instance.DeleteTimer("feowihfuieb3862478");
//        }
//    }
//}
