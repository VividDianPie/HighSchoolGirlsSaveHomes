using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ����֮��_�þ�TurnLeft : MonoBehaviour
{
    float ����֮��_�þ�_EulerY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ����֮��_�þ�_EulerY += 10f;
        gameObject.transform.localRotation = Quaternion.Euler(0f, ����֮��_�þ�_EulerY, 90f);
    }
}
