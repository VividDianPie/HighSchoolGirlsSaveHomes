using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour//按键弹出背包
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //监听按键弹出背包                                 //检测背包Ui无处于最上层
        if (Input.GetKeyDown(KeyCode.B) && !GameManager.Instance.CheckIsTop("BagPopup"))
        {
            GameManager.Instance.LoadUI("Prefab/Uis/BagPopup");
        }
    }
}
