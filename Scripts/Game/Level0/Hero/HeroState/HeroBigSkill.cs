
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBigSkill : ActionState 
{
    bool anima1stage;
    public HeroBigSkill(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
        : base(type, am, master, pnt, cld)
    {


    }

    void start()
    {

    }

    override public void Enter()
    {
        anima1stage = false;
        mAt.CrossFade("Skill", 0.05f);
        Hero0.����֮��_�þ�.localPosition = new Vector3(-0.009f, 0.072f, -0.031f);
        Hero0.����֮��_�þ�.localRotation = Quaternion.Euler(79.554f, 39.207f, 139.686f);
        GameObject.Instantiate(Resources.Load<Transform>("Prefab/����֮��_�þ���"));

    }


    override public void Update()
    {   
        if (anima1stage == true)
        {
            float ph = Input.GetAxis("Horizontal");
            float pv = Input.GetAxis("Vertical");
            // ת�� �� �л�Ϊ�ƶ�״̬
            if (pv != 0 || ph != 0f)
            {
                mAm.ChangeAction(EActionType.Run); 
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                mAm.ChangeAction(EActionType.Jump);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                mAm.ChangeAction(EActionType.Attack0);
            }
        }
    }
    override public void Exit()
    {
     
    }

    override public void OnAnimationStart()
    {

    }



    override public void OnAnimationHit(int i)
    {

    }



    override public void OnAnimationEnd()
    {
        mAm.ChangeAction(EActionType.Idle);
    }

    override public void Anima1stage()
    {
        anima1stage = true;
    }
    override public void Anima2stage()
    {
    }


    //������
    override public void OnTriggerEnter(Collider other)
    {
      
    }

    override public void OnTriggerStay(Collider other)
    {

    }


    override public void OnTriggerExit(Collider other)
    {

    }
     

     
}
