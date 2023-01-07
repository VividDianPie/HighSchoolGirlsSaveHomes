using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour//宝箱物品拾起显示至Ui
{

    [Header("要爆的物品ID")]
    public int[] ItemId;

    [Header("要爆的物品的数量")]
    public int[] ItemNumber;


    void Start()
    {

    }


    void Update()
    {

    }
    //退出碰撞关闭Ui
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Hero0>() != null)
        {
            if (GameManager.Instance.GetTopUI() != null)
            {
                GameManager.Instance.RemoveUI(GameManager.Instance.GetTopUI());
            }
        }
    }
    //被碰到的时候
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Hero0>() != null)
        {

            ItemSelectPopup isp = null;
            GameObject ui = null;


            GameManager.Instance.LoadUI("Prefab/Uis/ItemSelectPopup");
            ui = GameManager.Instance.GetTopUI();
            isp = ui.GetComponent<ItemSelectPopup>();


            //宝箱中物品设置到选择界面
            for (int i = 0; i < ItemId.Length; i++)
            {
                isp.AddItem(ItemId[i], ItemNumber[i]);
            }
        }
    }
}
