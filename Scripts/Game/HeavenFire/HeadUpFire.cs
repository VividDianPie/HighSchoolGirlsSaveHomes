using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadUpFire : MonoBehaviour
{
    void Start()
    {   
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TimerMgr.Instance.OneShot("ChangeScripts", 0.1f, ChangeScripts);//定时器yyds！！！
        }
            

        GameObject.FindWithTag("HeavenFireBig").transform.forward = Camera.main.transform.forward;
        if (Input.GetKey(KeyCode.F))
        {
            TimerMgr.Instance.OneShot("PlayMusicEffectAndFire", 0.1f, PlayMusicEffectAndFire);
        }


    }

    void PlayMusicEffectAndFire()
    {

        GameObject bullets = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefab/Bullet"));
        bullets.transform.position = GameObject.FindWithTag("FirePoint").transform.position;

        SoundMgr.Instance.PlayEffect("Music/EffectMusic/加农炮1_爱给网_aigei_com");

    }

    void ChangeScripts()
    {
        this.gameObject.GetComponent<HeadUpFire>().enabled = false;
        this.gameObject.GetComponent<HeavenFire>().enabled = true;
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        this.gameObject.transform.parent.SetParent(null);
    }
}
