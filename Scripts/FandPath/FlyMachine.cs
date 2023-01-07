using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMachine : MonoBehaviour
{
    public float flyMachineHp;
    public float Speed;
    public GameObject myObj;
    public List<GameObject> WayPoints;
    List<Vector3> mPoints;
    float mDis;
    static public Vector3 flyMachinePos;

    static public bool FlyMachineActive;
    private void Awake()
    {
        FlyMachineActive = true;
        flyMachineHp = 1;
        flyMachinePos = myObj.transform.position;
    }
    void Start()
    {
        mDis = 0;
        mPoints = new List<Vector3>();
        for (int i = 0; i < WayPoints.Count; i++)
        {
            mPoints.Add(WayPoints[i].transform.position);
        }
        //角色坐标为链表首个点坐标
        myObj.transform.position = GetStartPoint();
    }


    float GetDistance(int index)
    {
        float ret = 0;
        if (index == 0)
        {
            return 0f;
        }

        for (int i = 1; i <= index; i++)
        {
            ret += (mPoints[i] - mPoints[i - 1]).magnitude;
        }

        return ret;
    }


    public float GetPoints(float dis, ref Vector3 start, ref Vector3 end) 
    {
        int bigger = 0;
        for (int i = 0; i < mPoints.Count; i++)
        {
            if (GetDistance(i) > dis)
            {
                bigger = i;
                break;
            }
        }
     
        end = mPoints[bigger];//找到当前对象正处的前后两个点
        start = mPoints[bigger - 1];

        return dis - GetDistance(bigger - 1);//当前对象距离上一个经过的点走出了多远
    }


    public Vector3 GetPoint(float dis)
    {
        Vector3 start = new Vector3();
        Vector3 end = new Vector3();
        float ds = GetPoints(dis, ref start, ref end);
        Vector3 dir = (end - start).normalized;
        transform.forward = dir;//物体朝向为移动方向

        return start + dir * ds;
    }


    public Vector3 GetStartPoint()
    {
        return mPoints[0];
    }

        
    void Update()
    {
        mDis += Speed * Time.deltaTime;
        //越界限制
        //Debug.Log(mDis);
        if (mDis >= 880f)
        {
            mDis = 880f;
        }
        Vector3 pos = GetPoint(mDis);
        myObj.transform.position = pos;
        //抛出飞机坐标
        flyMachinePos = myObj.transform.position;

        TimerMgr.Instance.Repeated("MakeZero", 117.5f, MakeZero);
    }

    void MakeZero()
    {
        mDis = 0;
        myObj.transform.position = GetStartPoint();
    }


    void OnTriggerEnter(Collider other)
    {
        flyMachineHp -= 1f;
        Debug.Log(flyMachineHp);
        if (flyMachineHp <= 0)
        {
            flyMachineHp = 0;
            this.gameObject.AddComponent<Rigidbody>();
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            TimerMgr.Instance.DeleteTimer("MakeZero");
            SoundMgr.Instance.PlayMusic("Music/Wrath of Monoceros Caeli 斩破风暴的魔鲸");

            FlyMachineActive = false;

            TimerMgr.Instance.OneShot("BOOSDelayedAnger", 16f, BOOSDelayedAnger);



            Destroy(this);
        }
    }
    void BOOSDelayedAnger()
    {
        MonsterData.BOSSAnger = true;
    }
}
