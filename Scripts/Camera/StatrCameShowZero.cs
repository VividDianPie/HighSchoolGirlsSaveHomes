using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatrCameShowZero : MonoBehaviour
{
    void Start()
    {
        TimerMgr.Instance.OneShot("ChangeMusic", 0.1f, ChangeMusic);
    }

    void Update()
    {

    }
    public void OnButtonDow()
    {
        this.gameObject.GetComponent<StatrCameShowOne>().enabled = true;
        Destroy(GameObject.FindWithTag("GameStatrButton"));
        Destroy(this);
    }

    void ChangeMusic()
    {
        PlayMusic.Instance.ChangeMusic(0);
    }

}
