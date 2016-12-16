using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class OnCameraForShootMQ : MonoBehaviour
{
    [Header("蚊子出生點清單")]
    public GameObject[] myFirePoint;
    [Header("蚊子清單")]
    public GameObject[] myBullet;
    [Header("各隊蚊子種類")]
    public int myTeamAMQTypeID;
    public int myTeamBMQTypeID;
    public int myTeamCMQTypeID;
    public int myTeamDMQTypeID;
    public int myTeamEMQTypeID;

    public int myTeamBTNClick;
    float myTimer;
    public Text MQCount;
    public int myHowManyMQOnScene;
    [Header("=======================")]
    public int[] myTeamMQCount;
    public GameObject[] myTeamAmount_Image;
    [Header("=======================")]
    public bool[] myWhichTeam;
    public int myTeamID;
    [Header("生一隻蚊子的時間")]
    public float myPutMQTime;
    float myPutMQTimer;
    bool isPutMQTime;
//    [Header("=======================")]
    [System.Serializable]
    public struct MQSkillSettingDetail
    {
        [Header("技能是否發動")]
        public bool isSkillWorking;
        [Header("技能是否CD")]
        public bool isSkillCDTime;
        [Header("技能CD時間")]
        public float mySkillCDTime;
        public float mySkillCDTimer;
        [Header("蚊子需求數量")]
        public int myMQNeedAmount;
        [Header("=======================")]
        [Header("傷害目標:0怪物1我方")]
        public int mySkillTargetType;
        [Header("傷害型別:0瞬發1持續")]
        public int mySkillStateType;
        [Header("持續行傷害秒數")]
        public float mySkillKeepTime;
        public float mySkillKeepTimer;
        [Header("=======================")]
        [Header("傷害種類:0點數1士氣")]
        public int mySkillHurtRangeOfType;
        [Header("傷害點數")]
        public int mySkillHurtValue_Point;
        [Header("傷害氣勢(%)")]
        public int mySkillHurtValue_Morale;
    }
    [System.Serializable]
    public struct Pathfinding
    {
        [Header("蚊子技能_士兵")]
        public MQSkillSettingDetail MQ01_skill;
        [Header("蚊子技能_護士")]
        public MQSkillSettingDetail MQ02_skill;
        [Header("蚊子技能_美足")]
        public MQSkillSettingDetail MQ03_skill;
        [Header("蚊子技能_急凍")]
        public MQSkillSettingDetail MQ04_skill;
        [Header("蚊子技能_巫師")]
        public MQSkillSettingDetail MQ05_skill;
        [Header("蚊子技能_病毒")]
        public MQSkillSettingDetail MQ06_skill;
        [Header("蚊子技能_獵人")]
        public MQSkillSettingDetail MQ07_skill;
        [Header("蚊子技能_金盾")]
        public MQSkillSettingDetail MQ08_skill;
        [Header("蚊子技能_炸彈")]
        public MQSkillSettingDetail MQ09_skill;
        [Header("蚊子技能_機械")]
        public MQSkillSettingDetail MQ10_skill;
        [Header("蚊子技能_吟遊詩人")]
        public MQSkillSettingDetail MQ11_skill;
        [Header("蚊子技能_喪屍")]
        public MQSkillSettingDetail MQ12_skill;
        [Header("蚊子技能_德古拉")]
        public MQSkillSettingDetail MQ13_skill;
        [Header("蚊子技能_黑洞")]
        public MQSkillSettingDetail MQ14_skill;
    }
    [Header("蚊子技能相關設定")]
    public Pathfinding myMQSkillSettingMenu;
    [Header("=======================")]
    [Header("我的隊伍選擇圖")]
    public GameObject[] myTeamBTNSelectUI;
    [Header("是否可以施放技能")]
    public bool[] isTeamSkillReady;
    [Header("我的技能按鈕")]
    public GameObject[] mySkillBTN;
    [Header("技能按鈕遮罩(圖)")]
    public Sprite[] mySkillBTN_Sprite;
    [Header("隊伍按鈕遮罩(圖)")]
    public Sprite[] myTeamBTN_hide;
    [Header("技能CD遮罩")]
    public GameObject[] myCDBlack;
    public GameObject[] myskillUI;

    public bool[] isTeamSkillCD;
    public float[] myTeamSkillCDTimer;
    public float[] myTeamSkillCDTime;
    public bool isNurseTime;
    [Header("=======================")]
    [Header("放大縮小相關")]
    public bool[] isSkillBTNJuiceTime;
    public int[] mySkillBTNJuiceMod;
    [Header("技能按鈕後面光暈相關")]
    public bool[] isSkillBtnEdgeTime;
    public int[] mySkillBTNEdgeMod;
    public int[] mySkillBTNEdgeRandom;
    public float[] mySkillBTNEdgeTimer;
    float myfadwaittimer;

    [Header("=======================")]
    [Header("施放蚊子按鈕抖動相關")]
    public int[] mySkillBtnShakeRandom;
    public float[] mySkillBtnShakeTimer;
    [Header("=======================")]



    //-----------

    public AudioClip[] mySoundEffectData;
    public AudioSource myAudioSource;

    //-----auto fire
    public bool isAutoFire;
    public int myAutoFireBulletFullAmount;
    public int myAutoFireBulletAmount;
    public float myAutoFireTime;
    public float myAutoFireTimer;
    public int myAutoFireRandom;
    public GameObject[] myLocalMQList;
    public GameObject myMQSpawnPoint;
    //--------------
   

    void Start()
    {
          myMQSkillSettingMenu.MQ01_skill.isSkillCDTime = true;
          myMQSkillSettingMenu.MQ02_skill.isSkillCDTime = true;
          myMQSkillSettingMenu.MQ03_skill.isSkillCDTime = true;
          myMQSkillSettingMenu.MQ04_skill.isSkillCDTime = true;
          myMQSkillSettingMenu.MQ05_skill.isSkillCDTime = true;
        isPutMQTime = true;
        myPutMQTime = 0.3f;
        myAudioSource = gameObject.GetComponent<AudioSource>();
        for (int a = 0; a < myCDBlack.Length; a++)
        {
         /*   myCDBlack[a].GetComponent<Image>().fillAmount = 1;
            mySkillBTN[a].GetComponent<Button>().enabled = false;
            */
          /*  Color col = mySkillBTN[a].transform.GetChild(1).GetComponent<Image>().color;
            col.a = 0;
            mySkillBTN[a].transform.GetChild(1).GetComponent<Image>().color = col;*/
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        MQCount.text = "場上蚊子數量：" + myHowManyMQOnScene.ToString();
        if (gameObject.GetComponent<onMainCameraVer2>().isNeedToFollow)
        {
            if (GameObject.Find("Morale_Bar_Monster").GetComponent<Image>().fillAmount == 1){print("all MQ is over so you are lose!!!!!!!!!!");}
        }
        if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart) {
            if (GameObject.Find("Morale_Bar_Monster").GetComponent<Image>().fillAmount == 1 || GameObject.Find("Morale_Bar_Monster").GetComponent<Image>().fillAmount == 0) { }
            else {
                if (isAutoFire) {
                    if (myAutoFireTimer > 1 / GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLocalMQ_CreateSpeed)
                    {
                        if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLocalMQ_Amount <= 0) { }
                        else {
                            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLocalMQ_Amount--;
                            myAutoCreatMQ();
                            myAutoFireTimer = 0;
                        }
                    }
                    else {myAutoFireTimer += Time.deltaTime;}
                }   
            }
            myPutMQCheckFN();//用來檢查可以放蚊子了嗎？
            myCheckIsWhichTeam();
           // myTeamCDController();
            myAmountUpdate();//看看各隊伍剩下多少蚊子
            mySkillCheck();//技能檢查
            myWhenNotPressBTN_forfadeout_FN();
            myJuJuFN();
            /*
            if (!isSkillBtnEdgeTime[0]) myBTNShakeFN(0);
            if (!isSkillBtnEdgeTime[1]) myBTNShakeFN(1);
            if (!isSkillBtnEdgeTime[2]) myBTNShakeFN(2);
            if (!isSkillBtnEdgeTime[3]) myBTNShakeFN(3);
            if (!isSkillBtnEdgeTime[4]) myBTNShakeFN(4);
            */
            myBTNShakeFN(0);
            myBTNShakeFN(1);
            myBTNShakeFN(2);
            myBTNShakeFN(3);
            myBTNShakeFN(4);

            /*
            myBTNShake_FN(0);
            myBTNShake_FN(1);
            myBTNShake_FN(2);
            myBTNShake_FN(3);
            myBTNShake_FN(4);
            */
            /*  mySkillCheck_nothide_FN(0);
              mySkillCheck_nothide_FN(1);
              mySkillCheck_nothide_FN(2);
              mySkillCheck_nothide_FN(3);
              mySkillCheck_nothide_FN(4);*/
            mySelectBoxUpdateFN();
        }
    }
    public void myPutMQCheckFN() {
        if (isPutMQTime) { }
        else {
            if (myPutMQTimer > myPutMQTime)
            {
                myPutMQTimer = 0;
                isPutMQTime = true;
            }
            else {
                myPutMQTimer += Time.deltaTime;
            }
        }
        
    }
    public void myBTNShake_FN(int aa) {
        Vector3 aab = mySkillBTN[aa].transform.parent.transform.GetChild(1).gameObject.transform.position;
        Vector3 bbb = mySkillBTN[aa].transform.parent.transform.GetChild(1).gameObject.transform.eulerAngles;
        bbb.z = aab.z;
        mySkillBTN[aa].transform.parent.transform.GetChild(1).gameObject.transform.eulerAngles = bbb;
    }
    public void myJuJuFN() {
        for (int juju = 0; juju < isSkillBTNJuiceTime.Length; juju++)
        {
            //按鈕loading 好 放大縮小
            if (isSkillBTNJuiceTime[juju])
            {
                switch (mySkillBTNJuiceMod[juju])
                {
                    case 0:
                        Vector3 Sca1 = mySkillBTN[juju].GetComponent<RectTransform>().localScale;
                        if (Sca1.x > 1)
                        {
                            mySkillBTNJuiceMod[juju] = 1;
                        }
                        else {
                            Sca1.x += Time.deltaTime * 5;
                            Sca1.y = Sca1.x;
                            mySkillBTN[juju].GetComponent<RectTransform>().localScale = Sca1;
                        }

                      /*  Color a = mySkillBTN[juju].transform.GetChild(1).GetComponent<Image>().color;
                        a.a += Time.deltaTime * 20;
                        mySkillBTN[juju].transform.GetChild(1).GetComponent<Image>().color = a;*/
                        break;
                    case 1:
                        Vector3 Sca2 = mySkillBTN[juju].GetComponent<RectTransform>().localScale;
                        if (Sca2.x < 0.848)
                        {
                            mySkillBTNJuiceMod[juju] = 2;
                        }
                        else {
                            Sca2.x -= Time.deltaTime * 5;
                            Sca2.y = Sca2.x;
                            mySkillBTN[juju].GetComponent<RectTransform>().localScale = Sca2;
                        }
                       /* Color aa = mySkillBTN[juju].transform.GetChild(1).GetComponent<Image>().color;
                        aa.a -= Time.deltaTime * 20;
                        mySkillBTN[juju].transform.GetChild(1).GetComponent<Image>().color = aa;*/
                        break;
                    case 2:
                        isSkillBTNJuiceTime[juju] = false;
                        mySkillBTNJuiceMod[juju] = 0;
                        Vector3 Sca3 = mySkillBTN[juju].GetComponent<RectTransform>().localScale;
                        Sca3.x = 1;
                        Sca3.y = Sca3.x;
                        mySkillBTN[juju].GetComponent<RectTransform>().localScale = Sca3;

                       /* Color aaa = mySkillBTN[juju].transform.GetChild(1).GetComponent<Image>().color;
                        aaa.a = 0;
                        mySkillBTN[juju].transform.GetChild(1).GetComponent<Image>().color = aaa;*/
                        break;
                }
            }

            //技能按鈕後面光暈
            if (isSkillBtnEdgeTime[juju])
            {
                switch (mySkillBTNEdgeMod[juju])
                {
                    case 0:
                        if (mySkillBTN[juju].transform.parent.transform.GetChild(4).GetComponent<Image>().color.a > 1)
                        {
                            mySkillBTNEdgeMod[juju] = 1;
                        }
                        else {
                            Color a = mySkillBTN[juju].transform.parent.transform.GetChild(4).GetComponent<Image>().color;
                            a.a += Time.deltaTime * 2;
                            mySkillBTN[juju].transform.parent.transform.GetChild(4).GetComponent<Image>().color = a;
                        }
                        break;
                    case 1:
                        if (myfadwaittimer > 0.5) {
                            myfadwaittimer = 0;
                            mySkillBTNEdgeMod[juju] = 2;
                        }
                        else {
                            myfadwaittimer += Time.deltaTime;
                        }
                        break;
                    case 2:
                        if (mySkillBTN[juju].transform.parent.transform.GetChild(4).GetComponent<Image>().color.a < 0)
                        {
                            mySkillBTNEdgeMod[juju] = 0;
                            isSkillBtnEdgeTime[juju] = false;
                        }
                        else {
                            Color a = mySkillBTN[juju].transform.parent.transform.GetChild(4).GetComponent<Image>().color;
                            a.a -= Time.deltaTime * 2;
                            mySkillBTN[juju].transform.parent.transform.GetChild(4).GetComponent<Image>().color = a;
                        }
                        break;
                }
            }
        }
    }
    public void myWhenNotPressBTN_forfadeout_FN() {
        if (myWhichTeam[0] == false) {myWhenNotPressBTN_forfadeout_if_FN(0); }
        if (myWhichTeam[1] == false) {myWhenNotPressBTN_forfadeout_if_FN(1); }
        if (myWhichTeam[2] == false) {myWhenNotPressBTN_forfadeout_if_FN(2); }
        if (myWhichTeam[3] == false) {myWhenNotPressBTN_forfadeout_if_FN(3); }
        if (myWhichTeam[4] == false) {myWhenNotPressBTN_forfadeout_if_FN(4); }
    }
    //光暈相關
    public void myWhenNotPressBTN_forfadeout_if_FN(int btn_num) {
       /* if (mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color.a < 0) { }
        else {
            Color a = mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color;
            a.a -= Time.deltaTime * 5;
            mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color = a;
        }*/
    }
    //生蚊子的韓式
    public int mySpawnPointRandom;
    public void myAutoCreatMQ()
    {
        if (myAutoFireBulletAmount == 0) {
            print("Game Over");
        }
        else {
            myAutoFireBulletAmount--;
            mySpawnPointRandom = Random.Range(0, 14);
            Instantiate(myLocalMQList[GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLocalMQ_Mob-1], myFirePoint[mySpawnPointRandom].transform.position, Quaternion.identity);//生蚊子
        }
        
    }
    public void myBTNShakeFN(int myTeam_Num) {
        if (myTeamMQCount[myTeam_Num] > 0) {
            //按鈕晃動
            float bb = Random.Range(1.5f, 2.5f);
            if (mySkillBtnShakeTimer[myTeam_Num] > bb) {
                mySkillBtnShakeRandom[myTeam_Num] = Random.Range(0, 11);
                if (mySkillBtnShakeRandom[myTeam_Num] > 7) {
                    iTween.ShakePosition(mySkillBTN[myTeam_Num].transform.parent.transform.GetChild(4).gameObject, iTween.Hash("y", 20.3f, "time", 0.5f, "delay", 0.0f));
                }
                mySkillBtnShakeTimer[myTeam_Num] = 0;
            }
            else {
                mySkillBtnShakeTimer[myTeam_Num] += Time.deltaTime;
            }
        }
    }
    //玩家按著按鈕後～生蚊子出來的地方
    public void myCreatMQFN(int myTeam_Num) {
        if (myTeamMQCount[myTeam_Num] > 0)
        {
            switch (myTeam_Num) {
                case 0:
                    if (myTeamMQCount[myTeam_Num] > 0)
                    {
                        mySpawnPointRandom = Random.Range(0, 14);
                        GameObject myTeamAMQ = Instantiate(myBullet[myTeamAMQTypeID], myFirePoint[mySpawnPointRandom].transform.position, myFirePoint[mySpawnPointRandom].transform.rotation) as GameObject;
                        myTeamAMQ.GetComponent<onMQVer3>().myTargetPoint = transform.parent.gameObject.GetComponent<onCamera_dtg>().theLookAtPointOnMonster[transform.parent.gameObject.GetComponent<onCamera_dtg>().myCameraMod];
                        myTeamMQCount[myTeam_Num]--;
                    }
                    else { print("team A MQ is Gown"); }
                    break;
                case 1:
                    if (myTeamMQCount[myTeam_Num] > 0)
                    {
                        mySpawnPointRandom = Random.Range(0, 14);
                        GameObject myTeamAMQ = Instantiate(myBullet[myTeamBMQTypeID], myFirePoint[mySpawnPointRandom].transform.position, myFirePoint[mySpawnPointRandom].transform.rotation) as GameObject;
                        myTeamAMQ.GetComponent<onMQVer3>().myTargetPoint = transform.parent.gameObject.GetComponent<onCamera_dtg>().theLookAtPointOnMonster[transform.parent.gameObject.GetComponent<onCamera_dtg>().myCameraMod];
                        myTeamMQCount[myTeam_Num]--;
                    }
                    else { print("team B MQ is Gown"); }
                 break;
                case 2:
                    if (myTeamMQCount[myTeam_Num] > 0)
                    {
                        mySpawnPointRandom = Random.Range(0, 14);
                        GameObject myTeamAMQ = Instantiate(myBullet[myTeamCMQTypeID], myFirePoint[mySpawnPointRandom].transform.position, myFirePoint[mySpawnPointRandom].transform.rotation) as GameObject;
                        myTeamAMQ.GetComponent<onMQVer3>().myTargetPoint = transform.parent.gameObject.GetComponent<onCamera_dtg>().theLookAtPointOnMonster[transform.parent.gameObject.GetComponent<onCamera_dtg>().myCameraMod];
                        myTeamMQCount[myTeam_Num]--;
                    }
                    else { print("team C MQ is Gown"); }
                    break;
                case 3:
                    if (myTeamMQCount[myTeam_Num] > 0)
                    {
                        mySpawnPointRandom = Random.Range(0, 14);
                        GameObject myTeamAMQ = Instantiate(myBullet[myTeamDMQTypeID], myFirePoint[mySpawnPointRandom].transform.position, myFirePoint[mySpawnPointRandom].transform.rotation) as GameObject;
                        myTeamAMQ.GetComponent<onMQVer3>().myTargetPoint = transform.parent.gameObject.GetComponent<onCamera_dtg>().theLookAtPointOnMonster[transform.parent.gameObject.GetComponent<onCamera_dtg>().myCameraMod];
                        myTeamMQCount[myTeam_Num]--;
                    }
                    else { print("team D MQ is Gown"); }
                  break;
                case 4:
                    if (myTeamMQCount[myTeam_Num] > 0)
                    {
                        mySpawnPointRandom = Random.Range(0, 14);
                        GameObject myTeamAMQ = Instantiate(myBullet[myTeamEMQTypeID], myFirePoint[mySpawnPointRandom].transform.position, myFirePoint[mySpawnPointRandom].transform.rotation) as GameObject;
                        myTeamAMQ.GetComponent<onMQVer3>().myTargetPoint = transform.parent.gameObject.GetComponent<onCamera_dtg>().theLookAtPointOnMonster[transform.parent.gameObject.GetComponent<onCamera_dtg>().myCameraMod];
                        myTeamMQCount[myTeam_Num]--;
                    }
                    else { print("team E MQ is Gown"); }
                    break;
                default:
                    break;
            }
            myTimer = 0;
            mySpawnPointRandom = Random.Range(0, 14);
            /*Instantiate(myBullet[myTeamBTNClick - 1], myFirePoint[mySpawnPointRandom].transform.position, Quaternion.identity);//生蚊子
            //Instantiate(myBullet[0], myFirePoint[a].transform.position, Quaternion.identity);//生蚊子
            myTeamMQCount[myTeam_Num]--;*/
            myHowManyMQOnScene++;//數蚊子
        }
        else { print("沒MQ...."); }
    }
    public void BTN_TeamADown() {myForBTNDown(0); myTeamID = 1; }
    public void BTN_TeamBDown() {myForBTNDown(1); myTeamID = 2; }
    public void BTN_TeamCDown() {myForBTNDown(2); myTeamID = 3; }
    public void BTN_TeamDDown() {myForBTNDown(3); myTeamID = 4; }
    public void BTN_TeamEDown() {myForBTNDown(4); myTeamID = 5; }
    public void BTN_ScreenFireDown() {
        if (isPutMQTime)
        {
            myForBTNDown(myTeamID-1);
            myCreatMQFN(myTeamID-1);
            isPutMQTime = false;
        }
    }
    public void myForBTNDown(int btn_num)
    {
        myWhichTeam[btn_num] = true;
        myTeamBTNClick = btn_num + 1;
      /*  mySkillBTN[btn_num].transform.parent.transform.GetChild(1).GetComponent<Image>().sprite = mySkillBTN_Sprite[1];
        mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().sprite = myTeamBTN_hide[1];
        Color a = mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color;
        a.a = 0;
        mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color = a;*/
    }
    public void BTN_TeamAUp(){myForBTNUp(0);}
    public void BTN_TeamBUp(){myForBTNUp(1);}
    public void BTN_TeamCUp(){myForBTNUp(2);}
    public void BTN_TeamDUp(){myForBTNUp(3);}
    public void BTN_TeamEUp(){myForBTNUp(4);}
    public void BTN_ScreenFireUp() {myForBTNUp(myTeamID-1);}
    public void myForBTNUp(int btn_num)
    {
        myWhichTeam[btn_num] = false;
       /* mySkillBTN[btn_num].transform.parent.transform.GetChild(1).GetComponent<Image>().sprite = mySkillBTN_Sprite[0];
        mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().sprite = myTeamBTN_hide[0];
        Color a = mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color;
        a.a = 1;
        mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color = a;*/
    }
   
    public void myCheckIsWhichTeam()
    {
        if (myWhichTeam[0])
        {
            myFireBTNPress_fadinFN(0);
            if (isPutMQTime) {
                myCreatMQFN(0);
                isPutMQTime = false;
            }
        }
        if (myWhichTeam[1])
        {
            myFireBTNPress_fadinFN(1);
            if (isPutMQTime) {
                isPutMQTime = false;
                myCreatMQFN(1);
            }
        }
        if (myWhichTeam[2])
        {
            myFireBTNPress_fadinFN(2);
            if (isPutMQTime) {
                isPutMQTime = false;
                myCreatMQFN(2);
            }
        }
        if (myWhichTeam[3])
        {
            myFireBTNPress_fadinFN(3);
            if (isPutMQTime) {
                isPutMQTime = false;
                myCreatMQFN(3);
            }
        }
        if (myWhichTeam[4])
        {
            myFireBTNPress_fadinFN(4);
            if (isPutMQTime) {
                isPutMQTime = false;
                myCreatMQFN(4);
            }
        }
    }
    //放蚊子時的光暈
    public void myFireBTNPress_fadinFN(int btn_num) {
    /*    Color a = mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color;
        a.a += Time.deltaTime * 5f;
        mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color = a;*/
    }
    //放技能
    //public GameObject[] MQ;
    public void mySkillCheck()
    {
        if (!isTeamSkillCD[0]) myASkillCheck();
        if (!isTeamSkillCD[1]) myBSkillCheck();
        if (!isTeamSkillCD[2]) myCSkillCheck();
        if (!isTeamSkillCD[3]) myDSkillCheck();
        if (!isTeamSkillCD[4]) myESkillCheck();
    }
    public void myASkillCheck()
    {
        switch (myTeamAMQTypeID)
        {
            case 1://===============================士兵=================================
                //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[0] >= myMQSkillSettingMenu.MQ01_skill.myMQNeedAmount){
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ01_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ01_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ01_skill.isSkillCDTime = false;
                            mySkillBTN[0].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[0].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[0].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[0] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[0].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ01_skill.mySkillCDTime);
                            myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }
               
                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ01_skill.isSkillWorking) {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ01_skill.mySkillStateType == 0) {
                        myMQSkillSettingMenu.MQ01_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ01_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ01_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ01_skill.mySkillKeepTime) {
                            myMQSkillSettingMenu.MQ01_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ01_skill.isSkillWorking = false;
                        }
                        else{
                            myMQSkillSettingMenu.MQ01_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 2://===============================護士=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[0] >= myMQSkillSettingMenu.MQ02_skill.myMQNeedAmount)
                { //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ02_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ02_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ02_skill.isSkillCDTime = false;
                            mySkillBTN[0].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;
                            //CD完成將CD遮罩處理掉
                            myCDBlack[0].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[0].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[0] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[0].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ02_skill.mySkillCDTime);
                            myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                    
                }
                else {
                    mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }
               
                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ02_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ02_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ02_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ02_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ02_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ02_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ02_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ02_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ02_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 3://===============================衝鋒=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[0] >= myMQSkillSettingMenu.MQ03_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ03_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ03_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ03_skill.isSkillCDTime = false;
                            mySkillBTN[0].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[0].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[0].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[0] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[0].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ03_skill.mySkillCDTime);
                            myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ03_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ03_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ03_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ03_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ03_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ03_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ03_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ03_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ03_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 4://===============================冰凍=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[0] >= myMQSkillSettingMenu.MQ04_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ04_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ04_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ04_skill.isSkillCDTime = false;
                            mySkillBTN[0].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[0].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[0].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[0] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[0].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ04_skill.mySkillCDTime);
                            myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ04_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ04_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ04_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ04_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ04_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ04_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ04_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ04_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ04_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 5://===============================法師=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[0] >= myMQSkillSettingMenu.MQ05_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ05_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ05_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ05_skill.isSkillCDTime = false;
                            mySkillBTN[0].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[0].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[0].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[0] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[0].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ05_skill.mySkillCDTime);
                            myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ05_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ05_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ05_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ05_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ05_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ05_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ05_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ05_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ05_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 6://===============================生化=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[0] >= myMQSkillSettingMenu.MQ06_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ06_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ06_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ06_skill.isSkillCDTime = false;
                            mySkillBTN[0].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[0].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[0].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[0] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[0].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ06_skill.mySkillCDTime);
                            myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ06_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ06_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ06_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ06_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ06_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ06_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ06_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ06_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ06_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 7://===============================獵人=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[0] >= myMQSkillSettingMenu.MQ07_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ07_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ07_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ07_skill.isSkillCDTime = false;
                            mySkillBTN[0].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[0].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[0].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[0] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[0].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ07_skill.mySkillCDTime);
                            myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ07_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ07_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ07_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ07_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ07_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ07_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ07_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ07_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ07_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 8://===============================金盾=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[0] >= myMQSkillSettingMenu.MQ08_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ08_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ08_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ08_skill.isSkillCDTime = false;
                            mySkillBTN[0].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[0].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[0].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[0] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[0].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ08_skill.mySkillCDTime);
                            myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ08_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ08_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ08_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ08_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ08_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ08_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ08_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ08_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ08_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 9://===============================炸彈=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[0] >= myMQSkillSettingMenu.MQ09_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ09_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ09_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ09_skill.isSkillCDTime = false;
                            mySkillBTN[0].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[0].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[0].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[0] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[0].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ09_skill.mySkillCDTime);
                            myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ09_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ09_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ09_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ09_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ09_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ09_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ09_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ09_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ09_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 10://===============================機械=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[0] >= myMQSkillSettingMenu.MQ10_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ10_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ10_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ10_skill.isSkillCDTime = false;
                            mySkillBTN[0].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[0].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[0].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[0] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[0].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ10_skill.mySkillCDTime);
                            myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ10_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ10_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ10_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ10_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ10_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ10_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ10_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ10_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ10_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 11://===============================詩人=================================
                //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[0] >= myMQSkillSettingMenu.MQ11_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ11_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ11_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ11_skill.isSkillCDTime = false;
                            mySkillBTN[0].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[0].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[0].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[0] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[0].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ11_skill.mySkillCDTime);
                            myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ11_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ11_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ11_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ11_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ11_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ11_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ11_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ11_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ11_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 12://===============================喪屍=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[0] >= myMQSkillSettingMenu.MQ12_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ12_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ12_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ12_skill.isSkillCDTime = false;
                            mySkillBTN[0].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[0].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[0].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[0] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[0].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ12_skill.mySkillCDTime);
                            myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ12_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ12_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ12_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ12_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ12_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ12_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ12_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ12_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ12_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 13://===============================吸血=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[0] >= myMQSkillSettingMenu.MQ13_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ13_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ13_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ13_skill.isSkillCDTime = false;
                            mySkillBTN[0].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[0].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[0].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[0] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[0].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ13_skill.mySkillCDTime);
                            myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ13_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ13_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ13_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ13_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ13_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ13_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ13_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ13_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ13_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 14://===============================黑洞=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[0] >= myMQSkillSettingMenu.MQ14_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ14_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ14_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ14_skill.isSkillCDTime = false;
                            mySkillBTN[0].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[0].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[0].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[0] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[0].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ14_skill.mySkillCDTime);
                            myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[0].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ14_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ14_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ14_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ14_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ14_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ14_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ14_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ14_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ14_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
        }
    }
    public void myBSkillCheck()
    {
        switch (myTeamBMQTypeID)
        {
            case 1://===============================士兵=================================
                //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[1] >= myMQSkillSettingMenu.MQ01_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ01_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ01_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ01_skill.isSkillCDTime = false;
                            mySkillBTN[1].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[1].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[1].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[1] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[1].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ01_skill.mySkillCDTime);
                            myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ01_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ01_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ01_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ01_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ01_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ01_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ01_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ01_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ01_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 2://===============================護士=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[1] >= myMQSkillSettingMenu.MQ02_skill.myMQNeedAmount)
                { //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ02_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ02_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ02_skill.isSkillCDTime = false;
                            mySkillBTN[1].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;
                            //CD完成將CD遮罩處理掉
                            myCDBlack[1].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[1].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[1] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[1].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ02_skill.mySkillCDTime);
                            myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                        }
                    }

                }
                else {
                    mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ02_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ02_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ02_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ02_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ02_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ02_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ02_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ02_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ02_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 3://===============================衝鋒=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[1] >= myMQSkillSettingMenu.MQ03_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ03_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ03_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ03_skill.isSkillCDTime = false;
                            mySkillBTN[1].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[1].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[1].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[1] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[1].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ03_skill.mySkillCDTime);
                            myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ03_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ03_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ03_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ03_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ03_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ03_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ03_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ03_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ03_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 4://===============================冰凍=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[1] >= myMQSkillSettingMenu.MQ04_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ04_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ04_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ04_skill.isSkillCDTime = false;
                            mySkillBTN[1].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[1].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[1].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[1] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[1].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ04_skill.mySkillCDTime);
                            myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ04_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ04_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ04_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ04_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ04_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ04_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ04_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ04_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ04_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 5://===============================法師=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[1] >= myMQSkillSettingMenu.MQ05_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ05_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ05_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ05_skill.isSkillCDTime = false;
                            mySkillBTN[1].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[1].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[1].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[1] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[1].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ05_skill.mySkillCDTime);
                            myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ05_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ05_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ05_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ05_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ05_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ05_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ05_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ05_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ05_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 6://===============================生化=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[1] >= myMQSkillSettingMenu.MQ06_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ06_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ06_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ06_skill.isSkillCDTime = false;
                            mySkillBTN[1].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[1].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[1].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[1] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[1].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ06_skill.mySkillCDTime);
                            myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ06_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ06_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ06_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ06_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ06_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ06_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ06_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ06_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ06_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 7://===============================獵人=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[1] >= myMQSkillSettingMenu.MQ07_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ07_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ07_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ07_skill.isSkillCDTime = false;
                            mySkillBTN[1].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[1].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[1].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[1] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[1].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ07_skill.mySkillCDTime);
                            myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ07_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ07_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ07_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ07_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ07_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ07_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ07_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ07_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ07_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 8://===============================金盾=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[1] >= myMQSkillSettingMenu.MQ08_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ08_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ08_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ08_skill.isSkillCDTime = false;
                            mySkillBTN[1].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[1].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[1].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[1] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[1].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ08_skill.mySkillCDTime);
                            myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ08_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ08_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ08_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ08_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ08_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ08_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ08_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ08_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ08_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 9://===============================炸彈=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[1] >= myMQSkillSettingMenu.MQ09_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ09_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ09_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ09_skill.isSkillCDTime = false;
                            mySkillBTN[1].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[1].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[1].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[1] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[1].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ09_skill.mySkillCDTime);
                            myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ09_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ09_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ09_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ09_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ09_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ09_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ09_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ09_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ09_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 10://===============================機械=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[1] >= myMQSkillSettingMenu.MQ10_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ10_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ10_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ10_skill.isSkillCDTime = false;
                            mySkillBTN[1].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[1].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[1].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[1] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[1].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ10_skill.mySkillCDTime);
                            myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ10_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ10_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ10_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ10_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ10_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ10_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ10_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ10_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ10_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 11://===============================詩人=================================
                //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[1] >= myMQSkillSettingMenu.MQ11_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ11_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ11_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ11_skill.isSkillCDTime = false;
                            mySkillBTN[1].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[1].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[1].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[1] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[1].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ11_skill.mySkillCDTime);
                            myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ11_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ11_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ11_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ11_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ11_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ11_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ11_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ11_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ11_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 12://===============================喪屍=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[1] >= myMQSkillSettingMenu.MQ12_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ12_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ12_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ12_skill.isSkillCDTime = false;
                            mySkillBTN[1].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[1].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[1].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[1] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[1].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ12_skill.mySkillCDTime);
                            myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ12_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ12_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ12_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ12_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ12_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ12_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ12_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ12_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ12_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 13://===============================吸血=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[1] >= myMQSkillSettingMenu.MQ13_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ13_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ13_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ13_skill.isSkillCDTime = false;
                            mySkillBTN[1].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[1].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[1].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[1] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[1].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ13_skill.mySkillCDTime);
                            myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ13_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ13_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ13_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ13_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ13_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ13_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ13_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ13_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ13_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 14://===============================黑洞=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[1] >= myMQSkillSettingMenu.MQ14_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ14_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ14_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ14_skill.isSkillCDTime = false;
                            mySkillBTN[1].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[1].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[1].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[1] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[1].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ14_skill.mySkillCDTime);
                            myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[1].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ14_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ14_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ14_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ14_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ14_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ14_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ14_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ14_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ14_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
        }

    }
    public void myCSkillCheck()
    {
        switch (myTeamCMQTypeID)
        {
            case 1://===============================士兵=================================
                //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[2] >= myMQSkillSettingMenu.MQ01_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ01_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ01_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ01_skill.isSkillCDTime = false;
                            mySkillBTN[2].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[2].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[2].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[2] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[2].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ01_skill.mySkillCDTime);
                            myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ01_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ01_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ01_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ01_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ01_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ01_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ01_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ01_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ01_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 2://===============================護士=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[2] >= myMQSkillSettingMenu.MQ02_skill.myMQNeedAmount)
                { //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ02_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ02_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ02_skill.isSkillCDTime = false;
                            mySkillBTN[2].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;
                            //CD完成將CD遮罩處理掉
                            myCDBlack[2].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[2].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[2] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[2].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ02_skill.mySkillCDTime);
                            myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                        }
                    }

                }
                else {
                    mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ02_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ02_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ02_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ02_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ02_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ02_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ02_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ02_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ02_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 3://===============================衝鋒=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[2] >= myMQSkillSettingMenu.MQ03_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ03_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ03_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ03_skill.isSkillCDTime = false;
                            mySkillBTN[2].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[2].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[2].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[2] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[2].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ03_skill.mySkillCDTime);
                            myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ03_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ03_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ03_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ03_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ03_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ03_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ03_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ03_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ03_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 4://===============================冰凍=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[2] >= myMQSkillSettingMenu.MQ04_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ04_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ04_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ04_skill.isSkillCDTime = false;
                            mySkillBTN[2].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[2].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[2].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[2] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[2].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ04_skill.mySkillCDTime);
                            myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ04_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ04_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ04_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ04_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ04_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ04_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ04_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ04_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ04_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 5://===============================法師=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[2] >= myMQSkillSettingMenu.MQ05_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ05_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ05_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ05_skill.isSkillCDTime = false;
                            mySkillBTN[2].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[2].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[2].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[2] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[2].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ05_skill.mySkillCDTime);
                            myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ05_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ05_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ05_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ05_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ05_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ05_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ05_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ05_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ05_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 6://===============================生化=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[2] >= myMQSkillSettingMenu.MQ06_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ06_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ06_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ06_skill.isSkillCDTime = false;
                            mySkillBTN[2].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[2].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[2].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[2] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[2].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ06_skill.mySkillCDTime);
                            myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ06_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ06_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ06_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ06_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ06_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ06_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ06_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ06_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ06_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 7://===============================獵人=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[2] >= myMQSkillSettingMenu.MQ07_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ07_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ07_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ07_skill.isSkillCDTime = false;
                            mySkillBTN[2].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[2].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[2].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[2] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[2].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ07_skill.mySkillCDTime);
                            myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ07_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ07_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ07_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ07_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ07_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ07_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ07_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ07_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ07_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 8://===============================金盾=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[2] >= myMQSkillSettingMenu.MQ08_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ08_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ08_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ08_skill.isSkillCDTime = false;
                            mySkillBTN[2].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[2].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[2].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[2] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[2].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ08_skill.mySkillCDTime);
                            myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ08_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ08_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ08_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ08_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ08_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ08_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ08_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ08_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ08_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 9://===============================炸彈=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[2] >= myMQSkillSettingMenu.MQ09_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ09_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ09_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ09_skill.isSkillCDTime = false;
                            mySkillBTN[2].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[2].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[2].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[2] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[2].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ09_skill.mySkillCDTime);
                            myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ09_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ09_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ09_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ09_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ09_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ09_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ09_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ09_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ09_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 10://===============================機械=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[2] >= myMQSkillSettingMenu.MQ10_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ10_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ10_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ10_skill.isSkillCDTime = false;
                            mySkillBTN[2].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[2].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[2].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[2] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[2].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ10_skill.mySkillCDTime);
                            myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ10_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ10_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ10_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ10_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ10_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ10_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ10_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ10_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ10_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 11://===============================詩人=================================
                //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[2] >= myMQSkillSettingMenu.MQ11_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ11_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ11_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ11_skill.isSkillCDTime = false;
                            mySkillBTN[2].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[2].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[2].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[2] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[2].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ11_skill.mySkillCDTime);
                            myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ11_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ11_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ11_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ11_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ11_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ11_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ11_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ11_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ11_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 12://===============================喪屍=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[2] >= myMQSkillSettingMenu.MQ12_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ12_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ12_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ12_skill.isSkillCDTime = false;
                            mySkillBTN[2].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[2].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[2].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[2] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[2].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ12_skill.mySkillCDTime);
                            myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ12_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ12_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ12_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ12_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ12_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ12_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ12_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ12_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ12_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 13://===============================吸血=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[2] >= myMQSkillSettingMenu.MQ13_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ13_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ13_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ13_skill.isSkillCDTime = false;
                            mySkillBTN[2].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[2].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[2].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[2] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[2].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ13_skill.mySkillCDTime);
                            myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ13_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ13_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ13_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ13_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ13_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ13_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ13_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ13_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ13_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 14://===============================黑洞=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[2] >= myMQSkillSettingMenu.MQ14_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ14_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ14_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ14_skill.isSkillCDTime = false;
                            mySkillBTN[2].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[2].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[2].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[2] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[2].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ14_skill.mySkillCDTime);
                            myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[2].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ14_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ14_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ14_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ14_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ14_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ14_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ14_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ14_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ14_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
        }
    }
    public void myDSkillCheck()
    {
        switch (myTeamDMQTypeID)
        {
            case 1://===============================士兵=================================
                //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[3] >= myMQSkillSettingMenu.MQ01_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ01_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ01_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ01_skill.isSkillCDTime = false;
                            mySkillBTN[3].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[3].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[3].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[3] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[3].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ01_skill.mySkillCDTime);
                            myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ01_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ01_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ01_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ01_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ01_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ01_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ01_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ01_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ01_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 2://===============================護士=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[3] >= myMQSkillSettingMenu.MQ02_skill.myMQNeedAmount)
                { //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ02_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ02_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ02_skill.isSkillCDTime = false;
                            mySkillBTN[3].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;
                            //CD完成將CD遮罩處理掉
                            myCDBlack[3].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[3].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[3] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[3].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ02_skill.mySkillCDTime);
                            myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                        }
                    }

                }
                else {
                    mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ02_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ02_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ02_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ02_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ02_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ02_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ02_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ02_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ02_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 3://===============================衝鋒=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[3] >= myMQSkillSettingMenu.MQ03_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ03_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ03_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ03_skill.isSkillCDTime = false;
                            mySkillBTN[3].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[3].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[3].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[3] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[3].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ03_skill.mySkillCDTime);
                            myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ03_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ03_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ03_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ03_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ03_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ03_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ03_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ03_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ03_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 4://===============================冰凍=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[3] >= myMQSkillSettingMenu.MQ04_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ04_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ04_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ04_skill.isSkillCDTime = false;
                            mySkillBTN[3].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[3].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[3].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[3] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[3].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ04_skill.mySkillCDTime);
                            myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ04_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ04_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ04_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ04_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ04_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ04_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ04_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ04_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ04_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 5://===============================法師=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[3] >= myMQSkillSettingMenu.MQ05_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ05_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ05_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ05_skill.isSkillCDTime = false;
                            mySkillBTN[3].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[3].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[3].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[3] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[3].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ05_skill.mySkillCDTime);
                            myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ05_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ05_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ05_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ05_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ05_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ05_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ05_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ05_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ05_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 6://===============================生化=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[3] >= myMQSkillSettingMenu.MQ06_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ06_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ06_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ06_skill.isSkillCDTime = false;
                            mySkillBTN[3].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[3].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[3].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[3] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[3].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ06_skill.mySkillCDTime);
                            myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ06_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ06_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ06_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ06_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ06_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ06_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ06_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ06_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ06_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 7://===============================獵人=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[3] >= myMQSkillSettingMenu.MQ07_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ07_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ07_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ07_skill.isSkillCDTime = false;
                            mySkillBTN[3].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[3].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[3].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[3] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[3].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ07_skill.mySkillCDTime);
                            myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ07_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ07_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ07_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ07_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ07_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ07_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ07_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ07_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ07_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 8://===============================金盾=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[3] >= myMQSkillSettingMenu.MQ08_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ08_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ08_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ08_skill.isSkillCDTime = false;
                            mySkillBTN[3].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[3].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[3].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[3] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[3].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ08_skill.mySkillCDTime);
                            myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ08_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ08_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ08_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ08_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ08_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ08_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ08_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ08_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ08_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 9://===============================炸彈=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[3] >= myMQSkillSettingMenu.MQ09_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ09_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ09_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ09_skill.isSkillCDTime = false;
                            mySkillBTN[3].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[3].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[3].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[3] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[3].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ09_skill.mySkillCDTime);
                            myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ09_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ09_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ09_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ09_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ09_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ09_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ09_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ09_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ09_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 10://===============================機械=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[3] >= myMQSkillSettingMenu.MQ10_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ10_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ10_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ10_skill.isSkillCDTime = false;
                            mySkillBTN[3].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[3].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[3].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[3] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[3].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ10_skill.mySkillCDTime);
                            myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ10_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ10_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ10_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ10_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ10_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ10_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ10_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ10_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ10_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 11://===============================詩人=================================
                //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[3] >= myMQSkillSettingMenu.MQ11_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ11_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ11_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ11_skill.isSkillCDTime = false;
                            mySkillBTN[3].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[3].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[3].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[3] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[3].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ11_skill.mySkillCDTime);
                            myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ11_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ11_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ11_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ11_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ11_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ11_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ11_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ11_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ11_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 12://===============================喪屍=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[3] >= myMQSkillSettingMenu.MQ12_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ12_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ12_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ12_skill.isSkillCDTime = false;
                            mySkillBTN[3].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[3].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[3].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[3] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[3].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ12_skill.mySkillCDTime);
                            myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ12_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ12_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ12_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ12_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ12_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ12_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ12_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ12_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ12_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 13://===============================吸血=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[3] >= myMQSkillSettingMenu.MQ13_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ13_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ13_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ13_skill.isSkillCDTime = false;
                            mySkillBTN[3].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[3].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[3].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[3] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[3].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ13_skill.mySkillCDTime);
                            myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ13_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ13_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ13_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ13_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ13_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ13_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ13_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ13_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ13_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 14://===============================黑洞=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[3] >= myMQSkillSettingMenu.MQ14_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ14_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ14_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ14_skill.isSkillCDTime = false;
                            mySkillBTN[3].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[3].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[3].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[3] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[3].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ14_skill.mySkillCDTime);
                            myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[3].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ14_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ14_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ14_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ14_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ14_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ14_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ14_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ14_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ14_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
        }

    }
    public void myESkillCheck()
    {
        switch (myTeamEMQTypeID)
        {
            case 1://===============================士兵=================================
                //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[4] >= myMQSkillSettingMenu.MQ01_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ01_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ01_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ01_skill.isSkillCDTime = false;
                            mySkillBTN[4].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[4].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[4].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[4] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[4].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ01_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ01_skill.mySkillCDTime);
                            myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ01_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ01_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ01_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ01_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ01_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ01_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ01_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ01_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ01_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 2://===============================護士=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[4] >= myMQSkillSettingMenu.MQ02_skill.myMQNeedAmount)
                { //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ02_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ02_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ02_skill.isSkillCDTime = false;
                            mySkillBTN[4].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;
                            //CD完成將CD遮罩處理掉
                            myCDBlack[4].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[4].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[4] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[4].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ02_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ02_skill.mySkillCDTime);
                            myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                        }
                    }

                }
                else {
                    mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ02_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ02_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ02_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ02_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ02_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ02_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ02_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ02_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ02_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 3://===============================衝鋒=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[4] >= myMQSkillSettingMenu.MQ03_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ03_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ03_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ03_skill.isSkillCDTime = false;
                            mySkillBTN[4].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[4].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[4].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[4] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[4].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ03_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ03_skill.mySkillCDTime);
                            myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ03_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ03_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ03_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ03_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ03_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ03_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ03_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ03_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ03_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 4://===============================冰凍=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[4] >= myMQSkillSettingMenu.MQ04_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ04_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ04_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ04_skill.isSkillCDTime = false;
                            mySkillBTN[4].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[4].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[4].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[4] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[4].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ04_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ04_skill.mySkillCDTime);
                            myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ04_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ04_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ04_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ04_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ04_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ04_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ04_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ04_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ04_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 5://===============================法師=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[4] >= myMQSkillSettingMenu.MQ05_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ05_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ05_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ05_skill.isSkillCDTime = false;
                            mySkillBTN[4].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[4].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[4].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[4] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[4].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ05_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ05_skill.mySkillCDTime);
                            myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ05_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ05_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ05_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ05_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ05_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ05_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ05_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ05_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ05_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 6://===============================生化=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[4] >= myMQSkillSettingMenu.MQ06_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ06_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ06_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ06_skill.isSkillCDTime = false;
                            mySkillBTN[4].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[4].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[4].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[4] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[4].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ06_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ06_skill.mySkillCDTime);
                            myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ06_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ06_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ06_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ06_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ06_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ06_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ06_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ06_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ06_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 7://===============================獵人=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[4] >= myMQSkillSettingMenu.MQ07_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ07_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ07_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ07_skill.isSkillCDTime = false;
                            mySkillBTN[4].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[4].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[4].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[4] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[4].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ07_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ07_skill.mySkillCDTime);
                            myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ07_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ07_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ07_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ07_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ07_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ07_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ07_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ07_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ07_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 8://===============================金盾=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[4] >= myMQSkillSettingMenu.MQ08_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ08_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ08_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ08_skill.isSkillCDTime = false;
                            mySkillBTN[4].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[4].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[4].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[4] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[4].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ08_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ08_skill.mySkillCDTime);
                            myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ08_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ08_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ08_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ08_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ08_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ08_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ08_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ08_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ08_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 9://===============================炸彈=================================
                   //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[4] >= myMQSkillSettingMenu.MQ09_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ09_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ09_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ09_skill.isSkillCDTime = false;
                            mySkillBTN[4].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[4].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[4].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[4] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[4].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ09_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ09_skill.mySkillCDTime);
                            myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ09_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ09_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ09_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ09_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ09_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ09_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ09_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ09_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ09_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }
                break;
            case 10://===============================機械=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[4] >= myMQSkillSettingMenu.MQ10_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ10_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ10_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ10_skill.isSkillCDTime = false;
                            mySkillBTN[4].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[4].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[4].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[4] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[4].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ10_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ10_skill.mySkillCDTime);
                            myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ10_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ10_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ10_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ10_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ10_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ10_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ10_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ10_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ10_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 11://===============================詩人=================================
                //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[4] >= myMQSkillSettingMenu.MQ11_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ11_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ11_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ11_skill.isSkillCDTime = false;
                            mySkillBTN[4].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[4].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[4].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[4] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[4].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ11_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ11_skill.mySkillCDTime);
                            myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ11_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ11_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ11_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ11_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ11_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ11_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ11_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ11_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ11_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 12://===============================喪屍=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[4] >= myMQSkillSettingMenu.MQ12_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ12_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ12_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ12_skill.isSkillCDTime = false;
                            mySkillBTN[4].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[4].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[4].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[4] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[4].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ12_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ12_skill.mySkillCDTime);
                            myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ12_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ12_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ12_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ12_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ12_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ12_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ12_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ12_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ12_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 13://===============================吸血=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[4] >= myMQSkillSettingMenu.MQ13_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ13_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ13_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ13_skill.isSkillCDTime = false;
                            mySkillBTN[4].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[4].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[4].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[4] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[4].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ13_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ13_skill.mySkillCDTime);
                            myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ13_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ13_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ13_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ13_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ13_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ13_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ13_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ13_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ13_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
            case 14://===============================黑洞=================================
                    //如果蚊子數量充足，彈出技能扭
                if (myTeamMQCount[4] >= myMQSkillSettingMenu.MQ14_skill.myMQNeedAmount)
                {
                    //檢查是否CD時間
                    if (myMQSkillSettingMenu.MQ14_skill.isSkillCDTime)
                    {
                        if (myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer > myMQSkillSettingMenu.MQ14_skill.mySkillCDTime)
                        {
                            myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer = 0;
                            myMQSkillSettingMenu.MQ14_skill.isSkillCDTime = false;
                            mySkillBTN[4].GetComponent<Image>().raycastTarget = true;
                            mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = true;

                            //CD完成將CD遮罩處理掉
                            myCDBlack[4].GetComponent<Image>().fillAmount = 0;
                            myCDBlack[4].GetComponent<Image>().raycastTarget = false;

                            //CD好的時候讓框彈一下
                            isSkillBTNJuiceTime[4] = true;
                        }
                        else {
                            //技能CD時間計算
                            myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer += Time.deltaTime;

                            //技能CD遮罩
                            myCDBlack[4].GetComponent<Image>().fillAmount = 1 - (myMQSkillSettingMenu.MQ14_skill.mySkillCDTimer / myMQSkillSettingMenu.MQ14_skill.mySkillCDTime);
                            myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
                else {
                    mySkillBTN[4].transform.parent.GetComponent<onSkillBTN_ForShowHideControll>().isShowTime = false;
                }

                //檢查技能是否啟動
                if (myMQSkillSettingMenu.MQ14_skill.isSkillWorking)
                {
                    //0=瞬發
                    if (myMQSkillSettingMenu.MQ14_skill.mySkillStateType == 0)
                    {
                        myMQSkillSettingMenu.MQ14_skill.isSkillWorking = false;
                        //這邊就是丟瞬間要做的事情
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= myMQSkillSettingMenu.MQ14_skill.mySkillHurtValue_Morale;
                    }
                    else {//持續傷害
                        if (myMQSkillSettingMenu.MQ14_skill.mySkillKeepTimer >= myMQSkillSettingMenu.MQ14_skill.mySkillKeepTime)
                        {
                            myMQSkillSettingMenu.MQ14_skill.mySkillKeepTimer = 0;
                            myMQSkillSettingMenu.MQ14_skill.isSkillWorking = false;
                        }
                        else {
                            myMQSkillSettingMenu.MQ14_skill.mySkillKeepTimer += Time.deltaTime;
                            //這邊就是丟持續要做的事情
                        }
                    }
                }

                break;
        }

    }

    public void mySkillCheck_nothide_FN(int btn_skillnum)
    {
        isTeamSkillReady[btn_skillnum] = true;
        myCDBlack[btn_skillnum].GetComponent<Image>().fillAmount = 0;
        myCDBlack[btn_skillnum].GetComponent<Image>().raycastTarget = false;
        mySkillBTN[btn_skillnum].GetComponent<Button>().enabled = true;

        //技能按鈕底圖隨機閃爍光暈
        if (mySkillBTNEdgeTimer[btn_skillnum] > 1)
        {
            mySkillBTNEdgeRandom[btn_skillnum] = Random.Range(0, 11);
            if (mySkillBTNEdgeRandom[btn_skillnum] > 3) { isSkillBtnEdgeTime[btn_skillnum] = true; }
            mySkillBTNEdgeTimer[btn_skillnum] = 0;
        }
        else {
            mySkillBTNEdgeTimer[btn_skillnum] += Time.deltaTime;
        }
    }
    public void mySkillCheck_hide_FN(int btn_skillnum)
    {
        isTeamSkillReady[btn_skillnum] = false;
       /* myCDBlack[btn_skillnum].GetComponent<Image>().fillAmount = 1;
        myCDBlack[btn_skillnum].GetComponent<Image>().raycastTarget = true;
        mySkillBTN[btn_skillnum].GetComponent<Button>().enabled = false;*/
    }
    public void myTeamASkill()
    {
        switch (myTeamAMQTypeID) {
            case 1:
                if (myMQSkillSettingMenu.MQ01_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[0].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[0] -= myMQSkillSettingMenu.MQ01_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ01_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ01_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[0].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 2:
                if (myMQSkillSettingMenu.MQ02_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[0].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[0] -= myMQSkillSettingMenu.MQ02_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ02_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ02_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[0].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 3:
                if (myMQSkillSettingMenu.MQ03_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[0].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[0] -= myMQSkillSettingMenu.MQ03_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ03_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ03_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[0].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 4:
                if (myMQSkillSettingMenu.MQ04_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[0].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[0] -= myMQSkillSettingMenu.MQ04_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ04_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ04_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[0].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 5:
                if (myMQSkillSettingMenu.MQ05_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[0].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[0] -= myMQSkillSettingMenu.MQ05_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ05_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ05_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[0].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 6:
                if (myMQSkillSettingMenu.MQ06_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[0].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[0] -= myMQSkillSettingMenu.MQ06_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ06_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ06_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[0].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 7:
                if (myMQSkillSettingMenu.MQ07_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[0].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[0] -= myMQSkillSettingMenu.MQ07_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ07_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ07_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[0].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 8:
                if (myMQSkillSettingMenu.MQ08_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[0].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[0] -= myMQSkillSettingMenu.MQ08_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ08_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ08_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[0].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 9:  if (myMQSkillSettingMenu.MQ09_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[0].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[0] -= myMQSkillSettingMenu.MQ09_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ09_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ09_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[0].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 10:
                if (myMQSkillSettingMenu.MQ10_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[0].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[0] -= myMQSkillSettingMenu.MQ10_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ10_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ10_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[0].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 11:
                if (myMQSkillSettingMenu.MQ11_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[0].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[0] -= myMQSkillSettingMenu.MQ11_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ11_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ11_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[0].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 12:
                if (myMQSkillSettingMenu.MQ12_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[0].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[0] -= myMQSkillSettingMenu.MQ12_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ12_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ12_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[0].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 13:
                if (myMQSkillSettingMenu.MQ13_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[0].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[0] -= myMQSkillSettingMenu.MQ13_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ13_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ13_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[0].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 14:
                if (myMQSkillSettingMenu.MQ14_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[0].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[0] -= myMQSkillSettingMenu.MQ14_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ14_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ14_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[0].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[0].GetComponent<Image>().raycastTarget = true;
                }
                break;
        }
    }
    //隊伍B技能
    public void myTeamBSkill()
    {
        switch (myTeamBMQTypeID)
        {
            case 1:
                if (myMQSkillSettingMenu.MQ01_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[1].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[1] -= myMQSkillSettingMenu.MQ01_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ01_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ01_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[1].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 2:
                if (myMQSkillSettingMenu.MQ02_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[1].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[1] -= myMQSkillSettingMenu.MQ02_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ02_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ02_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[1].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 3:
                if (myMQSkillSettingMenu.MQ03_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[1].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[1] -= myMQSkillSettingMenu.MQ03_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ03_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ03_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[1].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 4:
                if (myMQSkillSettingMenu.MQ04_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[1].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[1] -= myMQSkillSettingMenu.MQ04_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ04_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ04_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[1].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 5:
                if (myMQSkillSettingMenu.MQ05_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[1].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[1] -= myMQSkillSettingMenu.MQ05_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ05_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ05_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[1].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 6:
                if (myMQSkillSettingMenu.MQ06_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[1].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[1] -= myMQSkillSettingMenu.MQ06_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ06_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ06_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[1].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 7:
                if (myMQSkillSettingMenu.MQ07_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[1].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[1] -= myMQSkillSettingMenu.MQ07_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ07_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ07_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[1].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 8:
                if (myMQSkillSettingMenu.MQ08_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[1].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[1] -= myMQSkillSettingMenu.MQ08_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ08_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ08_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[1].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 9:
                if (myMQSkillSettingMenu.MQ09_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[1].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[1] -= myMQSkillSettingMenu.MQ09_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ09_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ09_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[1].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 10:
                if (myMQSkillSettingMenu.MQ10_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[1].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[1] -= myMQSkillSettingMenu.MQ10_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ10_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ10_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[1].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 11:
                if (myMQSkillSettingMenu.MQ11_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[1].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[1] -= myMQSkillSettingMenu.MQ11_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ11_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ11_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[1].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 12:
                if (myMQSkillSettingMenu.MQ12_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[1].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[1] -= myMQSkillSettingMenu.MQ12_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ12_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ12_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[1].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 13:
                if (myMQSkillSettingMenu.MQ13_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[1].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[1] -= myMQSkillSettingMenu.MQ13_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ13_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ13_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[1].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 14:
                if (myMQSkillSettingMenu.MQ14_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[1].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[1] -= myMQSkillSettingMenu.MQ14_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ14_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ14_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[1].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[1].GetComponent<Image>().raycastTarget = true;
                }
                break;
        }
    }
    public void myTeamCSkill()
    {
        switch (myTeamCMQTypeID)
        {
            case 1:
                if (myMQSkillSettingMenu.MQ01_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[2].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[2] -= myMQSkillSettingMenu.MQ01_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ01_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ01_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[2].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 2:
                if (myMQSkillSettingMenu.MQ02_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[2].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[2] -= myMQSkillSettingMenu.MQ02_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ02_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ02_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[2].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 3:
                if (myMQSkillSettingMenu.MQ03_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[2].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[2] -= myMQSkillSettingMenu.MQ03_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ03_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ03_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[2].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 4:
                if (myMQSkillSettingMenu.MQ04_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[2].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[2] -= myMQSkillSettingMenu.MQ04_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ04_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ04_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[2].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 5:
                if (myMQSkillSettingMenu.MQ05_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[2].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[2] -= myMQSkillSettingMenu.MQ05_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ05_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ05_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[2].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 6:
                if (myMQSkillSettingMenu.MQ06_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[2].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[2] -= myMQSkillSettingMenu.MQ06_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ06_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ06_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[2].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 7:
                if (myMQSkillSettingMenu.MQ07_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[2].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[2] -= myMQSkillSettingMenu.MQ07_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ07_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ07_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[2].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 8:
                if (myMQSkillSettingMenu.MQ08_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[2].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[2] -= myMQSkillSettingMenu.MQ08_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ08_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ08_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[2].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 9:
                if (myMQSkillSettingMenu.MQ09_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[2].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[2] -= myMQSkillSettingMenu.MQ09_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ09_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ09_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[2].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 10:
                if (myMQSkillSettingMenu.MQ10_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[2].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[2] -= myMQSkillSettingMenu.MQ10_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ10_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ10_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[2].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 11:
                if (myMQSkillSettingMenu.MQ11_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[2].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[2] -= myMQSkillSettingMenu.MQ11_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ11_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ11_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[2].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 12:
                if (myMQSkillSettingMenu.MQ12_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[2].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[2] -= myMQSkillSettingMenu.MQ12_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ12_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ12_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[2].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 13:
                if (myMQSkillSettingMenu.MQ13_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[2].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[2] -= myMQSkillSettingMenu.MQ13_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ13_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ13_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[2].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 14:
                if (myMQSkillSettingMenu.MQ14_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[2].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[2] -= myMQSkillSettingMenu.MQ14_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ14_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ14_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[2].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[2].GetComponent<Image>().raycastTarget = true;
                }
                break;
        }
    }
    public void myTeamDSkill()
    {
        switch (myTeamDMQTypeID)
        {
            case 1:
                if (myMQSkillSettingMenu.MQ01_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[3].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[3] -= myMQSkillSettingMenu.MQ01_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ01_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ01_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[3].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 2:
                if (myMQSkillSettingMenu.MQ02_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[3].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[3] -= myMQSkillSettingMenu.MQ02_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ02_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ02_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[3].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 3:
                if (myMQSkillSettingMenu.MQ03_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[3].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[3] -= myMQSkillSettingMenu.MQ03_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ03_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ03_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[3].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 4:
                if (myMQSkillSettingMenu.MQ04_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[3].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[3] -= myMQSkillSettingMenu.MQ04_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ04_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ04_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[3].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 5:
                if (myMQSkillSettingMenu.MQ05_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[3].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[3] -= myMQSkillSettingMenu.MQ05_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ05_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ05_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[3].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 6:
                if (myMQSkillSettingMenu.MQ06_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[3].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[3] -= myMQSkillSettingMenu.MQ06_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ06_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ06_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[3].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 7:
                if (myMQSkillSettingMenu.MQ07_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[3].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[3] -= myMQSkillSettingMenu.MQ07_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ07_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ07_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[3].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 8:
                if (myMQSkillSettingMenu.MQ08_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[3].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[3] -= myMQSkillSettingMenu.MQ08_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ08_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ08_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[3].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 9:
                if (myMQSkillSettingMenu.MQ09_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[3].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[3] -= myMQSkillSettingMenu.MQ09_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ09_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ09_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[3].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 10:
                if (myMQSkillSettingMenu.MQ10_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[3].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[3] -= myMQSkillSettingMenu.MQ10_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ10_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ10_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[3].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 11:
                if (myMQSkillSettingMenu.MQ11_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[3].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[3] -= myMQSkillSettingMenu.MQ11_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ11_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ11_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[3].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 12:
                if (myMQSkillSettingMenu.MQ12_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[3].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[3] -= myMQSkillSettingMenu.MQ12_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ12_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ12_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[3].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 13:
                if (myMQSkillSettingMenu.MQ13_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[3].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[3] -= myMQSkillSettingMenu.MQ13_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ13_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ13_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[3].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 14:
                if (myMQSkillSettingMenu.MQ14_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[3].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[3] -= myMQSkillSettingMenu.MQ14_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ14_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ14_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[3].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[3].GetComponent<Image>().raycastTarget = true;
                }
                break;
        }
    }
    public void myTeamESkill()
    {
        switch (myTeamEMQTypeID)
        {
            case 1:
                if (myMQSkillSettingMenu.MQ01_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[4].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[4] -= myMQSkillSettingMenu.MQ01_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ01_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ01_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[4].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 2:
                if (myMQSkillSettingMenu.MQ02_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[4].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[4] -= myMQSkillSettingMenu.MQ02_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ02_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ02_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[4].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 3:
                if (myMQSkillSettingMenu.MQ03_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[4].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[4] -= myMQSkillSettingMenu.MQ03_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ03_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ03_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[4].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 4:
                if (myMQSkillSettingMenu.MQ04_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[4].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[4] -= myMQSkillSettingMenu.MQ04_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ04_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ04_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[4].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 5:
                if (myMQSkillSettingMenu.MQ05_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[4].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[4] -= myMQSkillSettingMenu.MQ05_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ05_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ05_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[4].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 6:
                if (myMQSkillSettingMenu.MQ06_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[4].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[4] -= myMQSkillSettingMenu.MQ06_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ06_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ06_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[4].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 7:
                if (myMQSkillSettingMenu.MQ07_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[4].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[4] -= myMQSkillSettingMenu.MQ07_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ07_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ07_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[4].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 8:
                if (myMQSkillSettingMenu.MQ08_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[4].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[4] -= myMQSkillSettingMenu.MQ08_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ08_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ08_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[4].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 9:
                if (myMQSkillSettingMenu.MQ09_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[4].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[4] -= myMQSkillSettingMenu.MQ09_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ09_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ09_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[4].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 10:
                if (myMQSkillSettingMenu.MQ10_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[4].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[4] -= myMQSkillSettingMenu.MQ10_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ10_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ10_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[4].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 11:
                if (myMQSkillSettingMenu.MQ11_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[4].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[4] -= myMQSkillSettingMenu.MQ11_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ11_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ11_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[4].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 12:
                if (myMQSkillSettingMenu.MQ12_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[4].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[4] -= myMQSkillSettingMenu.MQ12_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ12_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ12_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[4].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 13:
                if (myMQSkillSettingMenu.MQ13_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[4].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[4] -= myMQSkillSettingMenu.MQ13_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ13_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ13_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[4].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                }
                break;
            case 14:
                if (myMQSkillSettingMenu.MQ14_skill.isSkillCDTime) { }
                else {
                    mySkillBTN[4].GetComponent<Image>().raycastTarget = false;
                    myTeamMQCount[4] -= myMQSkillSettingMenu.MQ14_skill.myMQNeedAmount;
                    myMQSkillSettingMenu.MQ14_skill.isSkillCDTime = true;//技能發動了就要CD
                    myMQSkillSettingMenu.MQ14_skill.isSkillWorking = true;//啟動技能

                    myCDBlack[4].GetComponent<Image>().fillAmount = 1;
                    myCDBlack[4].GetComponent<Image>().raycastTarget = true;
                }
                break;
        }
    }
    //技能CD
    /*  public void myTeamCDController()
      {
          switch (myTeamAMQTypeID) {
              case 1:
                  if (myMQSkillSettingMenu.MQ01_skill.isSkillCDTime) { myTeamCD_inIF_FN(1); }
                  break;
              case 2:
                  if (myMQSkillSettingMenu.MQ02_skill.isSkillCDTime) { myTeamCD_inIF_FN(1); }
                  break;
              case 3:
                  if (myMQSkillSettingMenu.MQ03_skill.isSkillCDTime) { myTeamCD_inIF_FN(1); }
                  break;
              case 4:
                  if (myMQSkillSettingMenu.MQ04_skill.isSkillCDTime) { myTeamCD_inIF_FN(1); }
                  break;
              case 5:
                  if (myMQSkillSettingMenu.MQ05_skill.isSkillCDTime) { myTeamCD_inIF_FN(1); }
                  break;
              case 6:
                  if (myMQSkillSettingMenu.MQ06_skill.isSkillCDTime) { myTeamCD_inIF_FN(1); }
                  break;
              case 7:
                  if (myMQSkillSettingMenu.MQ07_skill.isSkillCDTime) { myTeamCD_inIF_FN(1); }
                  break;
              case 8:
                  if (myMQSkillSettingMenu.MQ08_skill.isSkillCDTime) { myTeamCD_inIF_FN(1); }
                  break;
              case 9:
                  if (myMQSkillSettingMenu.MQ09_skill.isSkillCDTime) { myTeamCD_inIF_FN(1); }
                  break;
              case 10:
                  if (myMQSkillSettingMenu.MQ10_skill.isSkillCDTime) { myTeamCD_inIF_FN(1); }
                  break;
              case 11:
                  if (myMQSkillSettingMenu.MQ11_skill.isSkillCDTime) { myTeamCD_inIF_FN(1); }
                  break;
              case 12:
                  if (myMQSkillSettingMenu.MQ12_skill.isSkillCDTime) { myTeamCD_inIF_FN(1); }
                  break;
              case 13:
                  if (myMQSkillSettingMenu.MQ13_skill.isSkillCDTime) { myTeamCD_inIF_FN(1); }
                  break;
              case 14:
                  if (myMQSkillSettingMenu.MQ14_skill.isSkillCDTime) { myTeamCD_inIF_FN(1); }
                  break;
          }
      }*/

    /*  public void myTeamCD_inIF_FN(int myteanskill_num)
      {
          //開始遊戲的時候把選定的角色的CD時間灌進來
          //我TMD真是個天才
          if (myTeamSkillCDTimer[myteanskill_num] > myTeamSkillCDTime[myteanskill_num])//cd秒數
          {
              myCDBlack[myteanskill_num].GetComponent<Image>().fillAmount = 0;
              myTeamSkillCDTimer[myteanskill_num] = 0;
              isTeamSkillCD[myteanskill_num] = false;
              mySkillBTN[myteanskill_num].GetComponent<Image>().raycastTarget = true;
              isSkillBTNJuiceTime[myteanskill_num] = true;


              Color aaa = mySkillBTN[myteanskill_num].transform.GetChild(1).GetComponent<Image>().color;
              aaa.a = 0;
              mySkillBTN[myteanskill_num].transform.GetChild(1).GetComponent<Image>().color = aaa;
          }
          else {
              myCDBlack[myteanskill_num].GetComponent<Image>().raycastTarget = true;
              mySkillBTN[myteanskill_num].GetComponent<Image>().raycastTarget = false;
              myCDBlack[myteanskill_num].GetComponent<Image>().fillAmount = 1 - (myTeamSkillCDTimer[myteanskill_num] / myTeamSkillCDTime[myteanskill_num]);
              myTeamSkillCDTimer[myteanskill_num] += Time.deltaTime;
          }
      }*/
    //蚊子數量更新_UI
    public void myAmountUpdate()
    {
        for (int a = 0; a < 10; a++)
        {
            if (myTeamMQCount[0].ToString().Length == 3) {
                if (myTeamMQCount[0].ToString().Substring(0, 1) == a.ToString()) { myTeamAmount_Image[0].GetComponent<onAmount_UI>().myAmountString[0].GetComponent<Image>().sprite = myTeamAmount_Image[0].GetComponent<onAmount_UI>().myNumSprite[a]; }
                if (myTeamMQCount[0].ToString().Substring(1, 1) == a.ToString()) { myTeamAmount_Image[0].GetComponent<onAmount_UI>().myAmountString[1].GetComponent<Image>().sprite = myTeamAmount_Image[0].GetComponent<onAmount_UI>().myNumSprite[a]; }
                if (myTeamMQCount[0].ToString().Substring(2, 1) == a.ToString()) { myTeamAmount_Image[0].GetComponent<onAmount_UI>().myAmountString[2].GetComponent<Image>().sprite = myTeamAmount_Image[0].GetComponent<onAmount_UI>().myNumSprite[a]; }
            }
            else if (myTeamMQCount[0].ToString().Length == 2) {
                if (myTeamMQCount[0].ToString().Substring(0, 1) == a.ToString()) { myTeamAmount_Image[0].GetComponent<onAmount_UI>().myAmountString[1].GetComponent<Image>().sprite = myTeamAmount_Image[0].GetComponent<onAmount_UI>().myNumSprite[a]; }
                if (myTeamMQCount[0].ToString().Substring(1, 1) == a.ToString()) { myTeamAmount_Image[0].GetComponent<onAmount_UI>().myAmountString[2].GetComponent<Image>().sprite = myTeamAmount_Image[0].GetComponent<onAmount_UI>().myNumSprite[a]; }
                myTeamAmount_Image[0].GetComponent<onAmount_UI>().myAmountString[0].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[0];
            }
            else if (myTeamMQCount[0].ToString().Length == 1) {
                if (myTeamMQCount[0].ToString().Substring(0, 1) == a.ToString()) { myTeamAmount_Image[0].GetComponent<onAmount_UI>().myAmountString[2].GetComponent<Image>().sprite = myTeamAmount_Image[0].GetComponent<onAmount_UI>().myNumSprite[a]; }
                myTeamAmount_Image[0].GetComponent<onAmount_UI>().myAmountString[0].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[0];
                myTeamAmount_Image[0].GetComponent<onAmount_UI>().myAmountString[1].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[0];
            }
            //---------------
            if (myTeamMQCount[1].ToString().Length == 3) {
                if (myTeamMQCount[1].ToString().Substring(0, 1) == a.ToString()) { myTeamAmount_Image[1].GetComponent<onAmount_UI>().myAmountString[0].GetComponent<Image>().sprite = myTeamAmount_Image[1].GetComponent<onAmount_UI>().myNumSprite[a]; }
                if (myTeamMQCount[1].ToString().Substring(1, 1) == a.ToString()) { myTeamAmount_Image[1].GetComponent<onAmount_UI>().myAmountString[1].GetComponent<Image>().sprite = myTeamAmount_Image[1].GetComponent<onAmount_UI>().myNumSprite[a]; }
                if (myTeamMQCount[1].ToString().Substring(2, 1) == a.ToString()) { myTeamAmount_Image[1].GetComponent<onAmount_UI>().myAmountString[2].GetComponent<Image>().sprite = myTeamAmount_Image[1].GetComponent<onAmount_UI>().myNumSprite[a]; }
            }
            else if (myTeamMQCount[1].ToString().Length == 2) {
                if (myTeamMQCount[1].ToString().Substring(0, 1) == a.ToString()) { myTeamAmount_Image[1].GetComponent<onAmount_UI>().myAmountString[1].GetComponent<Image>().sprite = myTeamAmount_Image[1].GetComponent<onAmount_UI>().myNumSprite[a]; }
                if (myTeamMQCount[1].ToString().Substring(1, 1) == a.ToString()) { myTeamAmount_Image[1].GetComponent<onAmount_UI>().myAmountString[2].GetComponent<Image>().sprite = myTeamAmount_Image[1].GetComponent<onAmount_UI>().myNumSprite[a]; }
                myTeamAmount_Image[1].GetComponent<onAmount_UI>().myAmountString[0].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[0];
            }
            else if (myTeamMQCount[1].ToString().Length == 1) {
                if (myTeamMQCount[1].ToString().Substring(0, 1) == a.ToString()) { myTeamAmount_Image[1].GetComponent<onAmount_UI>().myAmountString[2].GetComponent<Image>().sprite = myTeamAmount_Image[1].GetComponent<onAmount_UI>().myNumSprite[a]; }
                myTeamAmount_Image[1].GetComponent<onAmount_UI>().myAmountString[0].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[0];
                myTeamAmount_Image[1].GetComponent<onAmount_UI>().myAmountString[1].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[0];
            }
            //---------------
            if (myTeamMQCount[2].ToString().Length == 3)
            {
                if (myTeamMQCount[2].ToString().Substring(0, 1) == a.ToString()) { myTeamAmount_Image[2].GetComponent<onAmount_UI>().myAmountString[0].GetComponent<Image>().sprite = myTeamAmount_Image[2].GetComponent<onAmount_UI>().myNumSprite[a]; }
                if (myTeamMQCount[2].ToString().Substring(1, 1) == a.ToString()) { myTeamAmount_Image[2].GetComponent<onAmount_UI>().myAmountString[1].GetComponent<Image>().sprite = myTeamAmount_Image[2].GetComponent<onAmount_UI>().myNumSprite[a]; }
                if (myTeamMQCount[2].ToString().Substring(2, 1) == a.ToString()) { myTeamAmount_Image[2].GetComponent<onAmount_UI>().myAmountString[2].GetComponent<Image>().sprite = myTeamAmount_Image[2].GetComponent<onAmount_UI>().myNumSprite[a]; }
            }
            else if (myTeamMQCount[2].ToString().Length == 2)
            {
                if (myTeamMQCount[2].ToString().Substring(0, 1) == a.ToString()) { myTeamAmount_Image[2].GetComponent<onAmount_UI>().myAmountString[1].GetComponent<Image>().sprite = myTeamAmount_Image[2].GetComponent<onAmount_UI>().myNumSprite[a]; }
                if (myTeamMQCount[2].ToString().Substring(1, 1) == a.ToString()) { myTeamAmount_Image[2].GetComponent<onAmount_UI>().myAmountString[2].GetComponent<Image>().sprite = myTeamAmount_Image[2].GetComponent<onAmount_UI>().myNumSprite[a]; }
                myTeamAmount_Image[2].GetComponent<onAmount_UI>().myAmountString[0].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[0];
            }
            else if (myTeamMQCount[2].ToString().Length == 1)
            {
                if (myTeamMQCount[2].ToString().Substring(0, 1) == a.ToString()) { myTeamAmount_Image[2].GetComponent<onAmount_UI>().myAmountString[2].GetComponent<Image>().sprite = myTeamAmount_Image[2].GetComponent<onAmount_UI>().myNumSprite[a]; }
                myTeamAmount_Image[2].GetComponent<onAmount_UI>().myAmountString[0].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[0];
                myTeamAmount_Image[2].GetComponent<onAmount_UI>().myAmountString[1].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[0];
            }
            //---------------
            if (myTeamMQCount[3].ToString().Length == 3)
            {
                if (myTeamMQCount[3].ToString().Substring(0, 1) == a.ToString()) { myTeamAmount_Image[3].GetComponent<onAmount_UI>().myAmountString[0].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[a]; }
                if (myTeamMQCount[3].ToString().Substring(1, 1) == a.ToString()) { myTeamAmount_Image[3].GetComponent<onAmount_UI>().myAmountString[1].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[a]; }
                if (myTeamMQCount[3].ToString().Substring(2, 1) == a.ToString()) { myTeamAmount_Image[3].GetComponent<onAmount_UI>().myAmountString[2].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[a]; }
            }
            else if (myTeamMQCount[3].ToString().Length == 2)
            {
                if (myTeamMQCount[3].ToString().Substring(0, 1) == a.ToString()) { myTeamAmount_Image[3].GetComponent<onAmount_UI>().myAmountString[1].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[a]; }
                if (myTeamMQCount[3].ToString().Substring(1, 1) == a.ToString()) { myTeamAmount_Image[3].GetComponent<onAmount_UI>().myAmountString[2].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[a]; }
                myTeamAmount_Image[3].GetComponent<onAmount_UI>().myAmountString[0].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[0];
            }
            else if (myTeamMQCount[3].ToString().Length == 1)
            {
                if (myTeamMQCount[3].ToString().Substring(0, 1) == a.ToString()) { myTeamAmount_Image[3].GetComponent<onAmount_UI>().myAmountString[2].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[a]; }
                myTeamAmount_Image[3].GetComponent<onAmount_UI>().myAmountString[0].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[0];
                myTeamAmount_Image[3].GetComponent<onAmount_UI>().myAmountString[1].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[0];
            }
            //---------------
            if (myTeamMQCount[4].ToString().Length == 3)
            {
                if (myTeamMQCount[4].ToString().Substring(0, 1) == a.ToString()) { myTeamAmount_Image[4].GetComponent<onAmount_UI>().myAmountString[0].GetComponent<Image>().sprite = myTeamAmount_Image[4].GetComponent<onAmount_UI>().myNumSprite[a]; }
                if (myTeamMQCount[4].ToString().Substring(1, 1) == a.ToString()) { myTeamAmount_Image[4].GetComponent<onAmount_UI>().myAmountString[1].GetComponent<Image>().sprite = myTeamAmount_Image[4].GetComponent<onAmount_UI>().myNumSprite[a]; }
                if (myTeamMQCount[4].ToString().Substring(2, 1) == a.ToString()) { myTeamAmount_Image[4].GetComponent<onAmount_UI>().myAmountString[2].GetComponent<Image>().sprite = myTeamAmount_Image[4].GetComponent<onAmount_UI>().myNumSprite[a]; }
            }
            else if (myTeamMQCount[4].ToString().Length == 2)
            {
                if (myTeamMQCount[4].ToString().Substring(0, 1) == a.ToString()) { myTeamAmount_Image[4].GetComponent<onAmount_UI>().myAmountString[1].GetComponent<Image>().sprite = myTeamAmount_Image[4].GetComponent<onAmount_UI>().myNumSprite[a]; }
                if (myTeamMQCount[4].ToString().Substring(1, 1) == a.ToString()) { myTeamAmount_Image[4].GetComponent<onAmount_UI>().myAmountString[2].GetComponent<Image>().sprite = myTeamAmount_Image[4].GetComponent<onAmount_UI>().myNumSprite[a]; }
                myTeamAmount_Image[4].GetComponent<onAmount_UI>().myAmountString[0].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[0];
            }
            else if (myTeamMQCount[4].ToString().Length == 1)
            {
                if (myTeamMQCount[4].ToString().Substring(0, 1) == a.ToString()) { myTeamAmount_Image[4].GetComponent<onAmount_UI>().myAmountString[2].GetComponent<Image>().sprite = myTeamAmount_Image[4].GetComponent<onAmount_UI>().myNumSprite[a]; }
                myTeamAmount_Image[4].GetComponent<onAmount_UI>().myAmountString[0].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[0];
                myTeamAmount_Image[4].GetComponent<onAmount_UI>().myAmountString[1].GetComponent<Image>().sprite = myTeamAmount_Image[3].GetComponent<onAmount_UI>().myNumSprite[0];
            }

        }
    }
    public void mySelectBoxUpdateFN()
    {
        switch (myTeamID)
        {
            case 1:
                myTeamBTNSelectUI[0].gameObject.SetActive(true);
                myTeamBTNSelectUI[1].gameObject.SetActive(false);
                myTeamBTNSelectUI[2].gameObject.SetActive(false);
                myTeamBTNSelectUI[3].gameObject.SetActive(false);
                myTeamBTNSelectUI[4].gameObject.SetActive(false);
                break;
            case 2:
                myTeamBTNSelectUI[0].gameObject.SetActive(false);
                myTeamBTNSelectUI[1].gameObject.SetActive(true);
                myTeamBTNSelectUI[2].gameObject.SetActive(false);
                myTeamBTNSelectUI[3].gameObject.SetActive(false);
                myTeamBTNSelectUI[4].gameObject.SetActive(false);
                break;
            case 3:
                myTeamBTNSelectUI[0].gameObject.SetActive(false);
                myTeamBTNSelectUI[1].gameObject.SetActive(false);
                myTeamBTNSelectUI[2].gameObject.SetActive(true);
                myTeamBTNSelectUI[3].gameObject.SetActive(false);
                myTeamBTNSelectUI[4].gameObject.SetActive(false);
                break;
            case 4:
                myTeamBTNSelectUI[0].gameObject.SetActive(false);
                myTeamBTNSelectUI[1].gameObject.SetActive(false);
                myTeamBTNSelectUI[2].gameObject.SetActive(false);
                myTeamBTNSelectUI[3].gameObject.SetActive(true);
                myTeamBTNSelectUI[4].gameObject.SetActive(false);
                break;
            case 5:
                myTeamBTNSelectUI[0].gameObject.SetActive(false);
                myTeamBTNSelectUI[1].gameObject.SetActive(false);
                myTeamBTNSelectUI[2].gameObject.SetActive(false);
                myTeamBTNSelectUI[3].gameObject.SetActive(false);
                myTeamBTNSelectUI[4].gameObject.SetActive(true);
                break;
        }
    }
}
