using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EActionType//枚举状态类型
{
    None = -1,
    //英雄
    Idle = 0,
    Run,
    Jump,
    Jump1,
    Fly,
    Evade,
    Attack0,
    Attack1,
    Attack2,
    Attack3,
    EvadeToAttack,
    BeHit,
    BeHit1,
    BigSkill,
    SkillE,
    Count,

    //怪物
    MonsterIdle = 100000,
    MonsterIdle1,
    MosnterAttack,
    MosnterAttack1,
    MosnterWalk,
    MosnterRun,
    MosnterBeHit,
    MosnterBeHit1,

    MonsterDie,



    //BOSS香蕉人
    BOSSIdle=200000,
    BOSSRun,
    BOSSAtk0,
    BOSSAtk1,
    BOSSBnanaJump,
    BOSSBeHit,

    BOSSDie,
}
