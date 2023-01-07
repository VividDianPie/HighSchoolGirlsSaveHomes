using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (GameManager.Instance.GetTopUI() == null)
            {
                this.gameObject.GetComponent<CinemachineBrain>().enabled = true;
            }
            else
            {
                this.gameObject.GetComponent<CinemachineBrain>().enabled = false;
            }
        }
        if (GameManager.Instance.GetTopUI() == null)
        {
            this.gameObject.GetComponent<CinemachineBrain>().enabled = true;
        }
    }
}
