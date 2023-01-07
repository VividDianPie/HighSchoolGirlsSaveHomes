using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class HeroData 
{
    public float runSpeed { get; set; }
    public float jumpPower { get; set; }
    public float jumpMoveSpeed { get; set; }
    public float FlyMoveSpeed { get; set; }
    public float evadeSpeed { get; set; }
    public float evadeAtkSpeed { get; set; }
    public float Atk3Speed { get; set; }
    public float heroMaxHp { get; set; }
    public float heroHp { get; set; }
    public float heroAd { get; set; }

    public bool anima1stageIsEndHeroEvadeexclusive { get; set; }
    public bool isheroEvadeCooling { get; set; }


    HeroData()
    {
        runSpeed = 5f;
        jumpPower = 8f;
        jumpMoveSpeed = 8f;
        FlyMoveSpeed = 8f;
        evadeSpeed = 15;
        evadeAtkSpeed = 15;
        Atk3Speed = 10;
        heroMaxHp = 5000;
        heroHp = 5000;
        heroAd = 100;

        anima1stageIsEndHeroEvadeexclusive = true;
        isheroEvadeCooling = false;
    }
    static HeroData sInstance;
    public static HeroData Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = new HeroData();
            }
            return sInstance;
        }
    }


    //public int f1()
    //{
    //    return 1;
    //}
    //public float GetClipLength(this Animator animator, string clip)
    //{
    //    if (null == animator || string.IsNullOrEmpty(clip) || null == animator.runtimeAnimatorController)
    //        return 0;
    //    RuntimeAnimatorController ac = animator.runtimeAnimatorController;
    //    AnimationClip[] tAnimationClips = ac.animationClips;
    //    if (null == tAnimationClips || tAnimationClips.Length <= 0) return 0;
    //    AnimationClip tAnimationClip;
    //    for (int tCounter = 0, tLen = tAnimationClips.Length; tCounter < tLen; tCounter++)
    //    {
    //        tAnimationClip = ac.animationClips[tCounter];
    //        if (null != tAnimationClip && tAnimationClip.name == clip)
    //            return tAnimationClip.length;
    //    }
    //    return 0F;
    //}

   
}

