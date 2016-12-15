using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class onBigeyeForAniControllVer2 : MonoBehaviour {
    public int myAniMod;
    public Animator myAniam;
    public GameObject myFatherObject;//父物件
    [Header("死亡積分")]
    public int myBigeyeDeadScore;
    [Header("大眼積分")]
    public int myBigeyeBreakScore;
    [Header("翅膀積分")]
    public int myWingBreakScore;

    [Header("大眼耐久度(滿)")]
    public float myBigeyeGetHurtValue_Full;
    [Header("大眼耐久度")]
    public float myBigeyeGetHurtValue;
    [Header("大眼是否被破壞過")]
    public bool isBigeyeHaveBeBreak;
    [Header("大眼復原時間")]
    public float myBigeyeResumeTimerTarget;
    public float myBigeyeResumeTimer;

    [Header("翅膀耐久度(滿)")]
    public float myWingGetHurtValue_Full;
    [Header("翅膀耐久度")]
    public float myWingGetHurtValue;
    [Header("翅膀是否被破壞過")]
    public bool isWingHaveBeBreak;
    [Header("翅膀復原時間")]
    public float myWingResumeTimerTarget;
    float myWingResumeTimer;



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

    public bool isStruggleTime;
    public float myStruggleTime;
    public float myStruggleTimer;

    public bool isBeHitTime;
    public float myBeHitTime;
    public float myBeHitTimer;
    void Start()
    {
        isWinggood = true;
        isBigEyegood = true;
        myAniam = gameObject.GetComponent<Animator>();
        myAudioSource = gameObject.GetComponent<AudioSource>();
        myStruggleTime = Random.Range(15, 20);
        myBeHitTime = Random.Range(3, 5);
    }
    void Update()
    {
        if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart&&myFatherObject.GetComponent<onMonsterVer3>().isMeToFight) {
            if (GameObject.Find("Morale_Bar_Monster").GetComponent<Image>().fillAmount == 0)//怪物死翹翹
            { myAniMod = 4;}
            else {
                /*myBigeyeHP = myBigeyeHitpoint.GetComponent<OnLookAtPoint>().myHP;
                myWingHP = myWingHitpoint.GetComponent<OnLookAtPoint>().myHP;*/
                myIsFidgetyTimeFN();
                myBigeyeAttackMod();
            }
            myAniControll();
        }
    }
    public void myIsFidgetyTimeFN() {
        if (isStruggleTime){
            //myAniam.speed = 1.5f;
            if (isBigEyegood) { myAniMod = 30; }
            else { myAniMod = 15; }
        }
        else if (isBeHitTime) {
           
            //myAniam.speed = 1.5f;
            if (isBigEyegood) { myAniMod = 31; }
            else { myAniMod = 15; }
            
        }
        else {
            if (myStruggleTimer >= myStruggleTime){
                myStruggleTime = Random.Range(15, 20);
                myStruggleTimer = 0;
                isStruggleTime = true;
            }
            else {
                myStruggleTimer += Time.deltaTime;
            }

            if (myBeHitTimer >= myBeHitTime) {
                myBeHitTime = Random.Range(3, 5);
                myBeHitTimer = 0;
                isBeHitTime = true;
            }
            else {
                myBeHitTimer += Time.deltaTime;
            }
            myAniMod = 13;
        }
    }
    //技能1眼撞
    public void myBigeyeSkill1_basic_BigeyeAttack()
    {
        if (isBigEyegood) { myAniMod = 26;}
        else { myAniMod = 28;}
    }
    //技能2迴旋
    public void myBigeyeSkill2_basic_BigeyeRotate()
    {
        if (is27CD)
        {
            if (mySkill2Timer > mySkill2CDTimer)
            {
                mySkill2Timer = 0;
                is27CD = false;
            }
            else { mySkill2Timer += Time.deltaTime; }
        }
        if (isBigEyegood) { myAniMod = 27;}
        else { myAniMod = 29;}
    }
    //技能3空中大眼魔法
    public void myBigeyeSkill3_Special_BigeyeMagic_Air()
    {
        myAniMod = 21;
    }
    //技能4地上大眼魔法
    public void myBigeyeSkill3_Special_BigeyeMagic_Ground()
    {
        myAniMod = 24;
    }
    public void myBigeyeAttackMod()
    {
        if (GameObject.Find("Morale_Bar_Monster").GetComponent<Image>().fillAmount < 0.2 && isBigEyegood)//20%以下時
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
                        else {myBigeyeSkill1_basic_BigeyeAttack();}
                    }
                    else {
                        myBigeyeSkill2_basic_BigeyeRotate();
                        myAudioController(2);

                    }
                }
            }
            else {//放大招
                if (isWinggood) { myBigeyeSkill3_Special_BigeyeMagic_Air();
                    myAudioController(5);
                }
                else { myBigeyeSkill3_Special_BigeyeMagic_Ground();
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
        if (isBigEyegood && isWinggood)
        {//眼好翅好-------------------------------------------------------------------1
            //print("if (isBigEyegood && isWinggood)");
            if (myWingGetHurtValue>=myWingGetHurtValue_Full)
            {
                isWingHaveBeBreak = true;
                myAniMod = 22;
                myAudioController(3);
                myAniam.speed = 0.7f;
                //print("bigeye mod here");
            }
            else if (myBigeyeGetHurtValue >= myBigeyeGetHurtValue_Full)
            {
                isBigeyeHaveBeBreak = true;
                myAniMod = 61;
                myAudioController(1);
                myAniam.speed = 0.7f;
            }
            else {
                //myAniMod = 13;
                myIsFidgetyTimeFN();
                myAniam.speed = 0.7f;
            }
        }
        else if (isBigEyegood && !isWinggood)
        {//眼好翅壞-------------------------------------------------------------------2
            if (myWingResumeTimer > myWingResumeTimerTarget)
            {
                myWingGetHurtValue = 0;
                myAniMod = 25;
                myAniam.speed = 0.7f;
            }
            else if (myBigeyeGetHurtValue >= myBigeyeGetHurtValue_Full)
            {
                isBigeyeHaveBeBreak = true;
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
                //myBigeyeHitpoint.GetComponent<OnLookAtPoint>().myHP = myBigeyeFullHP;
                myBigeyeGetHurtValue = 0;
                myAniMod = 16;
                myAniam.speed = 0.7f;
            }
            else if (myWingGetHurtValue >= myWingGetHurtValue_Full)
            {
                isWingHaveBeBreak = true;
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
                myWingGetHurtValue = 0;
                myAniMod = 07;
                myAniam.speed = 0.7f;
            }
            else if (myBigeyeResumeTimer > myBigeyeResumeTimerTarget)
            {
                //myBigeyeResumeTimer = 0;
                //myBigeyeHitpoint.GetComponent<OnLookAtPoint>().myHP = myBigeyeFullHP;
                myBigeyeGetHurtValue = 0;
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
                myAniam.Play("eyebreak_idle");
                break;
            case 1:
                myAniam.Play("AttackIdle_resume");
                break;
            case 2:
                myAniam.Play("bigeyebreak_falldown");
                break;
            case 3:
                myAniam.Play("bigeyebreak_closeeyestruggling");
                break;
            case 4:
                myAniam.Play("bigeyebreak_closeeyedie");
                break;
            case 5:
                myAniam.Play("BigeyeResume_falldown");
                break;
            case 6:
                myAniam.Play("BigeyeResume_closeeyestruggling");
                break;
            case 7:
                myAniam.Play("BigeyeResume_closeeyeflyback");
                break;
            case 8:
                myAniam.Play("BigeyeResume2_falldown");
                break;
            case 9:
                myAniam.Play("BigeyeResume2_closeeyestruggling");
                break;
            case 10:
                myAniam.Play("BigeyeResume2_eyegoodonground");
                break;
            case 11:
                myAniam.Play("idle_basic");
                break;
            case 12:
                myAniam.Play("idleturning");
                break;
            case 13:
                myAniam.Play("idle_attack");
                break;
            case 14:
                myAniam.Play("OpeneyeDie");
                break;
            case 15:
                myAniam.Play("OthereyeBreak_onairshake");//空中閉眼掙扎
                break;
            case 16:
                myAniam.Play("OthereyeBreak_openeye");
                break;
            case 17:
                myAniam.Play("OthereyeBreak_openeyeshake");//空中開演掙扎
                break;
            case 18:
                myAniam.Play("Runready");
                break;
            case 19:
                myAniam.Play("Runing");
                break;
            case 20:
                myAniam.Play("Runstop");
                break;
            case 21:
                myAniam.Play("Skill");
                break;
            case 22:
                myAniam.Play("WingBreak_falldown");
                break;
            case 23:
                myAniam.Play("WingBreak_struggling");
                break;
            case 24:
                myAniam.Play("WingBreak_skillonground");
                break;
            case 25:
                myAniam.Play("WingBreak_resume");
                break;
            case 26:
                myAniam.Play("Attack1");
                break;
            case 27:
                myAniam.Play("Attack2");
                break;
            case 28:
                myAniam.Play("Attack1_closeeye");
                break;
            case 29:
                myAniam.Play("Attack2_closeeye");
                break;
            case 30:
                myAniam.Play("fidgety");
                break;
            case 31:
                myAniam.Play("behit");
                break;
            case 61:
                myAniam.Play("OthereyeBreak_closeeye");
                break;
            case 62:
                myAniam.Play("BigeyeResume2_groundeyegoodtoeyebad");
                break;
            case 63:
                myAniam.Play("bigeye_eyebreakfalldown");
                break;
            default:
                break;
        }
    }
    public void LastFram_idle_attack() {
        for (int a = 0; a < 5; a++) {
            myFatherObject.GetComponent<onMonsterVer3>().myHotPointList[a].gameObject.transform.position = myFatherObject.GetComponent<onMonsterVer3>().MyHitpointList[a].gameObject.transform.position;
        }
        GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().isMoveTime = true;
    }
    public void LastFram_winbreak() {
        for (int a = 0; a < 5; a++)
        {
            myFatherObject.GetComponent<onMonsterVer3>().myHotPointList[a].gameObject.transform.position = myFatherObject.GetComponent<onMonsterVer3>().MyHitpointList[a].gameObject.transform.position;
        }
        GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().isMoveTime = true;
    }
    public void LastFram_WingBreak_resume() {
        GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().isMoveTime = true;
        isWinggood = true;
        myWingResumeTimer = 0;
    }
    public void LastFram_Bigeyeresume2_eyegoodonground() {
        isBigEyegood = true;
        myBigeyeResumeTimer = 0;
    }
    public void LastFram_Bigeyeresume_closeeyeflyback() {
        GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().isMoveTime = true;
        isNeedToPlayBigeyeBreakMovie = false;
        isWinggood = true;
        myWingResumeTimer = 0;
    }
    public void LastFram_WingBreak_falldown() {
        GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().isMoveTime = true;
        isWinggood = false;
        myWingResumeTimer = 0;
    }
    public void LastFram_othereyebreak_openeye() {
        isBigEyegood = true;
        myBigeyeResumeTimer = 0;
    }
    public void LastFram_Bigeyeresume2_falldown() {
        GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().isMoveTime = true;
        isWinggood = false;
    }
    public void LastFram_othereyebreak_closeeye() {
        isBigEyegood = false;
    }
    public void LastFram_62() {
        isBigEyegood = false;
    }
    public void LastFram_26() {
        is26CD = true;
        myFindAllMQAndAttack_Skill1();
        myAniam.speed = 1;
        //myAudioSource.enabled = false;
    }
    public void LastFram_27() {
        is27CD = true;
        myFindAllMQAndAttack_Skill2();
        myAniam.speed = 1;
        //myAudioSource.enabled = false;
    }
    public void LastFram_24() {
        is21CD = true;
        myFindAllMQAndAttack_Skill3();
        //myAudioSource.enabled = false;
    }
    public void LastFram_21() {
        is21CD = true;
        myFindAllMQAndAttack_Skill3();
        //myAudioSource.enabled = false;
    }
    public void bigeye_eyebreakfalldown_FirstFram() { isNeedToPlayBigeyeBreakMovie = true; }
    public void bigeye_eyebreakfalldown_lastFram() {
        myAniMod = 7;
    }
    public void attack1middlewaite_1(){myAniam.speed = 0.5f;}
    public void attack1middlewaite_2(){myAniam.speed = 1.5f;
        myAudioController(0);
    }
    public void attack2middlewaite_1() { myAniam.speed = 0.5f; }
    public void attack2middlewaite_2() { myAniam.speed = 1.15f; }

    public void LastFram_30() { isStruggleTime = false; }
    public void LastFram_31() { isBeHitTime = false; }
    public void bigeyebreak_closeeyedie() {
        myFatherObject.GetComponent<onMonsterVer3>().isMeDead = true;
        if (myFatherObject.GetComponent<onMonsterVer3>().isBoss) {
            if (isBigeyeHaveBeBreak) { GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount_All += myBigeyeBreakScore; }
            if (isWingHaveBeBreak) { GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount_All += myWingBreakScore; }
            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount_All += myBigeyeDeadScore;

            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLevelClear.SetActive(true);
        }
        else {
            if (isBigeyeHaveBeBreak) { GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount += myBigeyeBreakScore; }
            if (isWingHaveBeBreak) { GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount += myWingBreakScore; }
            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount += myBigeyeDeadScore;
            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myEventClear.SetActive(true);
        }
    }
    public void myFindAllMQAndAttack_Skill1() {
       /* if (GameObject.Find("MainCamera").GetComponent<OnCameraForShootMQ>().isSuperStarTime) { }
        else {*/
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
                        myMQ[a].GetComponent<onMQVer3>().myHitflyAwayTime = Random.Range(0.5f, 2.0f);
                        myMQ[a].GetComponent<onMQVer3>().myHP -= mySkill1Hurtpoint;
                    }
                }
            }
       // }
    }
    public void myFindAllMQAndAttack_Skill2()
    {
        GameObject[] myMQ = GameObject.FindGameObjectsWithTag("MQ");
        if (myMQ != null) {
            for (int a = 0; a < myMQ.Length; a++)
            {
                if (myMQ[a].GetComponent<onMQVer3>().isAttackTime)
                {
                    myMQ[a].GetComponent<onMQVer3>().isBeHit = true;
                    myMQ[a].GetComponent<onMQVer3>().isHitFlyAway = true;
                    myMQ[a].GetComponent<onMQVer3>().myHitflyAwayTime = Random.Range(0.5f, 2.0f);
                    myMQ[a].GetComponent<onMQVer3>().myHP -= mySkill1Hurtpoint;
                }
            }
        }
        else {}
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

/*
 if (Input.GetKeyDown("."))
        {
            // myAniMod = 999;
            myAniMod++;
            if (myAniMod > 27) { myAniMod = 0; }
        }
        if (Input.GetKeyDown(","))
        {
            //myAniMod = 999;
            myAniMod--;
            if (myAniMod < 0) { myAniMod = 27; }
        }
*/
