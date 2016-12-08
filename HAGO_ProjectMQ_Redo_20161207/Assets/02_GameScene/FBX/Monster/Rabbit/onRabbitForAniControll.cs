using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onRabbitForAniControll : MonoBehaviour {
    public int myAniMod;
    public Animator myAniam;
    public Text mytextGroup;
    public Text mytextAnimMod;
    public GameObject myFatherObject;//父物件
    [Header("兔子滿血血量")]
    public float myBigeyeFullHP;
    [Header("大眼血量")]
    public float myBigeyeHP;
    public GameObject myBigeyeHitpoint;
    [Header("大眼復原時間")]
    public float myBigeyeResumeTimerTarget;
    float myBigeyeResumeTimer;
    [Header("翅膀滿血血量")]
    public float myWingFullHP;
    [Header("翅膀血量")]
    public float myWingHP;
    public GameObject myWingHitpoint;
    [Header("翅膀復原時間")]
    public float myWingResumeTimerTarget;
    float myWingResumeTimer;
    //[Header("複眼血量")]
    float myOtherEyeHP;


    public bool isBigEyegood;
    public bool isWinggood;

    public bool isUnderAttack;

    [Header("大眼衝撞傷害")]
    public int mySkill1Hurtpoint;
    [Header("大眼衝撞CD時間")]
    public float mySkill1CDTimer;
    float mySkill1Timer;
    bool is26CD;

    [Header("翅膀迴旋傷害")]
    public int mySkill2Hurtpoint;
    [Header("翅膀迴旋CD時間")]
    public float mySkill2CDTimer;
    float mySkill2Timer;
    bool is27CD;

    [Header("20%大招傷害")]
    public int mySkill3Hurtpoint;
    [Header("20%大招CD時間")]
    public float mySkill3CDTimer;
    float mySkill3Timer;
    bool is21CD;

    float mywaitTimer;

    public bool isNeedToPlayBigeyeBreakMovie;

    public AudioClip[] mySoundEffectData;
    public AudioSource myAudioSource;
    void Start()
    {
        isWinggood = true;
        isBigEyegood = true;
        myAniam = gameObject.GetComponent<Animator>();
        myAudioSource = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart)
        {
            //myBigeyeHP = myBigeyeHitpoint.GetComponent<OnLookAtPoint>().myHP;
            //myWingHP = myWingHitpoint.GetComponent<OnLookAtPoint>().myHP;
            myAniControll();
            myBigeyeAttackMod();
        }

    }
    public void myBigeyeSkill1_basic_BigeyeAttack()
    {//技能1眼撞
        if (isBigEyegood) { myAniMod = 26; }
        else { myAniMod = 28; }
    }
    public void myBigeyeSkill2_basic_BigeyeRotate()
    {//技能2迴旋
        if (is27CD)
        {
            if (mySkill2Timer > mySkill2CDTimer)
            {
                mySkill2Timer = 0;
                is27CD = false;
            }
            else { mySkill2Timer += Time.deltaTime; }
        }
        if (isBigEyegood) { myAniMod = 27; }
        else { myAniMod = 29; }
    }
    public void myBigeyeSkill3_Special_BigeyeMagic_Air()
    {//技能3空中大眼魔法
        myAniMod = 21;
    }
    public void myBigeyeSkill3_Special_BigeyeMagic_Ground()
    {//技能4地上大眼魔法
        myAniMod = 24;
    }
    public void myBigeyeAttackMod()
    {
        if (GameObject.Find("Morale_Monster").GetComponent<Image>().fillAmount < 0.2 && isBigEyegood)//20%以下時
        {
            if (is21CD)
            {
                if (mySkill3Timer > mySkill3CDTimer)
                {
                    mySkill3Timer = 0;
                    is21CD = false;
                }
                else {
                    myBigeyeModControll();
                    mySkill3Timer += Time.deltaTime;
                }
                //--
                if (isWinggood)
                {
                    if (is27CD)
                    {
                        if (mySkill2Timer > mySkill2CDTimer)
                        {
                            mySkill2Timer = 0;
                            is27CD = false;
                        }
                        else {
                            myBigeyeModControll();
                            mySkill2Timer += Time.deltaTime;
                        }
                        if (is26CD)
                        {
                            if (mySkill1Timer > mySkill1CDTimer)
                            {
                                mySkill1Timer = 0;
                                is26CD = false;
                            }
                            else {
                                myBigeyeModControll();
                                mySkill1Timer += Time.deltaTime;
                            }
                        }
                        else {
                            myBigeyeSkill1_basic_BigeyeAttack();

                        }
                    }
                    else {
                        myBigeyeSkill2_basic_BigeyeRotate();
                        myAudioController(2);

                    }
                }
                /* else {
                     if (is26CD)
                     {
                         if (mySkill1Timer > mySkill1CDTimer)
                         {
                             mySkill1Timer = 0;
                             is26CD = false;
                         }
                         else {
                             myBigeyeModControll();
                             mySkill1Timer += Time.deltaTime;
                         }
                     }
                     else {
                         myBigeyeSkill1_basic_BigeyeAttack();
                     }
                 }*/
                //--
            }
            else {//放大招
                if (isWinggood)
                {
                    myBigeyeSkill3_Special_BigeyeMagic_Air();
                    myAudioController(5);
                }
                else {
                    myBigeyeSkill3_Special_BigeyeMagic_Ground();
                    myAudioController(5);
                }
            }
        }
        else {//20%以上時
            if (isWinggood)
            {
                if (is27CD)
                {
                    if (mySkill2Timer > mySkill2CDTimer)
                    {
                        mySkill2Timer = 0;
                        is27CD = false;
                    }
                    else {
                        myBigeyeModControll();
                        mySkill2Timer += Time.deltaTime;
                    }
                    if (is26CD)
                    {
                        if (mySkill1Timer > mySkill1CDTimer)
                        {
                            mySkill1Timer = 0;
                            is26CD = false;
                        }
                        else {
                            myBigeyeModControll();
                            mySkill1Timer += Time.deltaTime;
                        }
                    }
                    else {
                        myBigeyeSkill1_basic_BigeyeAttack();
                    }
                }
                else {
                    myBigeyeSkill2_basic_BigeyeRotate();
                    myAudioController(2);
                }
            }
            else {
                myBigeyeModControll();
            }
            /*else {
                if (is26CD)
                {
                    if (mySkill1Timer > mySkill1CDTimer)
                    {
                        mySkill1Timer = 0;
                        is26CD = false;
                    }
                    else {
                        myBigeyeModControll();
                        mySkill1Timer += Time.deltaTime;
                    }
                }
                else {
                    myBigeyeSkill1_basic_BigeyeAttack();
                }
            }*/
        }
    }
    public void myBigeyeModControll()
    {
        //myAniam.speed = 0.7f;
        /* if (isNeedToPlayBigeyeBreakMovie) { }
         else */
        if (isBigEyegood && isWinggood)
        {//眼好翅好-------------------------------------------------------------------1
            //print("if (isBigEyegood && isWinggood)");
            if (myWingHP <= 0)
            {
                myAniMod = 22;
                myAudioController(3);
                myAniam.speed = 0.7f;
                //print("bigeye mod here");
            }
            else if (myBigeyeHP <= 0)
            {
                myAniMod = 61;
                myAudioController(1);
                myAniam.speed = 0.7f;
            }
            else {
                myAniMod = 13;
                myAniam.speed = 0.7f;
            }
        }
        else if (isBigEyegood && !isWinggood)
        {//眼好翅壞-------------------------------------------------------------------2
            if (myWingResumeTimer > myWingResumeTimerTarget)
            {
                //GameObject.Find("hitpoint-4").GetComponent<OnLookAtPoint>().myHP = myWingFullHP;
                //GameObject.Find("hitpoint-5").GetComponent<OnLookAtPoint>().myHP = myWingFullHP;
                myAniMod = 25;
                myAniam.speed = 0.7f;
            }
            else if (myBigeyeHP <= 0)
            {
                myAniMod = 62;
                myAniam.speed = 0.7f;
                myAudioController(1);
            }
            else {
                myWingResumeTimer += Time.deltaTime;
                myAniMod = 23;
                myAniam.speed = 0.7f;
            }
        }
        else if (!isBigEyegood && isWinggood)
        {//眼壞翅好-------------------------------------------------------------------3

            if (myBigeyeResumeTimer > myBigeyeResumeTimerTarget)
            {
                //myBigeyeResumeTimer = 0;
               // myBigeyeHitpoint.GetComponent<OnLookAtPoint>().myHP = myBigeyeFullHP;
                myAniMod = 16;
                myAniam.speed = 0.7f;
            }
            else if (myWingHP <= 0)
            {
                myAniMod = 08;
                myAudioController(3);
                myAniam.speed = 0.7f;
            }
            else {
                myBigeyeResumeTimer += Time.deltaTime;
                myAniMod = 0;
                myAniam.speed = 0.7f;
            }
        }
        else if (!isBigEyegood && !isWinggood)
        {//眼壞翅壞-------------------------------------------------------------------4
            if (myWingResumeTimer > myWingResumeTimerTarget)
            {
                //myWingResumeTimer = 0;
              //  GameObject.Find("hitpoint-4").GetComponent<OnLookAtPoint>().myHP = myWingFullHP;
               // GameObject.Find("hitpoint-5").GetComponent<OnLookAtPoint>().myHP = myWingFullHP;
                myAniMod = 07;
                myAniam.speed = 0.7f;
            }
            else if (myBigeyeResumeTimer > myBigeyeResumeTimerTarget)
            {
                //myBigeyeResumeTimer = 0;
             //   myBigeyeHitpoint.GetComponent<OnLookAtPoint>().myHP = myBigeyeFullHP;
                myAniMod = 10;
                myAniam.speed = 0.7f;
            }
            else {
                myWingResumeTimer += Time.deltaTime;
                myBigeyeResumeTimer += Time.deltaTime;
                myAniMod = 03;
                myAniam.speed = 0.7f;
            }
        }
    }
    public void myAniControll()
    {
        switch (myAniMod)
        {
            case 0:
                myAniam.Play("idle_basic");
                break;
            case 1:
                myAniam.Play("idle_attack");
                break;
            case 2:
                myAniam.Play("idle_attack_MB");
                break;
            case 3:
                myAniam.Play("idle_LB");
                break;
            case 4:
                myAniam.Play("idle_LBMB");
                break;
            case 5:
                myAniam.Play("dead_basic");
                break;
            case 6:
                myAniam.Play("dead_MB");
                break;
            case 7:
                myAniam.Play("dead_LBMBs");
                break;
            case 8:
                myAniam.Play("dead_LBs");
                break;
                //--------------------------------
            case 9:
                myAniam.Play("run_ready");
                break;
            case 10:
                myAniam.Play("run_loop");
                break;
            case 11:
                myAniam.Play("run_end");
                break;
            case 12:
                myAniam.Play("turning");
                break;
            case 13:
                myAniam.Play("walk_ready");
                break;
            case 14:
                myAniam.Play("walk_loop");
                break;
            case 15:
                myAniam.Play("walk_end");
                break;
                //------------------
            case 16:
                myAniam.Play("sk_bc_twohandfight");
                break;
            case 17:
                myAniam.Play("sk_bc_twohandfight_LB");
                break;
            case 18:
                myAniam.Play("sk_bc_twohandfight_MB");
                break;
            case 19:
                myAniam.Play("sk_bc_twohandfight_LBMB");
                break;
            case 20:
                myAniam.Play("sk_bc_airdish");
                break;
            case 21:
                myAniam.Play("sk_bc_airdish_MB");
                break;
            case 22:
                myAniam.Play("sk_sp_uplegfight_LB");
                break;
            case 23:
                myAniam.Play("sk_sp_uplegfight_LBMB");
                break;
            case 24:
                myAniam.Play("sk_sp_superpunch_ready");
                break;
            case 25:
                myAniam.Play("sk_sp_superpunch_fight");
                break;
            case 26:
                myAniam.Play("sk_sp_superpunch_lookgood");
                break;
            case 27:
                myAniam.Play("sk_sp_superpunch_ready_MB");
                break;
            case 28:
                myAniam.Play("sk_sp_superpunch_fight_MB");
                break;
            case 29:
                myAniam.Play("sk_sp_superpunch_lookgood_MB");
                break;
                //----------------------------------------------------
            case 30:
                myAniam.Play("breaking_mouth");
                break;
            case 31:
                myAniam.Play("breaking_leg");
                break;
            case 32:
                myAniam.Play("breaking_MBs_leg");
                break;
            case 33:
                myAniam.Play("breaking_LBs_mouth");
                break;
            case 34:
                myAniam.Play("breaking_ear");
                break;
            case 35:
                myAniam.Play("breaking_MBs_ear");
                break;
            case 36:
                myAniam.Play("breaking_LBs_ear");
                break;
            case 37:
                myAniam.Play("breaking_LBMBs_ear");
                break;
            case 38:
                myAniam.Play("resume_LBs_mouth");
                break;
            case 39:
                myAniam.Play("resume_leg");
                break;
            case 40:
                myAniam.Play("resume_MBs_leg");
                break;
            case 41:
                myAniam.Play("resume_mouth");
                break;
            default:
                break;
        }
    }
  
    public void myFindAllMQAndAttack_Skill1()
    {
        if (GameObject.Find("MainCamera").GetComponent<OnCameraForShootMQ>().isSuperStarTime) { }
        else {
            GameObject[] myMQ = GameObject.FindGameObjectsWithTag("MQ");
            for (int a = 0; a < myMQ.Length; a++)
            {
                /*if (myMQ[a].GetComponent<onMQVer3>().myTargetPoint.name == null) {
                    print("myMQ[a].GetComponent<onMQVer3>().myTargetPoint.name == null");
                }
                else */
                if (myMQ[a].GetComponent<onMQVer3>().myTargetPoint.name == "hitpoint-1")
                {
                    if (myMQ[a].GetComponent<onMQVer3>().isAttackTime)
                    {
                        myMQ[a].GetComponent<onMQVer3>().isBeHit = true;
                        myMQ[a].GetComponent<onMQVer3>().isHitFlyAway = true;
                        myMQ[a].GetComponent<onMQVer3>().myHP -= mySkill1Hurtpoint;
                    }
                }
            }
        }
    }
    public void myFindAllMQAndAttack_Skill2()
    {
        GameObject[] myMQ = GameObject.FindGameObjectsWithTag("MQ");
        if (myMQ != null)
        {
            for (int a = 0; a < myMQ.Length; a++)
            {
                if (myMQ[a].GetComponent<onMQVer3>().isAttackTime)
                {
                    myMQ[a].GetComponent<onMQVer3>().isBeHit = true;
                    myMQ[a].GetComponent<onMQVer3>().isHitFlyAway = true;
                    myMQ[a].GetComponent<onMQVer3>().myHP -= mySkill1Hurtpoint;
                }
            }
        }
        else { }
    }
    public void myFindAllMQAndAttack_Skill3()
    {

        GameObject[] myMQ = GameObject.FindGameObjectsWithTag("MQ");
        for (int a = 0; a < myMQ.Length; a++)
        {
            //myMQ[a].GetComponent<onMQVer3>().isBeHit = true;
            myMQ[a].GetComponent<onMQVer3>().myHP -= mySkill3Hurtpoint;
        }
    }
    public void myAudioController(int AudioID)
    {
        myAudioSource.clip = mySoundEffectData[AudioID];
        myAudioSource.enabled = false;
        myAudioSource.enabled = true;
    }
}
