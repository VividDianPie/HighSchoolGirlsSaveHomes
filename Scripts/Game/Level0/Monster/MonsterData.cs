using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData : MonoBehaviour
{
    public bool monsterAnger;
    public float monsterWalkSpeed;
    public float monsterRunSpeed;
    public float monsterMaxHp;
    public float monsterHp;


    public float BOSSMaxHp;
    public float BOSSHp;
    public float BOSSRunSpeed;
    static public bool BOSSAnger;
    MonsterData()
    {
        BOSSAnger = false;
        monsterAnger = false;
        monsterWalkSpeed = 3;
        monsterRunSpeed = 5;
        monsterMaxHp = 1000;
        monsterHp = 1000;

        BOSSMaxHp = 1000;
        BOSSHp = 1000;
        BOSSRunSpeed = 5;
    }

}
