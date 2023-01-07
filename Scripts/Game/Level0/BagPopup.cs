using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


class BagEvtData
{
    public int id;
    public int count;
    //背包事件数据
    public BagEvtData(int id, int count)
    {
        this.id = id;
        this.count = count;
    }
}

//背包弹出
public class BagPopup : MonoBehaviour 
{

    //使用按钮
    public Button UseBtn;

    //scroll content
    public GameObject Content;

    //ItemSelectCtrl
    public GameObject SelectCtrl;

    //当前选中的物品
    int mSelectItem;


    void Awake()
    {
        EventManager.Instance.AddListener(EEventType.BagItemSelect, OnBagItemSelect);
    }


    void OnDestroy()
    {
        EventManager.Instance.DeleteListener(EEventType.BagItemSelect, OnBagItemSelect);
    }


    void Start()
    {
        mSelectItem = -1;
        RefreshUseBtn();
        RefreshView();
    }

    
    void Update()
    {
        
    }


    public void OnUseBtn()
    {
        if (mSelectItem > 0)
        {
            //使用物品
            BagSystem.Instance.AddItem(mSelectItem, -1);
            if (mSelectItem == 1001)//罪雷天罚
            {
                Destroy(Hero0.天殛之境_裁决.gameObject);
                Hero0.天殛之境_裁决 = GameObject.Instantiate(Resources.Load<Transform>("Prefab/DayElectricityThisKey"));
                Hero0.天殛之境_裁决.parent = Hero0.heroActor.gameObject.GetComponent<Hero0>().RightHand.transform;
                Hero0.天殛之境_裁决.transform.localPosition = Hero0.heroActor.gameObject.GetComponent<Hero0>().RightHand.transform.localPosition;
                Hero0.天殛之境_裁决.localPosition = new Vector3(-0.009f, 0.072f, -0.031f);
                Hero0.天殛之境_裁决.localRotation = Quaternion.Euler(79.554f, 39.207f, 139.686f);
                Hero0.天殛之境_裁决.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
            else if (mSelectItem == 1002)//浴血狂樱
            {
                Destroy(Hero0.天殛之境_裁决.gameObject);

                Hero0.天殛之境_裁决 = GameObject.Instantiate(Resources.Load<Transform>("Prefab/魂妖刀_血樱寂灭"));
                Hero0.天殛之境_裁决.parent = Hero0.heroActor.gameObject.GetComponent<Hero0>().RightHand.transform;
                Hero0.天殛之境_裁决.transform.localPosition = Hero0.heroActor.gameObject.GetComponent<Hero0>().RightHand.transform.localPosition;
                Hero0.天殛之境_裁决.localPosition = new Vector3(-0.009f, 0.072f, -0.031f);
                Hero0.天殛之境_裁决.localRotation = Quaternion.Euler(79.554f, 39.207f, 139.686f);
                Hero0.天殛之境_裁决.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
            else if (mSelectItem == 1003)//口嚼酒
            {
                HeroData.Instance.heroHp += 100;
                if (HeroData.Instance.heroHp >= HeroData.Instance.heroMaxHp)
                {
                    HeroData.Instance.heroHp = HeroData.Instance.heroMaxHp;
                }
            }

            //刷新背包
            RefreshView();
        }
    }


    public void OnBg()
    {
        mSelectItem = -1;
        RefreshUseBtn();
    }


    public void OnCloseBtn()
    {
        GameManager.Instance.RemoveUI(gameObject);
    }

    //判断背包道具是否可交互
    void RefreshUseBtn()
    {
        //interactable 是否可交互
        if (mSelectItem >= 0)
        {
            UseBtn.interactable = true;
        }
        else
        {
            UseBtn.interactable = false;
        }
    }


    void RefreshView()
    {
        //获取背包的数据
        Dictionary<int, int> items = BagSystem.Instance.Items;
        //判断背包是否有当前道具
        if (!items.ContainsKey(mSelectItem))
        {
            //设置其为不可交互
            mSelectItem = -1;
            RefreshUseBtn();
        }

        //刷新界面
        RectTransform rt = Content.GetComponent<RectTransform>();
        //清空 RectTransform
        for (int i = 0; i < rt.childCount; i++)
        {
            GameObject.Destroy(rt.GetChild(i).gameObject);
        }
        
        foreach(var kv in items)
        {

            for (int i = 0; i < kv.Value; i++)
            {
                GameObject isc = GameObject.Instantiate<GameObject>(SelectCtrl);
                isc.SetActive(true);
                isc.GetComponent<RectTransform>().SetParent(rt);
                ItemSelectCtrl isccc = isc.GetComponent<ItemSelectCtrl>();
                isccc.SetData(kv.Key,1 /*kv.Value*/);
            }

          
        }
    }

    //挑选背包道具
    public void OnBagItemSelect(Event evt)
    {
        BagEvtData bed = evt.data as BagEvtData;
        if (bed != null)
        {
            //得到背包道具名
            mSelectItem = bed.id;
            RefreshUseBtn();
        }
    }
}
