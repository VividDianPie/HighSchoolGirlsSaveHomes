using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//选择道具弹出窗口
public class ItemSelectPopup : MonoBehaviour//添加物品 刷新物品ui显示界面 关闭ui 清空物品
{

    //用来挂在选择小物件
    public RectTransform Content;//目录

    //选择物品空间的模版
    public GameObject ItemSelectCtrl;

    //key:物品id value:数量
    Dictionary<int, int> mItems;


    void Awake()
    {
        mItems = new Dictionary<int, int>();
    }


    void Start()
    {

    }


    void Update()
    {

    }


    //添加物品 
    public void AddItem(int id, int count)
    {
        //判重复
        if (mItems.ContainsKey(id))
        {
            return;
        }
        //添加至道具字典
        mItems.Add(id, count);
        //刷新
        Refresh();
    }

    //清空背包
    public void ClearView()
    {
        int c = Content.childCount;
        for (int i = 0; i < c; i++)
        {
            GameObject.Destroy(Content.GetChild(i).gameObject);
        }

        mItems.Clear();
    }


    //刷新界面
    public void Refresh()
    {
        //清空Content目录
        int c = Content.childCount;
        for (int i = 0; i < c; i++)
        {
            GameObject.Destroy(Content.GetChild(i).gameObject);
        }

        //克隆我们上面ItemSelectCtrlTmp挂在到Content
        foreach (var kv in mItems)
        {
            //复制游戏物体
            GameObject isc = GameObject.Instantiate<GameObject>(ItemSelectCtrl);

            //把游戏物体设置激活状态
            isc.SetActive(true);

            //挂在到content
            isc.GetComponent<RectTransform>().SetParent(Content);

            //取下ItemSelectCtrl设置id和数量
            ItemSelectCtrl isccs = isc.GetComponent<ItemSelectCtrl>();
            //获得道具的详细信息并显示
            isccs.SetData(kv.Key, kv.Value);
        }
    }


    //按键关闭Ui显示
    public void OnCloseBtn()
    {
        GameManager.Instance.RemoveUI(this.gameObject);
    }

   
}
