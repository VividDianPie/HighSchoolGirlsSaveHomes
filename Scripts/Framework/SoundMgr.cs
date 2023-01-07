using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr//加载 播放音效 暂停 音量
{
    //单例
    static SoundMgr sInstance = null;
    public static SoundMgr Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = new SoundMgr();
            }
            return sInstance;
        }
    }

    //获取游戏中 背景音乐 和 音效 AudioSource
    AudioSource mBkg;
    AudioSource mEffect;

    SoundMgr()
    {
        mBkg = null;
        mEffect = null;
    }


    public void Set(GameObject effObj = null)
    {
        //UI根节点上AudioSource播放背景音乐
        if (mBkg == null)
        {
            //至ui根节点上加载声源组件
            mBkg = GameManager.Instance.UIRoot.GetComponent<AudioSource>();
        }

        //音效的应该在关卡里面
        if (effObj != null)
        {
            //至关卡里面加载音效
            mEffect = effObj.AddComponent<AudioSource>();
        }
        else
        {
            //至游戏根节点里加载声源
            mEffect = GameManager.Instance.GameRoot.AddComponent<AudioSource>();
        }

        mBkg.volume = GameCfgMgr.Instance.MusicOn ? 0.5f : 0f;//设置  初始 音乐 音效 音量
        mEffect.volume = GameCfgMgr.Instance.EffectOn ? 0.3f : 0f;
    }


    //播放音乐（如果当前正在播放则切换）
    public bool PlayMusic(string musPath)
    {

        AudioClip ac = Resources.Load<AudioClip>(musPath);
        if (ac == null)
        {
            return false;
        }
        //当前音乐暂停
        mBkg.Stop();
        //切换音乐
        mBkg.clip = ac;
        //当前音乐播放
        mBkg.Play();

        return true;
    }


    //暂停播放音乐
    public void Pause()
    {
        mBkg.Pause();
    }


    //恢复播放
    public void Resume()
    {
        mBkg.UnPause();
    }

    //音量
    public float MusicVolume
    {
        get
        {
            return mBkg.volume;
        }
        set
        {
            mBkg.volume = value;
        }
    }
    //判断当前是否播放音乐
    public bool IsPlayMusic()
    {
        return mBkg.isPlaying;
    }

    //播放音效
    public bool PlayEffect(string musPath)
    {
        AudioClip ac = Resources.Load<AudioClip>(musPath);
        if (ac == null)
        {
            return false;
        }

        mEffect.PlayOneShot(ac);

        return true;
    }

    //音效音量
    public float EffectVolume
    {
        get
        {
            return mEffect.volume;
        }
        set
        {
            mEffect.volume = value;
        }
    }
}
