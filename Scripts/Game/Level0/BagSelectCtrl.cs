using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//����ѡ�����
public class BagSelectCtrl : ItemSelectCtrl    //��ӱ���ѡ��ť�¼�
{
    //��ӱ���ѡ��ť�¼�
    new public void OnSelectBtn()
    {
        EventManager.Instance.DispatchEvent(new Event(EEventType.BagItemSelect, new BagEvtData(mCfg.Id, mCount)));
    }
}
