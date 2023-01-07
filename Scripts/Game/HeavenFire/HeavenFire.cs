using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenFire : MonoBehaviour
{
    float heavenFireBig_EulerY;
    bool trigger;
    void Start()
    {
        heavenFireBig_EulerY = 0;
        trigger = false;
    }


    void Update()
    {
        if (trigger == false)
        {
            heavenFireBig_EulerY += 35; 
            GameObject.FindWithTag("HeavenFireBig").transform.localRotation = Quaternion.Euler(279.03f, heavenFireBig_EulerY, -157.756f);
        }
    }

 

    void OnTriggerEnter(Collider other)
    {

        trigger = true;

    }

    void OnTriggerStay(Collider other)
    {


        GameObject.FindWithTag("HeavenFireBig").transform.forward = Camera.main.transform.forward;
        if (Input.GetKey(KeyCode.F))
        {
            TimerMgr.Instance.OneShot("PlayMusicEffect", 0.1f, PlayMusicEffect);
        }




       else if (Input.GetKeyDown(KeyCode.R))
        {
            TimerMgr.Instance.OneShot("ChangeScripts", 0.1f, ChangeScripts);//定时器永远的神！！！
        }
    }

    void ChangeScripts()
    {
        this.gameObject.GetComponent<HeavenFire>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponent<HeadUpFire>().enabled = true;
        this.gameObject.transform.parent.SetParent(Hero0.heroActor);
    }
    void PlayMusicEffect()
    {

        GameObject bullets = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefab/Bullet"));
        bullets.transform.position = GameObject.FindWithTag("FirePoint").transform.position;

        SoundMgr.Instance.PlayEffect("Music/EffectMusic/加农炮1_爱给网_aigei_com");

    }

    void OnTriggerExit(Collider other)
    {


        trigger = false;

    }

}
