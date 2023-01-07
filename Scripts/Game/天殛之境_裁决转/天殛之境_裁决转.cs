using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 天殛之境_裁决转 : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 15);
    }

    void Update()
    {
        gameObject.transform.position = Hero0.heroActor.position + new Vector3(-0.009f, 1.016f, 0.1128f);
        gameObject.transform.Rotate(Vector3.up, Time.deltaTime * 500,Space.World);
    }
}
