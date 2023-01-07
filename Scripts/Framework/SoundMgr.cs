using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr//���� ������Ч ��ͣ ����
{
    //����
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

    //��ȡ��Ϸ�� �������� �� ��Ч AudioSource
    AudioSource mBkg;
    AudioSource mEffect;

    SoundMgr()
    {
        mBkg = null;
        mEffect = null;
    }


    public void Set(GameObject effObj = null)
    {
        //UI���ڵ���AudioSource���ű�������
        if (mBkg == null)
        {
            //��ui���ڵ��ϼ�����Դ���
            mBkg = GameManager.Instance.UIRoot.GetComponent<AudioSource>();
        }

        //��Ч��Ӧ���ڹؿ�����
        if (effObj != null)
        {
            //���ؿ����������Ч
            mEffect = effObj.AddComponent<AudioSource>();
        }
        else
        {
            //����Ϸ���ڵ��������Դ
            mEffect = GameManager.Instance.GameRoot.AddComponent<AudioSource>();
        }

        mBkg.volume = GameCfgMgr.Instance.MusicOn ? 0.5f : 0f;//����  ��ʼ ���� ��Ч ����
        mEffect.volume = GameCfgMgr.Instance.EffectOn ? 0.3f : 0f;
    }


    //�������֣������ǰ���ڲ������л���
    public bool PlayMusic(string musPath)
    {

        AudioClip ac = Resources.Load<AudioClip>(musPath);
        if (ac == null)
        {
            return false;
        }
        //��ǰ������ͣ
        mBkg.Stop();
        //�л�����
        mBkg.clip = ac;
        //��ǰ���ֲ���
        mBkg.Play();

        return true;
    }


    //��ͣ��������
    public void Pause()
    {
        mBkg.Pause();
    }


    //�ָ�����
    public void Resume()
    {
        mBkg.UnPause();
    }

    //����
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
    //�жϵ�ǰ�Ƿ񲥷�����
    public bool IsPlayMusic()
    {
        return mBkg.isPlaying;
    }

    //������Ч
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

    //��Ч����
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
