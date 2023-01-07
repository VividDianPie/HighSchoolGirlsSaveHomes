using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour//���� ��ʼ��ui���ڵ� ��Ϸ�������ڵ� ��Ϸ������ʼ�� ���м����� �����¼� ���ö�ʱ��
{
    //ui���ڵ�
    GameObject mUIRoot;
    //��Ϸ���ڵ�
    GameObject mGameRoot;
  
    void Start()
    {
        mUIRoot = GameObject.Find("UI");
        mGameRoot = GameObject.Find("Game");

        //��ʼ��ui���ڵ� ��Ϸ���ڵ�
        GameManager.Instance.init(mUIRoot, mGameRoot);

        //�л�����ʱ������ui
        GameObject.DontDestroyOnLoad(mUIRoot);

        //���ش浵
        GameCfgMgr ins = GameCfgMgr.Instance;

        //�����������ó�ʼ����
        SoundMgr.Instance.Set();


        //��ʼ����Ʒ����
         ItemHelp ih = ItemHelp.Instance;

    }


    void Update()
    {
        //���ü�������
        EventManager.Instance.Update();
        //���ö�ʱ��
        TimerMgr.Instance.Update();
        //�������ֿ���
        PlayMusic.Instance.Run();
    }




}
