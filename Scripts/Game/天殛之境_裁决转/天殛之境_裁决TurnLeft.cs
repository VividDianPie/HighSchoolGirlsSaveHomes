using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 天殛之境_裁决TurnLeft : MonoBehaviour
{
    float 天殛之境_裁决_EulerY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        天殛之境_裁决_EulerY += 10f;
        gameObject.transform.localRotation = Quaternion.Euler(0f, 天殛之境_裁决_EulerY, 90f);
    }
}
