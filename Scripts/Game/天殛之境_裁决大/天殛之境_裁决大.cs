using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 天殛之境_裁决大 : MonoBehaviour
{
    float angle;
    bool down;
    bool stop;
    Vector3 oldVec;
    Vector3 downCur;







    private float radius;//爆炸半径
    private float powerValue;//力量值

    private Collider[] colliders;//碰撞器
    private Vector3 explosionPoint;
    public GameObject boomPoint;
    void Start()
    {
        this.gameObject.transform.position = Hero0.heroActor.forward * 2 + Hero0.heroActor.position;    
        oldVec = this.gameObject.transform.forward = -Hero0.heroActor.forward;
        down = false;
        stop = false;
        angle = 0;
        downCur = new Vector3();








        radius = 10.0f;
        powerValue = 1000.0f;

        explosionPoint = boomPoint.transform.position;
        colliders = Physics.OverlapSphere(explosionPoint, radius);//参数1为原点和参数2为半径的球体内“满足一定条件”的碰撞体集合

    }

    void Update()
    {
     


        if (stop == false)
        {

            if (down == false)
            {
                angle = Vector3.Angle(oldVec, this.gameObject.transform.forward);
            }


            transform.Rotate(Vector3.right, 4f, Space.Self);
            if (angle >= 90)
            {
                down = true;
                downCur = this.gameObject.transform.forward;
            }

            if (down == true)
            {
                angle = Vector3.Angle(downCur, this.gameObject.transform.forward);

                transform.Rotate(Vector3.right, -12f, Space.Self);
                if (angle >90)
                {
                    stop = true;






                    foreach (Collider col in colliders)
                    {
                        Rigidbody rb = col.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                            rb.AddExplosionForce(powerValue,//爆破力
                                explosionPoint,//爆破坐标点
                                radius, //爆破半径
                                5.0f);//爆破向上的力
                        }
                    }
                }
            }
        }
        Destroy(gameObject, 15);
    }






}
