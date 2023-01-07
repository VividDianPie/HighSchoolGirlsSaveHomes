using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//背包选择控制
public class BagSelectCtrl : ItemSelectCtrl    //添加背包选择按钮事件
{
    //添加背包选择按钮事件
    new public void OnSelectBtn()
    {
        EventManager.Instance.DispatchEvent(new Event(EEventType.BagItemSelect, new BagEvtData(mCfg.Id, mCount)));
    }
}
