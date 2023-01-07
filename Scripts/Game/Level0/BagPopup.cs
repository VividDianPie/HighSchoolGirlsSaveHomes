using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


class BagEvtData
{
    public int id;
    public int count;
    //�����¼�����
    public BagEvtData(int id, int count)
    {
        this.id = id;
        this.count = count;
    }
}

//��������
public class BagPopup : MonoBehaviour 
{

    //ʹ�ð�ť
    public Button UseBtn;

    //scroll content
    public GameObject Content;

    //ItemSelectCtrl
    public GameObject SelectCtrl;

    //��ǰѡ�е���Ʒ
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
            //ʹ����Ʒ
            BagSystem.Instance.AddItem(mSelectItem, -1);
            if (mSelectItem == 1001)//�����췣
            {
                Destroy(Hero0.����֮��_�þ�.gameObject);
                Hero0.����֮��_�þ� = GameObject.Instantiate(Resources.Load<Transform>("Prefab/DayElectricityThisKey"));
                Hero0.����֮��_�þ�.parent = Hero0.heroActor.gameObject.GetComponent<Hero0>().RightHand.transform;
                Hero0.����֮��_�þ�.transform.localPosition = Hero0.heroActor.gameObject.GetComponent<Hero0>().RightHand.transform.localPosition;
                Hero0.����֮��_�þ�.localPosition = new Vector3(-0.009f, 0.072f, -0.031f);
                Hero0.����֮��_�þ�.localRotation = Quaternion.Euler(79.554f, 39.207f, 139.686f);
                Hero0.����֮��_�þ�.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
            else if (mSelectItem == 1002)//ԡѪ��ӣ
            {
                Destroy(Hero0.����֮��_�þ�.gameObject);

                Hero0.����֮��_�þ� = GameObject.Instantiate(Resources.Load<Transform>("Prefab/������_Ѫӣ����"));
                Hero0.����֮��_�þ�.parent = Hero0.heroActor.gameObject.GetComponent<Hero0>().RightHand.transform;
                Hero0.����֮��_�þ�.transform.localPosition = Hero0.heroActor.gameObject.GetComponent<Hero0>().RightHand.transform.localPosition;
                Hero0.����֮��_�þ�.localPosition = new Vector3(-0.009f, 0.072f, -0.031f);
                Hero0.����֮��_�þ�.localRotation = Quaternion.Euler(79.554f, 39.207f, 139.686f);
                Hero0.����֮��_�þ�.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
            else if (mSelectItem == 1003)//�ڽ���
            {
                HeroData.Instance.heroHp += 100;
                if (HeroData.Instance.heroHp >= HeroData.Instance.heroMaxHp)
                {
                    HeroData.Instance.heroHp = HeroData.Instance.heroMaxHp;
                }
            }

            //ˢ�±���
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

    //�жϱ��������Ƿ�ɽ���
    void RefreshUseBtn()
    {
        //interactable �Ƿ�ɽ���
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
        //��ȡ����������
        Dictionary<int, int> items = BagSystem.Instance.Items;
        //�жϱ����Ƿ��е�ǰ����
        if (!items.ContainsKey(mSelectItem))
        {
            //������Ϊ���ɽ���
            mSelectItem = -1;
            RefreshUseBtn();
        }

        //ˢ�½���
        RectTransform rt = Content.GetComponent<RectTransform>();
        //��� RectTransform
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

    //��ѡ��������
    public void OnBagItemSelect(Event evt)
    {
        BagEvtData bed = evt.data as BagEvtData;
        if (bed != null)
        {
            //�õ�����������
            mSelectItem = bed.id;
            RefreshUseBtn();
        }
    }
}
