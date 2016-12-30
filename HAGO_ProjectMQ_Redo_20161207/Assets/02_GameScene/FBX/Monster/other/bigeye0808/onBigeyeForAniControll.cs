using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class onBigeyeForAniControll : MonoBehaviour {
    public int myAniMod;
    public int myModControll;
    public Animator myAniam;
    public Text mytextGroup;
    public Text mytextAnimMod;
    public GameObject myFatherObject;//父物件
    [Header("大眼血量")]
    public float myBigeyeHP;
    [Header("大眼復原時間")]
    public float myBigeyeResumeTimer;
    [Header("翅膀血量")]
    public float myWingHP;
    [Header("翅膀復原時間")]
    public float myWingResumeTimer;
    [Header("複眼血量")]
    public float myOtherEyeHP;
    [Header("複眼復原時間")]
    public float myOtherEyeResumeTimer;


    public bool isBigEyegood;
    public bool isWinggood;
    public bool isOtherEyegood;

    public float mySkill1CDTimer;
    public float mySkill1Timer;
    public float mySkill2CDTimer;
    public float mySkill2Timer;
    public float mySkill3CDTimer;
    public float mySkill3Timer;
    public void myBigeyeSkill1_basic_BigeyeAttack() {//技能1眼撞
        GameObject[] myMQ = GameObject.FindGameObjectsWithTag("MQ");
        for (int a = 0; a < myMQ.Length; a++)
        {
            if (myMQ[a].GetComponent<onMQVer3>().myTargetPoint.name == "hitpoint-1") {
                myMQ[a].GetComponent<onMQVer3>().isBeHit = true;
                //myMQ[a].GetComponent<onMQVer3>().myHP--;
            }
        }
    }
    public void myBigeyeSkill2_basic_BigeyeRotate() {//技能2迴旋
        GameObject[] myMQ = GameObject.FindGameObjectsWithTag("MQ");
        for (int a = 0; a < myMQ.Length; a++) {
            myMQ[a].GetComponent<onMQVer3>().myHP--;
        } 
    }
    public void myBigeyeSkill3_Special_BigeyeMagic() {//技能3大眼魔法
        GameObject[] myMQ = GameObject.FindGameObjectsWithTag("MQ");
        for (int a = 0; a < myMQ.Length; a++)
        {
            myMQ[a].GetComponent<onMQVer3>().myHP--;
        }
    }
    public void myBigeyeAttackMod() {
        if (GameObject.Find("Morale_Monster").GetComponent<Image>().fillAmount < 0.2 && isBigEyegood){
            myBigeyeSkill3_Special_BigeyeMagic();
        }
        else {
            if (isWinggood) { myBigeyeSkill2_basic_BigeyeRotate(); }
            else { myBigeyeSkill1_basic_BigeyeAttack(); }
        }
    }
    // Use this for initialization
    void Start () {
        myAniam = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //mytextGroup.text = "第「" + myModControll + "」組的組合動畫";
        //mytextAnimMod.text = "動畫編號「" + myAniMod + "」";
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
        
        myAniControll();
        //myModController();
    }
    public void myBigeyeModControll() {
        if (isBigEyegood && isWinggood){//眼好翅好---------------------------------------1
            if (myWingHP <= 0) {
                myAniMod = 22;
            }
            else if (myBigeyeHP <= 0) {
                myAniMod = 16;//到轉播放，如果無法就直接=false
            }
            else {
                myAniMod = 13;
            }
        }
        else if (isBigEyegood && !isWinggood){//眼好翅壞---------------------------------2
            if (myWingResumeTimer > 10) {
                //myWingResumeTimer = 0;
                myWingHP = 100;
                myAniMod = 25;
            }
            else {
                myWingResumeTimer += Time.deltaTime;
            }
            if (myBigeyeHP <= 0) {
                myAniMod = 16;//到轉播放，如果無法就直接=false
            }
            else {
                myAniMod = 23;
            }
        }
        else if (!isBigEyegood && isWinggood){//眼壞翅好----------------------------------3

            if (myBigeyeResumeTimer > 10) {
                myBigeyeResumeTimer = 0;
                myAniMod = 16;
            }
            else {myBigeyeResumeTimer += Time.deltaTime;}
            if (myWingHP <= 0) {
                myAniMod = 08;
            }
            else {
                myAniMod = 00;
            }
        }
        else if (!isBigEyegood && !isWinggood){//眼壞翅壞----------------------------------4
            if (myWingResumeTimer > 10){
                //myWingResumeTimer = 0;
                myWingHP = 100;

            }
            else {myWingResumeTimer += Time.deltaTime;}
            if (myBigeyeResumeTimer > 10) {
                //myBigeyeResumeTimer = 0;
                myBigeyeHP = 100;

            }
            else { myBigeyeResumeTimer += Time.deltaTime; }
            myAniMod = 03;
        }
    }
    public void myAniControll() {
        switch (myAniMod) {
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
                myAniam.Play("OthereyeBreak_onairshake");
                break;
            case 16:
                myAniam.Play("OthereyeBreak_openeye");
                break;
            case 17:
                myAniam.Play("OthereyeBreak_openeyeshake");
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

            default:
                break;

        }
    }
    public void myModController() {
        switch (myModControll) {
            case 1:
                mymod1();
                break;
            case 2:
                mymod2();
                break;
            case 3:
                mymod3();
                break;
            case 4:
                mymod4();
                break;
            case 5:
                mymod5();
                break;
            case 6:
                mymod6();
                break;
            case 7:
                mymod7();
                break;
            case 8:
                mymod8();
                break;
            case 9:
                mymod9();
                break;
            case 10:
                mymod10();
                break;
            case 11:
                mymod11();
                break;
            case 12:
                mymod12();
                break;
            case 13:
                mymod13();
                break;
            case 14:
                mymod14();
                break;
            case 15:
                mymod15();
                break;
            case 16:
                mymod16();
                break;
            case 17:
                mymod17();
                break;
            case 18:
                mymod18();
                break;
            case 19:
                mymod19();
                break;
            case 20:
                mymod20();
                break;
            case 21:
                mymod21();
                break;
            case 22:
                mymod22();
                break;
        }
    }
    public void mymod1() {
        if (myAniMod == 12) { myAniMod = 12; }
        else { myAniMod = 11; }
    }
    public void mymod2() {
        if (myAniMod == 19) { myAniMod = 19; }
        else if (myAniMod ==20 ) { myAniMod = 20; }
        else { myAniMod = 18; }
    }
    public void mymod3() { myAniMod = 13; }
    public void mymod4() { myAniMod = 26; }
    public void mymod5() { myAniMod = 27; }
    public void mymod6() {
        if (myAniMod == 3) { myAniMod = 3; }
        else if (myAniMod == 7) { myAniMod = 7; }
        else { myAniMod = 2; }
    }
    public void mymod7() {
        if (myAniMod == 3) { myAniMod = 3; }
        else { myAniMod = 23; }
    }
    public void mymod8() {
        if (myAniMod == 16) { myAniMod = 16; }
        else { myAniMod = 0; }
    }
    public void mymod9()
    {
        if (myAniMod == 23) { myAniMod = 23; }
        else { myAniMod = 3; }
    }
    public void mymod10() {
        if (myAniMod == 23) { myAniMod = 23; }
        else { myAniMod = 22; }
    }
    public void mymod11() {
        if (myAniMod == 25) { myAniMod = 25; }
        else { myAniMod = 23; }
    }
    public void mymod12() {
        if (myAniMod == 7) { myAniMod = 7; }
        else if (myAniMod == 0) { myAniMod = 0; }
        else { myAniMod = 3; }
    }
    public void mymod13() {
        if (myAniMod == 23) { myAniMod = 23; }
        else if (myAniMod == 14) { myAniMod = 14; }
        else { myAniMod = 22; }
    }
    public void mymod14() {
        if (myAniMod == 23) { myAniMod = 23; }
        else if (myAniMod == 4) { myAniMod = 4; }
        else { myAniMod = 22; }
    }
    public void mymod15() {
        if (myAniMod == 14) { myAniMod = 14; }
        else { myAniMod = 23; }
    }
    public void mymod16() {
        if (myAniMod == 4) { myAniMod = 4; }
        else { myAniMod = 3; }
    }
    public void mymod17() { myAniMod = 21; }
    public void mymod18() {
        if (myAniMod == 24) { myAniMod = 24; }
        else { myAniMod = 23; }
    }
    public void mymod19() { myAniMod = 17; }
    public void mymod20() { myAniMod = 23; }
    public void mymod21() { myAniMod = 15; }
    public void mymod22() { myAniMod = 3; }

    //---------------------------------
    public void mod1_1() {
        Debug.Log("mod1_1 be call");
        myAniMod = 12; }
    public void mod2_1() {/* myAniMod = 19;*/ }
    public void mod2_2()
    {/* myAniMod = 20; */}
    public void mod6_1() {/* myAniMod = 3; */}
    public void mod6_2() {
        /*
        if (myModControll == 6) { myAniMod = 7; }
        else if (myModControll == 9) { myAniMod = 23; }
        else if (myModControll == 12) { myAniMod = 7; }
        else if (myModControll == 16) { myAniMod = 4; }
        else { }*/
    }
    public void mod7_1() {
        /*
        if (myModControll == 7) { myAniMod = 3; }
        else if (myModControll == 11) { myAniMod = 25; }
        else if (myModControll == 13) { myAniMod = 14; }
        else if (myModControll == 14) { myAniMod = 4; }
        else if (myModControll == 15) { myAniMod = 14; }
        else if (myModControll == 18) { myAniMod = 24; }
        else { }
        */
    }
    public void mod8_1() {
        /*
        if (myModControll == 8) { myAniMod = 16; }
        else { }*/
    }
    public void mod9_1() {
       /* if (myModControll == 9) { myAniMod = 23; }
        else if (myModControll == 16) { myAniMod = 4; }
        else { }*/
    }
    public void mod10_1() {
      /*  if (myModControll == 10) { myAniMod = 23; }
        else if (myModControll == 13) { myAniMod = 23; }
        else if (myModControll == 14) { myAniMod = 23; }
        else { }*/
    }
    public void mod11_1() { /*myAniMod = 25; */}
    public void mod12_1() {
       /* if (myModControll == 12) { myAniMod = 7; }
        else { }*/
    }
    public void mod12_2() {
       /* if (myModControll == 12) { myAniMod = 0; }
        else { }*/
    }
    public void mod13_1() {/* myAniMod = 23;*/ }
    public void mod13_2() { /*myAniMod = 14;*/ }
    public void mod14_1() { /*myAniMod = 23;*/ }
    public void mod14_2()
    { /*myAniMod = 4; */}
    public void mod15_1() { /*myAniMod = 14; */}
    public void mod16_1() { /*myAniMod = 4; */}
    public void mod18_1() { /*myAniMod = 24; */}
}
