using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onNoFaceForAniControl : MonoBehaviour {
    public int myAniMod;
    public Animator myAniam;
    public GameObject myFatherObject;//父物件
    [Header("========================")]
    [Header("死亡積分")]
    public int mySnowManDeadScore;
    [Header("面殘積分")]
    public int myFaceBreakScore;
    [Header("========================")]
    [Header("臉耐久度(滿)")]
    public float myFaceGetHurtValue_Full;
    [Header("臉耐久度")]
    public float myFaceGetHurtValue;
    [Header("臉是否被破壞過")]
    public bool isFaceHaveBeBreak;
    /*[Header("手復原時間")]
    public float myHeadResumeTimerTarget;
    public float myHeadResumeTimer;*/

    [Header("========================")]
    public float myTestingMarvalValue;
    public bool isFacegood;

    public int myIdleRandom;

    public bool isCDTtime_punch;
    public bool isCDTtime_hitground;
    public bool isCDTtime_roar;

    public bool isUnderAttack;

    [Header("========================")]
    [Header("重擊CD時間")]
    public float myskillCDTime_punch;
    float myskillCDTimer_punch;
    [Header("橫掃CD時間")]
    public float myskillCDTime_hitground;
    float myskillCDTimer_hitground;
    [Header("雪花噴射CD時間")]
    public float myskillCDTime_snowworld;
    float myskillCDTimer_roar;

    [Header("========================")]
    public bool isFreezeTime;
    //-------------
    public GameObject myHotPoint;
    void Start()
    {

        isFacegood = true;

        myAniam = gameObject.GetComponent<Animator>();
        //print("hehehaha");
    }
    void Update()
    {
        /*  if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart && myFatherObject.GetComponent<onMonsterVer3>().isMeToFight)
          {
              if (isFreezeTime) { }
              else {
                  if (GameObject.Find("Morale_Monster").GetComponent<Image>().fillAmount == 0)//怪物死翹翹
                  {
                      myAniam.speed = 1;
                      myAniMod = 2;
                      print("myAniMod = 2;");
                  }
                  else {
                      mySnowmanAttackMod();
                  }
              }
              myAniControll();
          }*/
        // mySnowmanAttackMod();
        mySnowmanModControll();
          myAniControll();
    }
    //bear skill function-
    public void mySnowmanSkill_BC_punch() { myAniMod = 5; }
    //bear skill function-
    public void mySnowmanSkill_BC_hitground() { myAniMod = 6; }
    //bear skill function-
    public void mySnowmanSkill_SP_roar() { myAniMod = 7; }

    //Monster AI Tree - 熊
    public void mySnowmanAttackMod()
    {
        if (isFacegood)
        {
            // if (GameObject.Find("Morale_Monster").GetComponent<Image>().fillAmount < 0.4)
            if (myTestingMarvalValue < 0.4)
            {//40%以下時-------------------------------
                if (isCDTtime_roar){mySnowmanAttackHPMore40();}
                else {mySnowmanSkill_SP_roar();}
            }
            else
            {//40%以上時--------------------
                mySnowmanAttackHPMore40();
            }
        }
        else {mySnowmanModControll();}
    }
    public void mySnowmanAttackHPMore40()
    {
        if (isCDTtime_hitground)
        {
            if (myskillCDTimer_hitground > myskillCDTime_hitground)
            {
                myskillCDTimer_hitground = 0;
                isCDTtime_hitground = false;
            }
            else {
                myskillCDTimer_hitground += Time.deltaTime;
                mySnowmanModControll();
            }

            if (isCDTtime_punch)
            {
                if (myskillCDTimer_punch > myskillCDTime_punch)
                {
                    myskillCDTimer_punch = 0;
                    isCDTtime_punch = false;
                }
                else {
                    myskillCDTimer_punch += Time.deltaTime;
                    mySnowmanModControll();
                }
            }
            else {
                mySnowmanSkill_BC_punch();
            }
        }
        else {
            mySnowmanSkill_BC_hitground();
        }
    }


    //怪物模式控制(待機用+復原CD計時)
    public void mySnowmanModControll()
    {//手好-------------------------------------------------------------------1
        if (isFacegood)
        {
            if (myFaceGetHurtValue >= myFaceGetHurtValue_Full)
            {
                myAniMod = 8;
            }
            else { myAniMod = 0; }
        }
        else { myAniMod = 0; }

    }
    //怪物動畫控制器
    public void myAniControll()
    {
        switch (myAniMod)
        {
            case 0://idle
                if (isFacegood)
                {
                    if (myIdleRandom > 50) { myAniam.Play("idle_attack"); }
                    else { myAniam.Play("idle_worry"); }
                }
                else {
                    myAniam.Play("idle_headbreak");
                }
                break;
            case 1:
                myAniam.Play("idle_basic"); 
                break;
            case 2:
                if (isFacegood) { myAniam.Play("dead_havemask"); }
                else { myAniam.Play("dead_nomask"); }
                break;
            case 3:
                myAniam.Play("turning");
                break;
            case 4:
                myAniam.Play("idle_behit");
                break;
            //-----------------以下為技能相關動作
            case 5:
                myAniam.Play("skill_bc_punch");
                break;
            case 6:
                myAniam.Play("skill_bc_hitground");
                break;
            case 7:
                myAniam.Play("skill_bc_roar");
                break;
            case 8:
                myAniam.Play("breaking_head");
                break;
            default:
                break;
        }
    }

    //on Monster KeyFram event function
    public void LastFram_5_FN()
    {
        isCDTtime_punch = true;
        myAniMod = 0;
    }
    public void LastFram_6_FN()
    {
        isCDTtime_hitground = true;
        myAniMod = 0;
    }
    public void LastFram_7_FN()
    {
        isCDTtime_roar = true;
        myAniMod = 0;
    }
    public void LastFram_8_FN() { isFacegood = false; }

    public void LastFram_Idle_FN() {
        myAniMod = 0;
        myIdleRandom = Random.RandomRange(0, 101);
    }

    //Monster attack MQ function
    public void myFindAllMQAndAttack()
    {
        GameObject[] myMQ = GameObject.FindGameObjectsWithTag("MQ");
        for (int a = 0; a < myMQ.Length; a++)
        {
            myMQ[a].GetComponent<onMQVer3>().myHP--;
        }
    }
}
