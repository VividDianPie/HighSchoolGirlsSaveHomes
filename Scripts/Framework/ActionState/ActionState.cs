using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//��������ࣨ���ܻᱻ�̳У�
public class ActionState//���� ״̬ ���� �˳� ���� ��ʼ �� �˳�  ��ײ��� ��״̬���У����ܻᱻ��д��
{


    //���ڵ�
    protected ActionState mParent;

    //�ӽڵ�
    protected ActionState mChild;

    //״̬������
    protected EActionType mType;

    //������Ϸ����
    protected GameObject mMaster;

    //������Ϸ���� ����������
    protected Animator mAt;
   
    //������Ϸ���� ����
    protected Rigidbody mRb;

    //��ɫ״̬��
    protected ActionMachine mAm;


    public ActionState Parent
    {
        get
        {
            return mParent;
        }
        protected set
        {
            mParent = value;
        }
    }


    public ActionState Child
    {
        get
        {
            return mChild;
        }
        protected set
        {
            mChild = value;
        }
    }


    public EActionType Type
    {
        get
        {
            return mType;
        }
        protected set
        {
            mType = value;
        }
    }


    //����
    public ActionState(EActionType type, ActionMachine am, GameObject master, ActionState pnt = null, ActionState cld = null)
    {
        mType = type;
        mAm = am;
        mMaster = master;
        Parent = pnt;
        Child = cld;
        mRb = mMaster.GetComponent<Rigidbody>();
        mAt = mMaster.GetComponent<Animator>();

    
    }


    //����״̬
    virtual public void Enter()
    {

    }


    //�����״̬����
    virtual public void Update()
    {
       
    }


    //�˳����״̬
    virtual public void Exit()
    {

    }


    //������ʼ
    virtual public void OnAnimationStart()
    {

    }


    //����������
    virtual public void OnAnimationHit(int i)
    {

    }


    //��������
    virtual public void OnAnimationEnd()
    {
        
    }


    //��ײ��ʼ��ʱ��
    virtual public void OnCollisionEnter(Collision collision)
    {

    }


    //��ײ������ʱ��
    virtual public void OnCollisionStay(Collision collision)
    {

    }


    //��ײ������ʱ��
    virtual public void OnCollisionExit(Collision collision)
    {

    }

    virtual public void Anima1stage()
    {
     
    }

    virtual public void Anima2stage()
    {

    }

    virtual public void OnTriggerEnter(Collider other)
    { 
    
    }

    virtual public void OnTriggerStay(Collider other)
    {

    }


    virtual public void OnTriggerExit(Collider other)
    {

    }




}

