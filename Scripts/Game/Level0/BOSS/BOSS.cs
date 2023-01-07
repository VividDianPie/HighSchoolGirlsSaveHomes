using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//ʹ�õ�����Ҫ��ͷ�ļ�
public class BOSS : MonoBehaviour//��Ϊ���� �����¼� ��ײ����� ��������� �������� �ж����� ����״̬
{
    // ����ʦ
    public Animator At;

    // ����
    public Rigidbody Rb;

    protected ActionMachine mAm;
    protected BehaviorTree mBehaviorTree;
    public Transform bangBang { get; set; }
    //��������
    public GameObject RightHand;


   

    //NavneshAgent
    public NavMeshAgent Agent;//Ѱ·���





    //true��ʾ�� false����
    protected bool mIsDead;
    public bool IsDead
    {
        get
        {
            return mIsDead;
        }
        set
        {
            mIsDead = value;
            if (mIsDead)
            {
                mAm.ChangeAction(EActionType.BOSSDie);
                TimerMgr.Instance.OneShot("BOSSDieDelayedDelete", 12f, BOSSDieDelayedDelete);
                //�ӳ�һ����ʱ�������������Լ�����  0.0~1.0֮��������
                //TimerMgr.Instance.OneShot((Random.value * 100000).ToString(), 3f, MonsterDieAndCreateBox);
            }
        }
    }
    void BOSSDieDelayedDelete()
    {
        Destroy(this);
        Destroy(this.gameObject);
    }

    void Awake()
    {
        mIsDead = false;
        //״̬��
        mAm = new ActionMachine(this.gameObject);
        //��ֲ��Ϊ��  
        mBehaviorTree = new BehaviorTree(this.gameObject, mAm, null);
        //������Ϊ����
        AIBOSSIdle root = new AIBOSSIdle(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And);
        //������Ϊ����
        mBehaviorTree.BehaviorOfTreeSpecies(root);
        //��Ϊ����ʼ����
        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIBOSSIdle(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIBOSSRun(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIBOSSBnanaJump(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIBOSSAtk0(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));

        mBehaviorTree.AddChild(mBehaviorTree.Root, new AIBOSSAtk1(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));

       mBehaviorTree.AddChild(mBehaviorTree.Root, new AIBOSSBeHit(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));

       mBehaviorTree.AddChild(mBehaviorTree.Root, new AIBOSSDie(this.gameObject, mAm, mBehaviorTree, BehaviorCondition.EType.And));


        //Monster
        mAm.AddAction(new BOSSIdle(EActionType.BOSSIdle, mAm, this.gameObject));

        mAm.AddAction(new BOSSRun(EActionType.BOSSRun, mAm, this.gameObject));

        mAm.AddAction(new BOSSBnanaJump(EActionType.BOSSBnanaJump, mAm, this.gameObject));

        mAm.AddAction(new BOSSAtk0(EActionType.BOSSAtk0, mAm, this.gameObject));

        mAm.AddAction(new BOSSAtk1(EActionType.BOSSAtk1, mAm, this.gameObject));

        mAm.AddAction(new BOSSAtk1(EActionType.BOSSAtk1, mAm, this.gameObject));

        mAm.AddAction(new BOSSBeHit(EActionType.BOSSBeHit, mAm, this.gameObject));

        mAm.AddAction(new BOSSDie(EActionType.BOSSDie, mAm, this.gameObject));




        //���� Bangbang
        bangBang = GameObject.Instantiate(Resources.Load<Transform>("Prefab/Bangbang"));
        bangBang.parent = RightHand.transform;
        bangBang.transform.localPosition = RightHand.transform.localPosition;
        bangBang.localPosition = new Vector3(0.003f, 0.0055f, 0.005f);
        bangBang.localRotation = Quaternion.Euler(27.492f, -85.569f, 91.641f);
        bangBang.localScale = new Vector3(0.003866859f, 0.005604669f, 0.003866859f);
    }


    void Start()
    {
        //AI��Ϊ��Enter
        mBehaviorTree.OnEnter();
    }

    static bool bossAinSpeed=true;
    void Update()
    {
        mAm.Update();

        //��ɫ����AI��û�б�Ҫ����
        if (mIsDead == false)
        {
            //�ж���������״̬
            mBehaviorTree.Update();
        }


        //if (Input.GetKeyDown(KeyCode.Keypad1))
        //{
        //    bossAinSpeed = !bossAinSpeed;
        //}
        //if (bossAinSpeed == false)
        //{
        //    At.speed = 0;
        //}
        //else { At.speed = 1; }


    }
 

    public void OnAnimationStart()
    {
        mAm.OnAnimationStart();
    }


    public void OnAnimationHit(int i)
    {
        mAm.OnAnimationHit(i);
    }


    public void OnAnimationEnd()
    {
        mAm.OnAnimationEnd();
    }


    public void OnCollisionEnter(Collision collision)
    {
        mBehaviorTree.OnCollisionEnter(collision);
    }


    public void OnCollisionStay(Collision collision)
    {
        mBehaviorTree.OnCollisionStay(collision);
    }


    public void OnCollisionExit(Collision collision)
    {
        mBehaviorTree.OnCollisionExit(collision);
    }

    virtual public void OnTriggerEnter(Collider other)
    {
        mBehaviorTree.OnTriggerEnter(other);
    }

    virtual public void OnTriggerStay(Collider other)
    {
        mBehaviorTree.OnTriggerStay(other);
    }


    virtual public void OnTriggerExit(Collider other)
    {
        mBehaviorTree.OnTriggerExit(other);
    }

    //������������
    public void MonsterDieAndCreateBox()
    {
        Vector3 pos = gameObject.transform.position;

        //�ñ���Ϸ����������ʧ
        GameObject.Destroy(this.gameObject, 6f);

        //��������
        GameObject obj = Resources.Load<GameObject>("Prefab/Bangbang");
        obj = GameObject.Instantiate<GameObject>(obj);
        pos.y += 0.5f;
        obj.transform.position = pos;
    }



    //��Ϊ��������
    public bool IsHeroCloseTo()
    {
        //����Ŀ��
        GameObject heroObj = GameObject.FindGameObjectWithTag("Hero");
        //���
        float disToHero = Vector3.Distance(gameObject.transform.position, heroObj.transform.position);
        if (disToHero < 1.5f)
        {
            return true;
        }
        return false;
    }




    bool MonsterWalkIsEnd()
    {

        //�жϵ�ǰ�Ķ���״̬����
        if ((mAm.Current as BehaviorActionBase).StateFinish == true)
        {
            //mAm.ChangeAction(EActionType.MosnterWalk);
            return true;
        }
        return false;
    }
     

}
