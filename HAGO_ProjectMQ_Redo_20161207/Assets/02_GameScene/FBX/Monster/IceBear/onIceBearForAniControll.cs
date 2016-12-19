using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class onIceBearForAniControll : MonoBehaviour
{
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
    public int myIceBearDeadScore;
    [Header("腿殘積分")]
    public int myLegBreakScore;
    [Header("頭爆積分")]
    public int myHeadBreakScore;
    [Header("========================")]
    [Header("腦袋耐久度(滿)")]
    public float myHeadGetHurtValue_Full;
    [Header("腦袋耐久度")]
    public float myHeadGetHurtValue;
    [Header("腦袋是否被破壞過")]
    public bool isHeadHaveBeBreak;
    [Header("腦袋復原時間")]
    public float myHeadResumeTimerTarget;
    public float myHeadResumeTimer;

    [Header("嘴耐久度(滿)")]
    public float myMouthGetHurtValue_Full;
    [Header("嘴耐久度")]
    public float myMouthGetHurtValue;
    [Header("嘴是否被破壞過")]
    public bool isMouthHaveBeBreak;
    [Header("嘴復原時間")]
    public float myMouthResumeTimerTarget;
    public float myMouthResumeTimer;

    [Header("肚子耐久度(滿)")]
    public float myBellyGetHurtValue_Full;
    [Header("肚子耐久度")]
    public float myBellyGetHurtValue;
    [Header("肚子是否被破壞過")]
    public bool isBellyHaveBeBreak;
    [Header("肚子復原時間")]
    public float myBellyResumeTimerTarget;
    public float myBellyResumeTimer;


    [Header("腳耐久度(滿)")]
    public float myLegGetHurtValue_Full;
    [Header("腳耐久度")]
    public float myLegGetHurtValue;
    [Header("腳是否被破壞過")]
    public bool isLegHaveBeBreak;
    [Header("腳復原時間")]
    public float myLegResumeTimerTarget;
    public float myLegResumeTimer;

    [Header("========================")]
    public bool isHeadgood;
    public bool isMouthgood;
    public bool isBellygood;
    public bool isLeggood;


    public int myIdleRandom;

    public bool isCDTtime_wave;
    public bool isCDTtime_jumphit;
    public bool isCDTtime_eatfish;
    public bool isCDTtime_gyrohit;

    public bool isUnderAttack;

    [Header("========================")]
    [Header("揮擊CD時間")]
    public float myskillCDTime_wave;
    float myskillCDTimer_wave;
    [Header("跳擊CD時間")]
    public float myskillCDTime_jumphit;
    float myskillCDTimer_jumphit;
    [Header("啃魚CD時間")]
    public float myskillCDTime_eatfish;
    public float myskillCDTimer_eatfish;
    public float myEatFishLoopTime;
    public float myEatFishLoopTimer;
    [Header("迴旋斬CD時間")]
    public float myskillCDTime_gyrohit;
    float myskillCDTimer_grohit;
    public float myGrohitLoopTime;
    public float myGrohitLoopTimer;

    [Header("========================")]
    public bool isFreezeTime;
    //-------------
    public GameObject myHotPoint;
    void Start()
    {

        isHeadgood = true;
        isMouthgood = true;
        isBellygood = true;
        isLeggood = true;

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
                    if (isQTETime)
                    {
                        switch (myQTEMod)
                        {
                            case "A":
                                if (myQTE_A_Count == 5)
                                {
                                    myAniam.speed = 1;
                                    if (isLeggood) { myAniMod = 34; }
                                    else { myAniMod = 33; }
                                    isCDTtime_eatfish = true;
                                    myQTE_A_Count = 0;
                                    print("qte a 成功");
                                }
                                break;
                            case "B":
                                if (myQTE_B_Count > myQTE_B_TargetValue)
                                {
                                    myAniam.speed = 1;
                                    if (isLeggood) { myAniMod = 34; }
                                    else { myAniMod = 33; }
                                    print("qte B 成功");
                                    isCDTtime_eatfish = true;
                                    myQTE_B_Count = 0;
                                }
                                break;
                            case "C":
                                if (myQTE_C_Count == 8)
                                {
                                    myAniam.speed = 1;
                                    if (isLeggood) { myAniMod = 34; }
                                    else { myAniMod = 33; }
                                    isCDTtime_eatfish = true;
                                    myQTE_C_Count = 0;
                                    print("qte C 成功");
                                }
                                break;
                            default:
                                print("你忘記設定QTE的ABC模式囉！！");
                                break;
                        }
                    }
                    else {
                        myBearAttackMod();
                    }

                    //myBearModControll();
                }
            }
        
            //QTE時光
            //if (isQTETime) { myQTEFN(); }
            myAniControll();
        }
    }
    //bear skill function-揮魚
    public void myBearSkill_BC_FishWave() { myAniMod = 11; }
    //bear skill function-跳打
    public void myBearSkill_BC_JumpHit() { myAniMod = 10; }
    //bear skill function-吃魚
    public void myBearSkill_SP_EatFish()
    {
        if (isLeggood) {
            if (myAniMod == 13) { }
            else if (myAniMod == 14) { }
            else { myAniMod = 12; }
        }
        else {
            if (myAniMod == 31) { }
            else if (myAniMod == 32) { }
            else { myAniMod = 30; }

        }
        
    }
    //bear skill function-迴旋斬
    public void myBearSkill_SP_GyroHit()
    {
        if (myAniMod == 16) { }
        else if (myAniMod == 17) { }
        else if (myAniMod == 20) { }
        else { myAniMod = 15; }
    }
    //Monster AI Tree - 熊
    public void myBearAttackMod()
    {
        if (GameObject.Find("Morale_Monster").GetComponent<Image>().fillAmount < 0.2 && isLeggood)
        {//20%以下時-------------------------------
            if (isCDTtime_gyrohit)
            {
                if (myskillCDTimer_grohit > myskillCDTimer_grohit)
                {
                    myskillCDTimer_grohit = 0;
                    isCDTtime_gyrohit = false;
                }
                else {
                    myskillCDTimer_grohit += Time.deltaTime;
                    if (isCDTtime_eatfish)
                    {
                        if (myskillCDTimer_eatfish > myskillCDTime_eatfish)
                        {
                            myskillCDTimer_eatfish = 0;
                            isCDTtime_eatfish = false;
                        }
                        else {
                            myskillCDTimer_eatfish += Time.deltaTime;
                            if (isCDTtime_jumphit)
                            {
                                if (myskillCDTimer_jumphit > myskillCDTime_jumphit)
                                {
                                    myskillCDTimer_jumphit = 0;
                                    isCDTtime_jumphit = false;
                                }
                                else {
                                    myskillCDTimer_jumphit += Time.deltaTime;
                                    myBearModControll();
                                }
                                if (isCDTtime_wave)
                                {
                                    if (myskillCDTimer_wave > myskillCDTime_wave)
                                    {
                                        isCDTtime_wave = false;
                                        myskillCDTimer_wave = 0;
                                    }
                                    else {
                                        myskillCDTimer_wave += Time.deltaTime;
                                        myBearModControll();
                                    }
                                }
                                else {
                                    if (isLeggood) {
                                        myBearSkill_BC_FishWave();
                                    }
                                    else { myBearModControll(); }
                                    
                                }
                            }
                            else { myBearSkill_BC_JumpHit(); }
                        }
                    }
                    else {
                        myBearSkill_SP_EatFish();
                    }
                }
            }
            else {myBearSkill_SP_GyroHit();}
        }
        else if (GameObject.Find("Morale_Monster").GetComponent<Image>().fillAmount < 0.4 && isMouthgood)
        {//40%以下時-------------------
            myBearAttackHPMore20();
        }
        else
        {//40%以上時--------------------
            myBearAttackHPMore40();
        }
    }
    public void myBearAttackHPMore20()
    {
        //print("be call");
        if (isCDTtime_eatfish)
        {
            if (myskillCDTimer_eatfish > myskillCDTime_eatfish)
            {
                myskillCDTimer_eatfish = 0;
                isCDTtime_eatfish = false;
            }
            else {
                myskillCDTimer_eatfish += Time.deltaTime;
                myBearAttackHPMore40();
            }
        }
        else {
            myBearSkill_SP_EatFish();
        }
    }
    public void myBearAttackHPMore40()
    {
        if (isCDTtime_jumphit)
        {
            if (myskillCDTimer_jumphit > myskillCDTime_jumphit)
            {
                myskillCDTimer_jumphit = 0;
                isCDTtime_jumphit = false;
            }
            else {
                myskillCDTimer_jumphit += Time.deltaTime;
                myBearModControll();
            }
            if (isCDTtime_wave)
            {
                if (myskillCDTimer_wave > myskillCDTime_wave)
                {
                    isCDTtime_wave = false;
                    myskillCDTimer_wave = 0;
                }
                else {
                    myskillCDTimer_wave += Time.deltaTime;
                    myBearModControll();
                }
            }
            else {
                if (isLeggood) {
                    myBearSkill_BC_FishWave();
                }
                else {
                    myBearModControll();
                }
            }
        }
        else {
            if (isLeggood) {
                myBearSkill_BC_JumpHit();
            }
            else {
                myBearModControll();
            }
            
        }
    }
    
    //QTE相關函釋 當isqtetime = true 的那個時候呼叫一次進行部屬
    public void myQTEFN_set()
    {
        isShowQTEUI = true;
        switch (myQTEMod)
        {
            case "A":
                for (int a = 0; a < 5; a++) {
                    GameObject qteUI_1 = Instantiate(myQTETargetUI[0], transform.position, transform.rotation) as GameObject;
                    qteUI_1.GetComponent<onQTEIcon>().myFather = this.gameObject;
                    qteUI_1.transform.parent = GameObject.Find("Canvas").transform;
                    Vector3 myrandomPos = GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myUICenter.transform.position;
                    myrandomPos.x = Random.Range(myrandomPos.x - 250.0f, myrandomPos.x + 250.0f);
                    myrandomPos.y = Random.Range(myrandomPos.y - 250.0f, myrandomPos.y + 250.0f);
                    qteUI_1.transform.position = myrandomPos;
                }
                /*
                一次出現5個icon
                icon點擊後就會消失

                時間內全打下來就可以阻止怪物發動技能
                時間內如果還有icon怪物成功發動技能

                */
                break;
            case "B":
                /*
                時間內連打達到目標值就可以阻止怪物發動技能
                */
                GameObject qteUI_2 = Instantiate(myQTETargetUI[1], transform.position, transform.rotation) as GameObject;
                qteUI_2.GetComponent<onQTEIcon>().myFather = this.gameObject;
                qteUI_2.transform.parent = GameObject.Find("Canvas").transform;
                qteUI_2.transform.position = GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myUICenter.transform.position;

                break;
            case "C":
          

                /*
                qte開始後依序出現8個icon
                icon內會有倒數計時的數字
                在倒數計時前要點到
                依序點玩
                成功怪物就不會施放技能
                */
                //if (Input.GetKeyDown(KeyCode.Space)) { myQTETouchCountFN(); }
                break;
            default:
                print("你忘記設定QTE的ABC模式囉！！");
                break;
        }
    }
    public void myQTEFN_check()
    {
        isShowQTEUI = false;
        myAniam.speed = 1;
        switch (myQTEMod)
        {
            case "A":
                if (myQTE_A_Count == 5)
                {
                    if (isLeggood) { myAniMod = 34; }
                    else { myAniMod = 33; }
                    isCDTtime_eatfish = true;
                    myQTE_A_Count = 0;
                    print("qte a 成功");
                }
                else {
                    if (isLeggood) { myAniMod = 13; }
                    else { myAniMod = 31; }
                    isCDTtime_eatfish = true;
                    myQTE_A_Count = 0;
                    print("qte a fail");
                }
                break;
            case "B":
                if (myQTE_B_Count > myQTE_B_TargetValue)
                {
                    if (isLeggood) { myAniMod = 34; }
                    else { myAniMod = 33; }
                    print("qte B 成功");
                    isCDTtime_eatfish = true;
                    myQTE_B_Count = 0;
                }
                else {
                    if (isLeggood) { myAniMod = 13; }
                    else { myAniMod = 31; }
                    myQTE_B_Count = 0;
                    isCDTtime_eatfish = true;
                    print("qte B fail");
                }
                break;
            case "C":
                if (myQTE_C_Count == 8)
                {
                    if (isLeggood) { myAniMod = 34; }
                    else { myAniMod = 33; }
                    isCDTtime_eatfish = true;
                    myQTE_C_Count = 0;
                    print("qte C 成功");
                }
                else {
                    if (isLeggood) { myAniMod = 13; }
                    else { myAniMod = 31; }
                    isCDTtime_eatfish = true;
                    myQTE_C_Count = 0;
                    print("qte C fail");
                }
                break;
            default:
                print("你忘記設定QTE的ABC模式囉！！");
                break;
        }
    }
    public void myQTEFN_C() {
        if (myQTEMod == "C") {
            GameObject qteUI_3 = Instantiate(myQTETargetUI[2], transform.position, transform.rotation) as GameObject;
            qteUI_3.GetComponent<onQTEIcon>().myTimer = myQTE_C_ActionTime;
            qteUI_3.GetComponent<onQTEIcon>().myFather = this.gameObject;
            qteUI_3.transform.parent = GameObject.Find("Canvas").transform;
            Vector3 myrandomPos = GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myUICenter.transform.position;
            myrandomPos.x = Random.Range(myrandomPos.x - 250.0f, myrandomPos.x + 250.0f);
            myrandomPos.y = Random.Range(myrandomPos.y - 250.0f, myrandomPos.y + 250.0f);
            qteUI_3.transform.position = myrandomPos;
        }
        else {
        }
        
    }
    //QTE function 連打
    public void myQTEFN_B()
    {
        myQTE_B_Count++;
    }

    //怪物模式控制(待機用+復原CD計時)
    public void myBearModControll()
    {//腿好嘴好-------------------------------------------------------------------1
        if (isLeggood && isMouthgood)
        {
            if (myLegGetHurtValue >= myLegGetHurtValue_Full)//如果腿的血沒有了，播放腿殘動畫
            {
                myAniMod = 25;
            }
            else if (myMouthGetHurtValue >= myMouthGetHurtValue_Full)//如果嘴巴的血沒有了，播放嘴殘動畫
            {
                isMouthgood = false;
                //myAniMod = 61;
            }
            else if (myHeadGetHurtValue >= myHeadGetHurtValue_Full)//
            {
                if (myAniMod == 20) { }
                else if (myAniMod == 21) { }
                else { myAniMod = 19; }
            }
            else {//播放好腳好嘴的待機動作
                if (isUnderAttack)
                {

                }
                else { }
                myAniMod = 0;
            }
        }
        else if (isLeggood && !isMouthgood)
        {
            if (myMouthResumeTimer > myMouthResumeTimerTarget)
            {
                myMouthResumeTimer = 0;
                myMouthGetHurtValue = 0;
                isMouthgood = true;
            }
            else if (myLegGetHurtValue >= myLegGetHurtValue_Full)//如果腳的血沒了，播放腳殘動畫
            {
                myAniMod = 25;
            }
            else {
                myMouthResumeTimer += Time.deltaTime;
                myAniMod = 0;
            }

        }
        else if (!isLeggood && isMouthgood)
        {
            if (myLegResumeTimer > myLegResumeTimerTarget)
            {
                myAniMod = 28;
            }
            else if (myMouthGetHurtValue >= myMouthGetHurtValue_Full)//如果嘴的血沒了，播放嘴殘動畫
            {
                isMouthgood = false;
                //myAniMod = 62;
            }
            else {
                myLegResumeTimer += Time.deltaTime;
                myAniMod = 29;
            }
        }
        else if (!isLeggood && !isMouthgood)
        {
            if (myLegResumeTimer > myLegResumeTimerTarget)
            {
                myAniMod = 28;
            }
            else if (myMouthResumeTimer > myMouthResumeTimerTarget)//如果嘴的血沒了，播放嘴殘動畫
            {
                myMouthResumeTimer = 0;
                myMouthGetHurtValue = 0;
                isMouthgood = true;
            }
            else {
                myLegResumeTimer += Time.deltaTime;
                myMouthResumeTimer += Time.deltaTime;
                myAniMod = 23;
            }
        }
    }
    //怪物動畫控制器
    public void myAniControll()
    {
        switch (myAniMod)
        {
            case 0://idle
                if (!isMouthgood && isBellygood)//嘴壞肚好
                {
                    if (myIdleRandom > 50) { myAniam.Play("idle_attack"); }
                    else { myAniam.Play("breaking_mouth"); }
                }
                else if (!isMouthgood && !isBellygood)//嘴壞肚壞
                {
                    if (myIdleRandom > 33) { myAniam.Play("idle_attack"); }
                    else if (myIdleRandom > 66) { myAniam.Play("breaking_belly"); }
                    else { myAniam.Play("breaking_mouth"); }
                }
                else if (isMouthgood && !isBellygood)//嘴好肚壞
                {
                    if (myIdleRandom > 50) { myAniam.Play("idle_attack"); }
                    else { myAniam.Play("breaking_belly"); }
                }
                else {myAniam.Play("idle_attack");}
                break;
            case 1:
                myAniam.Play("idle_basic");
                break;
            case 2:
                myAniam.Play("dead_basic");
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
                myAniam.Play("walk_ready");
                break;
            case 8:
                myAniam.Play("walk_loop");
                break;
            case 9:
                myAniam.Play("walk_end");
                break;

            //-----------------以下為技能相關動作
            case 10:
                myAniam.Play("sk_bc_jumphit");
                break;
            case 11:
                myAniam.Play("sk_bc_twohandwavefish");
                break;

            //吃魚相關動作-------------------站著吃--------------------------
            case 12:
                myAniam.Play("sk_sp_eatfigh_ready");
                break;
            case 13:
                if (myEatFishLoopTimer > myEatFishLoopTime)
                {
                    myEatFishLoopTimer = 0;
                    myAniMod = 14;
                }
                else {
                    myAniam.Play("sk_sp_eatfigh_eating");
                    myEatFishLoopTimer += Time.deltaTime;
                }
                break;
            case 14:
                myAniam.Play("sk_sp_eatfigh_end");
                break;
            case 34:
                myAniam.Play("sk_sp_eatfish_QTEfail");
                break;
            //吃魚相關動作-------------------坐著吃--------------------------
            case 30:
                //myAniam.speed = 0.1f;
                myAniam.Play("sk_sp_eatfish_LBs_ready");
                break;
            case 31:
                if (myEatFishLoopTimer > myEatFishLoopTime)
                {
                    myEatFishLoopTimer = 0;
                    myAniMod = 14;
                }
                else {
                    myAniam.Play("sk_sp_eatfish_LBs_eating");
                    myEatFishLoopTimer += Time.deltaTime;
                }
                break;
            case 32:
                myAniam.Play("sk_sp_eatfish_LBs_end");
                break;
            case 33:
                myAniam.Play("sk_sp_eatfish_LBs_QTEfail");
                break;
            //迴旋展相關動作---------------------------------------------
            case 15:
                myAniam.Play("sk_sp_rollcut_ready");
                break;
            case 16:
                if (myGrohitLoopTimer > myGrohitLoopTime)
                {
                    myGrohitLoopTimer = 0;
                    myAniMod = 17;
                }
                else {
                    myGrohitLoopTimer += Time.deltaTime;
                    myAniam.Play("sk_sp_rollcut_rolling");
                }
                break;
            case 17:
                myAniam.Play("sk_sp_rollcut_dizzing");
                break;
            case 18:
                myAniam.Play("sk_sp_rollcut_dizzing_resume");
                break;
            //---------------------------------殘障系列動作
            case 19:
                myAniam.Play("breaking_head_fighthitheadtodizzing");
                break;
            case 20:
                if (myHeadResumeTimer > myHeadResumeTimerTarget)
                {
                    myHeadResumeTimer = 0;
                    myAniMod = 21;
                }
                else {
                    myAniam.Play("breaking_head_fighthithead_land_dizzing");
                    myHeadResumeTimer += Time.deltaTime;
                    //myBearAttackHPMore20();
                }
                break;
            case 21:
                myAniam.Play("breaking_head_fighthithead_dizzing_resume");
                break;
            case 22:
                myAniam.Play("breaking_belly");
                break;
            case 23:
                myAniam.Play("breaking_LBs_belly");
                break;
            case 24:
                myAniam.Play("breaking_LBs_mouth");
                break;
            case 25:
                myAniam.Play("breaking_leg");
                break;
            case 26:
                myAniam.Play("breaking_mouth");
                break;
            case 27:
                myAniam.Play("dead_LB");
                break;
            case 28:
                myAniam.Play("resume_leg");
                break;
                
            case 29://腿殘相關待機--------------
                if (!isMouthgood && isBellygood)
                {
                    if (myIdleRandom > 50) { myAniam.Play("idle_LBs"); }
                    else { myAniam.Play("breaking_LBs_mouth"); }
                }
                else if (!isMouthgood && !isBellygood)
                {
                    if (myIdleRandom > 33) { myAniam.Play("idle_LBs"); }
                    else if (myIdleRandom > 66) { myAniam.Play("breaking_LBs_belly"); }
                    else { myAniam.Play("breaking_LBs_mouth"); }
                }
                else if (isMouthgood && !isBellygood)
                {
                    if (myIdleRandom > 50) { myAniam.Play("idle_LBs"); }
                    else { myAniam.Play("breaking_LBs_belly"); }
                }
                else {myAniam.Play("idle_LBs");}
                break;
            case 35:
                myAniam.Play("behit_basic");
                break;
            case 36:
                myAniam.Play("angry_basic");
                break;
            case 37:
                myAniam.Play("behit_LBs");
                break;
            case 38:
                myAniam.Play("angry_LBs");
                break;
            default:
                break;
        }
    }

    //on Monster KeyFram event function
    public void LastFram_2_FN() {
        print("LastFram_2_FN() { be call");
        myFatherObject.GetComponent<onMonsterVer3>().isMeDead = true;
        if (myFatherObject.GetComponent<onMonsterVer3>().isBoss)
        {
            if (isHeadHaveBeBreak) { GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount_All += myHeadBreakScore; }
            if (isLegHaveBeBreak) { GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount_All += myLegBreakScore; }
            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount_All += myIceBearDeadScore;
            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLevelClear.SetActive(true);
        }
        else {
            if (isHeadHaveBeBreak) { GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount += myHeadBreakScore; }
            if (isLegHaveBeBreak) { GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount += myLegBreakScore; }
            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount += myIceBearDeadScore;
            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myEventClear.SetActive(true);
        }
    }
    public void LastFram_10_FN() { isCDTtime_jumphit = true; }
    public void LastFram_11_FN() { isCDTtime_wave = true; }
    //----------站著吃魚相關-----------
    public void FirstFram_12_FN()
    {
        myAniam.speed = 0.1f;
        isQTETime = true;
        myQTEFN_set();
        GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().isMoveTime = true;
    }
    public void LastFram_12_FN(){myQTEFN_check();}
    public void LastFram_14_FN()
    {
        isQTETime = false;
        isCDTtime_eatfish = true;
    }
    public void LastFram_34_FN()
    {
        isQTETime = false;
        isCDTtime_eatfish = true;
    }
    //----------坐著吃魚相關-----------
    public void FirstFram_30_FN()
    {
        myAniam.speed = 0.1f;
        isQTETime = true;
        myQTEFN_set();
        GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().isMoveTime = true;
    }
    public void LastFram_30_FN(){myQTEFN_check();}
    public void LastFram_32_FN()
    {
        isQTETime = false;
        isCDTtime_eatfish = true;
    }
    public void LastFram_33_FN()
    {
        isQTETime = false;
        isCDTtime_eatfish = true;
    }
    //----------------------
    public void LastFram_15_FN() { myAniMod = 16; }
    public void LastFram_17_FN() { myAniMod = 20; }
    //public void LastFram_18_FN() { isCDTtime_gyrohit = true; }
    public void LastFram_19_FN() { myAniMod = 20; }
    public void LastFram_21_FN()
    {
        isCDTtime_gyrohit = true;
        isHeadgood = true;
        myHeadGetHurtValue = 0;
        myAniMod = 0;
    }
    public void LastFram_LGIdle_FN() { myIdleRandom = Random.RandomRange(0, 101); }
    public void LastFram_25_FN() {
        print("last fram 25 be call");
        isLeggood = false;
    }
    public void LastFram_28_FN()
    {
        isLeggood = true;
        myLegResumeTimer = 0;
        myLegGetHurtValue = 0;
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