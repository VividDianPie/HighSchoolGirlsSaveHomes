using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatrCameShowTwo : MonoBehaviour
{
    float statrCameRotationY;
    void Start()
    {
        statrCameRotationY = 99.69f;
        this.gameObject.transform.localPosition = new Vector3(-27.452f, -15.303f, 38.401f);
        this.gameObject.transform.localRotation = Quaternion.Euler(-5.75f, statrCameRotationY, 0f);
        TimerMgr.Instance.OneShot("CameOkStatrGame", 5f, CameOkStatrGame);
    }

    void Update()
    {
        this.gameObject.transform.localRotation = Quaternion.Euler(-5.75f, statrCameRotationY, 0f);
        Invoke("CameTwoRotation", 2f);
    }



    void CameTwoRotation()
    {
        if (statrCameRotationY < 160)
        {
            statrCameRotationY++;
        }
    }


    void CameOkStatrGame()
    {
        //激活第三人称相机
        FindGameObject("virtualCamera").SetActive(true);
        //激活小地图
        GameObject parentObj = GameObject.Find("Canvas");
        GameObject Image = parentObj.transform.Find("Image").gameObject;
        Image.SetActive(true);

        GameObject.FindWithTag("FlyMachine").GetComponent<AudioSource>().enabled = true;
        SoundMgr.Instance.Pause();
        PlayMusic.Instance.musicCtrl = 2;
        Destroy(this);
    }


    public GameObject FindGameObject(string str)
    {
        GameObject instance = new GameObject();
        var all = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject item in all)
        {
            if (item.gameObject.name == str)
            {
                instance = item;
            }
        }
        return instance;
    }
 

}


