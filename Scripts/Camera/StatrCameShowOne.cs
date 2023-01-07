using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatrCameShowOne : MonoBehaviour
{
    void Start()
    {
        this.gameObject.transform.position = new Vector3(FlyMachine.flyMachinePos.x, FlyMachine.flyMachinePos.y+35, FlyMachine.flyMachinePos.z) ;
        TimerMgr.Instance.OneShot("ChangeCameTwo", 8f, ChangeCameTwo);
    }

    void Update()
    {
        this.gameObject.transform.LookAt(FlyMachine.flyMachinePos);
    }

    public void ChangeCameTwo()
    {
        this.gameObject.GetComponent<StatrCameShowTwo>().enabled = true;
        Destroy(this);
    }
}
