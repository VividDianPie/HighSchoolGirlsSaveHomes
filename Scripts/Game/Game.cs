using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour//������������
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //����������������                                 //��ⱳ��Ui�޴������ϲ�
        if (Input.GetKeyDown(KeyCode.B) && !GameManager.Instance.CheckIsTop("BagPopup"))
        {
            GameManager.Instance.LoadUI("Prefab/Uis/BagPopup");
        }
    }
}
