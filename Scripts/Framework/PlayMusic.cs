using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic
{
    float musicVolume = 0.5f;
    public int musicCtrl = 0;
    //µ¥ÀýÄ£Ê½
    static PlayMusic sInstance;
    public static PlayMusic Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = new PlayMusic();
            }
            return sInstance;
        }
    }


    void MusicVolumeCtrl()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            musicVolume += 0.002f;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            musicVolume -= 0.002f;
        }
        SoundMgr.Instance.MusicVolume = musicVolume;
    }
    void MusicCtrl()
    {

      
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            musicCtrl += 2;
            if (musicCtrl > 16)
            {
                musicCtrl = 2;
            }
            ChangeMusic(musicCtrl);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            musicCtrl -= 2;
            if (musicCtrl < 2)
            {
                musicCtrl = 16;
            }
            ChangeMusic(musicCtrl);
        }

        if(Input.GetKeyUp(KeyCode.RightArrow))
        {

        }
    }
        
    public void ChangeMusic(int i)
    {
        switch (i)
        {
            case 0: SoundMgr.Instance.PlayMusic("Music/ÉñÖ®¼ü¸ó"); break;
            case 2: SoundMgr.Instance.PlayMusic("Music/Moonrise"); break;
            case 4: SoundMgr.Instance.PlayMusic("Music/³ÂÖÂÒÝ,HOYO-MiX - Hanachirusato »ªÉ¢Ö®Ôµ"); break;
            case 6: SoundMgr.Instance.PlayMusic("Music/³ÂÖÂÒÝ,HOYO-MiX - Qilin's Prance ÷ëÔ¾ÓÄÑÒ"); break;
            case 8: SoundMgr.Instance.PlayMusic("Music/The Starlit Past ÐÇÖªÏþµÄ¾ÉÃÎ"); break;
            case 10: SoundMgr.Instance.PlayMusic("Music/Ashen2 - À×µç½«¾üÑÝÊ¾"); break;
            case 12: SoundMgr.Instance.PlayMusic("Music/Clouds"); break;
            case 14: SoundMgr.Instance.PlayMusic("Music/Hakushin's Lullaby ÉñºüµÄ×£¸£"); break;
            case 16: SoundMgr.Instance.PlayMusic("Music/º£Ô¨ÃÔÓ°"); break;

        }
    }

    public void Run()
    {
        GameCfgMgr.Instance.EffectOn = true;
        GameCfgMgr.Instance.MusicOn = true;
        MusicVolumeCtrl();
        MusicCtrl();
    }

}
