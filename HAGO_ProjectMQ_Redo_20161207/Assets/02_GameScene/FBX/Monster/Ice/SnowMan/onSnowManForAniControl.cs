using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onSnowManForAniControl : MonoBehaviour {
    public int myAniMod;
    public Animator myAniam;
    public GameObject myFatherObject;//父物件
    [Header("QTE模式(A,B,C)")]
    public string myQTEMod;
    [Header("QTE開始了嗎？")]
    public bool isQTETime;
    [Header("是否顯示QTEUI")]
    public bool isShowQTEUI;
    [Header("QTE目標UI")]
    public GameObject[] myQTETargetUI;
    [Header("A-目標次數")]
    public int myQTE_A_Count;
    [Header("B-連打次數")]
    public int myQTE_B_Count;
    [Header("B-連打次數目標值")]
    public int myQTE_B_TargetValue;
    [Header("C-反應秒數")]
    public float myQTE_C_ActionTime;
    [Header("C-目標次數")]
    public int myQTE_C_Count;
    [Header("========================")]
    [Header("死亡積分")]
    public int mySnowManDeadScore;
    [Header("手殘積分")]
    public int myHandBreakScore;
    [Header("========================")]
    [Header("手耐久度(滿)")]
    public float myHandGetHurtValue_Full;
    [Header("手耐久度")]
    public float myHandGetHurtValue;
    [Header("手是否被破壞過")]
    public bool isHandHaveBeBreak;
    /*[Header("手復原時間")]
    public float myHeadResumeTimerTarget;
    public float myHeadResumeTimer;*/

    [Header("========================")]
    public float myTestingMarvalValue;
    public bool isHandgood;
    
    public int myIdleRandom;

    public bool isCDTtime_hit;
    public bool isCDTtime_wave;
    public bool isCDTtime_snowshotshot;

    public bool isUnderAttack;

    [Header("========================")]
    [Header("重擊CD時間")]
    public float myskillCDTime_hit;
    float myskillCDTimer_hit;
    [Header("橫掃CD時間")]
    public float myskillCDTime_wave;
    float myskillCDTimer_wave;
    [Header("雪花噴射CD時間")]
    public float myskillCDTime_snowworld;
    float myskillCDTimer_snowshotshot;
    
    [Header("========================")]
    public bool isFreezeTime;
    //-------------
    public GameObject myHotPoint;
    void Start()
    {

        isHandgood = true;
        
        myAniam = gameObject.GetComponent<Animator>();
        //print("hehehaha");
    }
    void Update()
    {
          if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart && myFatherObject.GetComponent<onMonsterVer3>().isMeToFight)
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
          }
    }
    //bear skill function-
    public void mySnowmanSkill_BC_hit() { myAniMod = 8; }
    //bear skill function-
    public void mySnowmanSkill_BC_wave() { myAniMod = 9; }
    //bear skill function-
    public void mySnowmanSkill_SP_snowshotshot(){myAniMod = 10;}
  
    //Monster AI Tree - 熊
    public void mySnowmanAttackMod()
    {
        if (isHandgood) {
            if (GameObject.Find("Morale_Monster").GetComponent<Image>().fillAmount < 0.2)
           //if(myTestingMarvalValue<0.2)
            {//20%以下時-------------------------------
                if (isCDTtime_snowshotshot)
                {
                    mySnowmanAttackHPMore20();
                }
                else {
                    mySnowmanSkill_SP_snowshotshot();
                }
            }
            else
            {//20%以上時--------------------
                mySnowmanAttackHPMore20();
            }
        }
        else {
            mySnowmanModControll();
        }
    }
    public void mySnowmanAttackHPMore20()
    {
        if (isCDTtime_wave)
        {
            if (myskillCDTimer_wave > myskillCDTime_wave) {
                myskillCDTimer_wave = 0;
                isCDTtime_wave = false;
            }
            else {
                myskillCDTimer_wave += Time.deltaTime;
                mySnowmanModControll();
            }

            if (isCDTtime_hit)
            {
                if (myskillCDTimer_hit > myskillCDTime_hit)
                {
                    myskillCDTimer_hit = 0;
                    isCDTtime_hit = false;
                }
                else {
                    myskillCDTimer_hit += Time.deltaTime;
                    mySnowmanModControll();
                }
            }
            else {
                mySnowmanSkill_BC_hit();
            }
        }
        else {
            mySnowmanSkill_BC_wave();
        }
    }


    //怪物模式控制(待機用+復原CD計時)
    public void mySnowmanModControll()
    {//手好-------------------------------------------------------------------1
        if (isHandgood) {
            if (myHandGetHurtValue >= myHandGetHurtValue_Full) {
                myAniMod = 12;
            }
            else {myAniMod = 0;}
        }
        else {myAniMod = 0;}
  
    }
    //怪物動畫控制器
    public void myAniControll()
    {
        switch (myAniMod)
        {
            case 0://idle
                if (isHandgood) {
                    if (myIdleRandom > 50) { myAniam.Play("idle_attack"); }
                    else { myAniam.Play("angry"); }
                }
                else {
                    myAniam.Play("idle_handbreak");
                }
                break;
            case 1:
                if (myIdleRandom > 50) { myAniam.Play("idle_basic"); }
                else { myAniam.Play("idle_basic2"); }
                break;
            case 2:
                if (isHandgood) {myAniam.Play("dead_withweapon");}
                else {myAniam.Play("dead_noweapon");}
                break;
            //移動相關，走路跑步
            case 3:
                myAniam.Play("run_ready");
                break;
            case 4:
                myAniam.Play("run_loop");
                break;
            case 5:
                myAniam.Play("run_end");
                break;
            case 6:
                myAniam.Play("turning");
                break;
            case 7:
                myAniam.Play("walk_loop");
                break;
            //-----------------以下為技能相關動作
            case 8:
                myAniam.Play("sk_bc_weaponhit");
                break;
            case 9:
                myAniam.Play("sk_bc_weaponwave");
                break;
            case 10:
                myAniam.Play("sk_sp_snowshotshot");
                break;
            case 12:
                myAniam.Play("breaking_hand");
                break;
            default:
                break;
        }
    }

    //on Monster KeyFram event function
    public void LastFram_8_FN() {
        isCDTtime_hit = true;
        myAniMod = 0;
    }
    public void LastFram_9_FN()
    {
        isCDTtime_wave = true;
        myAniMod = 0;
    }
    public void LastFram_10_FN()
    {
        isCDTtime_snowshotshot = true;
        myAniMod = 0;
    }
    public void LastFram_12_FN() { isHandgood = false; }

    public void LastFram_Idle_FN() { myIdleRandom = Random.RandomRange(0, 101); }

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