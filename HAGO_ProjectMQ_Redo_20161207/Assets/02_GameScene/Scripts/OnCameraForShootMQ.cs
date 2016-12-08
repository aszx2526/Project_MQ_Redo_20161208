using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class OnCameraForShootMQ : MonoBehaviour
{
    public GameObject[] myFirePoint;
    public GameObject[] myBullet;
    public int myTeamBTNClick;
    float myTimer;
    public Text MQCount;
    public int myHowManyMQOnScene;
    //-----------------
    public int[] myTeamMQCount;
    public GameObject[] myTeamAmount_Image;
    //---------------
    public bool[] myWhichTeam;
    public float myPutMQTimer;
    public float myPutMQTime;
    public bool isPutMQTime;
    public bool[] isTeamSkillCD;
    public float[] isTeamSkillCDTimer;
    public float[] isTeamSkillCdTime;

    //放大縮小相關
    public bool[] isSkillBTNJuiceTime;
    public int[] mySkillBTNJuiceMod;

    //技能按鈕後面光暈相關
    public bool[] isSkillBtnEdgeTime;
    public int[] mySkillBTNEdgeMod;
    public int[] mySkillBTNEdgeRandom;
    public float[] mySkillBTNEdgeTimer;
    float myfadwaittimer;


    //施放蚊子按鈕抖動相關
    public int[] mySkillBtnShakeRandom;
    public float[] mySkillBtnShakeTimer;


    public GameObject[] myCDBlack;
    /* public int myTeamABTNMod;
     public int myTeamBBTNMod;
     public int myTeamCBTNMod;
     public int myTeamDBTNMod;
     public int myTeamEBTNMod;*/

    //-----------
    public bool isSuperStarTime;
    float isSuperStarTimer;

    public bool[] isTeamSkillReady;
    public GameObject[] mySkillBTN;
    public Sprite[] mySkillBTN_Sprite;
    public Sprite[] myTeamBTN_hide;
    public GameObject[] myskillUI;
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
    void Start()
    {
        isPutMQTime = true;
        myPutMQTime = 0.3f;
        myAudioSource = gameObject.GetComponent<AudioSource>();
        for (int a = 0; a < myCDBlack.Length; a++)
        {
            myCDBlack[a].GetComponent<Image>().fillAmount = 1;
            mySkillBTN[a].GetComponent<Button>().enabled = false;

            Color col = mySkillBTN[a].transform.GetChild(1).GetComponent<Image>().color;
            col.a = 0;
            mySkillBTN[a].transform.GetChild(1).GetComponent<Image>().color = col;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isSuperStarTime)
        {
            if (isSuperStarTimer >= 5)
            {
                isSuperStarTimer = 0;
                isSuperStarTime = false;
            }
            else {isSuperStarTimer += Time.deltaTime;}
        }
        MQCount.text = "場上蚊子數量：" + myHowManyMQOnScene.ToString();
        if (gameObject.GetComponent<onMainCameraVer2>().isNeedToFollow)
        {
            if (GameObject.Find("Morale_Monster").GetComponent<Image>().fillAmount == 1){print("all MQ is over so you are lose!!!!!!!!!!");}
        }
        if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart) {
            if (GameObject.Find("Morale_Monster").GetComponent<Image>().fillAmount == 1 || GameObject.Find("Morale_Monster").GetComponent<Image>().fillAmount == 0) { }
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
        }
        //PlayerFunction();
        //CheckIsWin();
        if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart) {
            myPutMQCheckFN();
            myCheckIsWhichTeam();
            myTeamCDController();
            myAmountUpdate();//看看各隊伍剩下多少蚊子
            mySkillCheck();//看看各隊伍有多少蚊子
            myWhenNotPressBTN_forfadeout_FN();
            myJuJuFN();

            if (!isSkillBtnEdgeTime[0]) myBTNShakeFN(0);
            if (!isSkillBtnEdgeTime[1]) myBTNShakeFN(1);
            if (!isSkillBtnEdgeTime[2]) myBTNShakeFN(2);
            if (!isSkillBtnEdgeTime[3]) myBTNShakeFN(3);
            if (!isSkillBtnEdgeTime[4]) myBTNShakeFN(4);

            myBTNShake_FN(0);
            myBTNShake_FN(1);
            myBTNShake_FN(2);
            myBTNShake_FN(3);
            myBTNShake_FN(4);

            
        }
    }
    //onCanvasForUIControll will call this function
    /*public void myGameAwakeTestFN() {
        for (int teama = 0; teama < myTeamMQCount[0]; teama++)
        {
            GameObject myMQ = Instantiate(myBullet[0], myMQSpawnPoint.transform.position, myMQSpawnPoint.transform.rotation) as GameObject;
            myMQ.GetComponent<onMQVer3>().myMQMod = 0;
            myMQ.transform.parent = myMQSpawnPoint.transform.GetChild(0);
            myMQ.SetActive(false);
        }
        for (int teama = 0; teama < myTeamMQCount[1]; teama++)
        {
            GameObject myMQ = Instantiate(myBullet[1], myMQSpawnPoint.transform.position, myMQSpawnPoint.transform.rotation) as GameObject;
            myMQ.gameObject.GetComponent<onMQVer3>().myMQMod = 0;
            myMQ.gameObject.transform.parent = myMQSpawnPoint.transform.GetChild(1);
            myMQ.gameObject.SetActive(false);
        }
        for (int teama = 0; teama < myTeamMQCount[2]; teama++)
        {
            GameObject myMQ = Instantiate(myBullet[2], myMQSpawnPoint.transform.position, myMQSpawnPoint.transform.rotation) as GameObject;
            myMQ.gameObject.GetComponent<onMQVer3>().myMQMod = 0;
            myMQ.gameObject.transform.parent = myMQSpawnPoint.transform.GetChild(2);
            myMQ.gameObject.SetActive(false);
        }
        for (int teama = 0; teama < myTeamMQCount[3]; teama++)
        {
            GameObject myMQ = Instantiate(myBullet[3], myMQSpawnPoint.transform.position, myMQSpawnPoint.transform.rotation) as GameObject;
            myMQ.gameObject.GetComponent<onMQVer3>().myMQMod = 0;
            myMQ.gameObject.transform.parent = myMQSpawnPoint.transform.GetChild(3);
            myMQ.gameObject.SetActive(false);
        }
        for (int teama = 0; teama < myTeamMQCount[4]; teama++)
        {
            GameObject myMQ = Instantiate(myBullet[4], myMQSpawnPoint.transform.position, myMQSpawnPoint.transform.rotation) as GameObject;
            myMQ.gameObject.GetComponent<onMQVer3>().myMQMod = 0;
            myMQ.gameObject.transform.parent = myMQSpawnPoint.transform.GetChild(4);
            myMQ.gameObject.SetActive(false);
        }
    }
    */
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

                        Color a = mySkillBTN[juju].transform.GetChild(1).GetComponent<Image>().color;
                        a.a += Time.deltaTime * 20;
                        mySkillBTN[juju].transform.GetChild(1).GetComponent<Image>().color = a;
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
                        Color aa = mySkillBTN[juju].transform.GetChild(1).GetComponent<Image>().color;
                        aa.a -= Time.deltaTime * 20;
                        mySkillBTN[juju].transform.GetChild(1).GetComponent<Image>().color = aa;
                        break;
                    case 2:
                        isSkillBTNJuiceTime[juju] = false;
                        mySkillBTNJuiceMod[juju] = 0;
                        Vector3 Sca3 = mySkillBTN[juju].GetComponent<RectTransform>().localScale;
                        Sca3.x = 0.848f;
                        Sca3.y = Sca3.x;
                        mySkillBTN[juju].GetComponent<RectTransform>().localScale = Sca3;

                        Color aaa = mySkillBTN[juju].transform.GetChild(1).GetComponent<Image>().color;
                        aaa.a = 0;
                        mySkillBTN[juju].transform.GetChild(1).GetComponent<Image>().color = aaa;
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
    public void myWhenNotPressBTN_forfadeout_if_FN(int btn_num) {
        if (mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color.a < 0) { }
        else {
            Color a = mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color;
            a.a -= Time.deltaTime * 5;
            mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color = a;
        }
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
    public void aaaaa(int juju) {
        
    }

    public void myBTNShakeFN(int myTeam_Num) {
        if (myTeamMQCount[myTeam_Num] > 0) {
            //按鈕晃動
            float bb = Random.Range(1.5f, 2.5f);
            if (mySkillBtnShakeTimer[myTeam_Num] > bb) {
                mySkillBtnShakeRandom[myTeam_Num] = Random.Range(0, 11);
                if (mySkillBtnShakeRandom[myTeam_Num] > 7) {
                    iTween.ShakePosition(mySkillBTN[myTeam_Num].transform.parent.transform.GetChild(1).gameObject, iTween.Hash("z", 20.3f, "time", 0.5f, "delay", 0.0f));
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
                        GameObject myTeamAMQ = Instantiate(myBullet[myTeam_Num], myFirePoint[mySpawnPointRandom].transform.position, myFirePoint[mySpawnPointRandom].transform.rotation) as GameObject;
                        myTeamAMQ.GetComponent<onMQVer3>().myTargetPoint = transform.parent.gameObject.GetComponent<onCamera_dtg>().theLookAtPointOnMonster[transform.parent.gameObject.GetComponent<onCamera_dtg>().myCameraMod];
                        myTeamMQCount[myTeam_Num]--;
                    }
                    else { print("team A MQ is Gown"); }
                    break;
                case 1:
                    if (myTeamMQCount[myTeam_Num] > 0)
                    {
                        mySpawnPointRandom = Random.Range(0, 14);
                        GameObject myTeamAMQ = Instantiate(myBullet[myTeam_Num], myFirePoint[mySpawnPointRandom].transform.position, myFirePoint[mySpawnPointRandom].transform.rotation) as GameObject;
                        myTeamAMQ.GetComponent<onMQVer3>().myTargetPoint = transform.parent.gameObject.GetComponent<onCamera_dtg>().theLookAtPointOnMonster[transform.parent.gameObject.GetComponent<onCamera_dtg>().myCameraMod];
                        myTeamMQCount[myTeam_Num]--;
                    }
                    else { print("team B MQ is Gown"); }
                 break;
                case 2:
                    if (myTeamMQCount[myTeam_Num] > 0)
                    {
                        mySpawnPointRandom = Random.Range(0, 14);
                        GameObject myTeamAMQ = Instantiate(myBullet[myTeam_Num], myFirePoint[mySpawnPointRandom].transform.position, myFirePoint[mySpawnPointRandom].transform.rotation) as GameObject;
                        myTeamAMQ.GetComponent<onMQVer3>().myTargetPoint = transform.parent.gameObject.GetComponent<onCamera_dtg>().theLookAtPointOnMonster[transform.parent.gameObject.GetComponent<onCamera_dtg>().myCameraMod];
                        myTeamMQCount[myTeam_Num]--;
                    }
                    else { print("team C MQ is Gown"); }
                    break;
                case 3:
                    if (myTeamMQCount[myTeam_Num] > 0)
                    {
                        mySpawnPointRandom = Random.Range(0, 14);
                        GameObject myTeamAMQ = Instantiate(myBullet[myTeam_Num], myFirePoint[mySpawnPointRandom].transform.position, myFirePoint[mySpawnPointRandom].transform.rotation) as GameObject;
                        myTeamAMQ.GetComponent<onMQVer3>().myTargetPoint = transform.parent.gameObject.GetComponent<onCamera_dtg>().theLookAtPointOnMonster[transform.parent.gameObject.GetComponent<onCamera_dtg>().myCameraMod];
                        myTeamMQCount[myTeam_Num]--;
                    }
                    else { print("team D MQ is Gown"); }
                  break;
                case 4:
                    if (myTeamMQCount[myTeam_Num] > 0)
                    {
                        mySpawnPointRandom = Random.Range(0, 14);
                        GameObject myTeamAMQ = Instantiate(myBullet[myTeam_Num], myFirePoint[mySpawnPointRandom].transform.position, myFirePoint[mySpawnPointRandom].transform.rotation) as GameObject;
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
  /*  public void myCreatAMQ(){myCreatMQFN(0);}
    public void myCreatBMQ(){myCreatMQFN(1);}
    public void myCreatCMQ(){myCreatMQFN(2);}
    public void myCreatDMQ(){myCreatMQFN(3);}
    public void myCreatEMQ(){myCreatMQFN(4);}*/
    //檢查輸贏
    public void CheckIsWin()
    {
        /*   bool a = GameObject.Find("lookatPointA").GetComponent<OnLookAtPoint>().isGG;
           bool b = GameObject.Find("lookatPointB").GetComponent<OnLookAtPoint>().isGG;
           bool c = GameObject.Find("lookatPointC").GetComponent<OnLookAtPoint>().isGG;
           if (a == true && b == true && c == true) {
               //print("win");
               
           }*/
       // winlose.gameObject.SetActive(true);
        //winlose.text = "You win"+ "/n"+ "Thanks for Playing";
    }
    public void BTN_TeamADown() {myForBTNDown(0);}
    public void BTN_TeamBDown() {myForBTNDown(1);}
    public void BTN_TeamCDown() {myForBTNDown(2);}
    public void BTN_TeamDDown() {myForBTNDown(3);}
    public void BTN_TeamEDown() {myForBTNDown(4);}
    public void myForBTNDown(int btn_num)
    {
        myWhichTeam[btn_num] = true;
        myTeamBTNClick = btn_num + 1;
        mySkillBTN[btn_num].transform.parent.transform.GetChild(1).GetComponent<Image>().sprite = mySkillBTN_Sprite[1];
        mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().sprite = myTeamBTN_hide[1];
        Color a = mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color;
        a.a = 0;
        mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color = a;
    }
  
    /*
    public void BTN_TeamAUp(){
      myWhichTeam[0] = false;
        mySkillBTN[0].transform.parent.transform.GetChild(1).GetComponent<Image>().sprite = mySkillBTN_Sprite[0];

          if (isTeamSkillCD[0]) { }
           else {

                if (myBTNHoldTimer < 0.2)
                {
                    myTeamASkill();
                    myBTNHoldTimer = 0;
                }
                else { myBTNHoldTimer = 0; }
           }
    }
        */
    public void BTN_TeamAUp(){myForBTNUp(0);}
    public void BTN_TeamBUp(){myForBTNUp(1);}
    public void BTN_TeamCUp(){myForBTNUp(2);}
    public void BTN_TeamDUp(){myForBTNUp(3);}
    public void BTN_TeamEUp(){myForBTNUp(4);}
    public void myForBTNUp(int btn_num)
    {
        myWhichTeam[btn_num] = false;
        mySkillBTN[btn_num].transform.parent.transform.GetChild(1).GetComponent<Image>().sprite = mySkillBTN_Sprite[0];
        mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().sprite = myTeamBTN_hide[0];
        Color a = mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color;
        a.a = 1;
        mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color = a;
    }
   
    public void myCheckIsWhichTeam()
    {
        if (myWhichTeam[0])
        {
            myFireBTNPress_fadinFN(0);
            if (isPutMQTime) {
                //myCreatAMQ();
                myCreatMQFN(0);
                isPutMQTime = false;
            }
        }
        if (myWhichTeam[1])
        {
            myFireBTNPress_fadinFN(1);
            if (isPutMQTime) {
                isPutMQTime = false;
                //myCreatBMQ();
                myCreatMQFN(1);
            }
        }
        if (myWhichTeam[2])
        {
            myFireBTNPress_fadinFN(2);
            if (isPutMQTime) {
                isPutMQTime = false;
                //myCreatCMQ();
                myCreatMQFN(2);
            }
        }
        if (myWhichTeam[3])
        {
            myFireBTNPress_fadinFN(3);
            if (isPutMQTime) {
                isPutMQTime = false;
                //myCreatDMQ();
                myCreatMQFN(3);
            }
        }
        if (myWhichTeam[4])
        {
            myFireBTNPress_fadinFN(4);
            if (isPutMQTime) {
                isPutMQTime = false;
                //myCreatEMQ();
                myCreatMQFN(4);
            }
        }
    }
    public void myFireBTNPress_fadinFN(int btn_num) {
        Color a = mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color;
        a.a += Time.deltaTime * 5f;
        mySkillBTN[btn_num].transform.parent.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>().color = a;
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
        GameObject[] MQA = GameObject.FindGameObjectsWithTag("MQA");
        if (MQA.Length > 29)        {            mySkillCheck_nothide_FN(0);            //mySkillBTN[0].SetActive(true);
        }
        else { mySkillCheck_hide_FN(0); }
    }
    public void myBSkillCheck()
    {
        GameObject[] MQB = GameObject.FindGameObjectsWithTag("MQB");
        if (MQB != null && MQB.Length > 19)        {            mySkillCheck_nothide_FN(1);        }
        else { mySkillCheck_hide_FN(1); }
    }
    public void myCSkillCheck()
    {
        GameObject[] MQC = GameObject.FindGameObjectsWithTag("MQC");
        if (MQC != null && MQC.Length > 19)        {            mySkillCheck_nothide_FN(2);        }
        else { mySkillCheck_hide_FN(2); }
    }
    public void myDSkillCheck()
    {
        GameObject[] MQD = GameObject.FindGameObjectsWithTag("MQD");
        if (MQD != null && MQD.Length > 19)        {            mySkillCheck_nothide_FN(3);        }
        else { mySkillCheck_hide_FN(3); }
    }
    public void myESkillCheck()
    {
        GameObject[] MQE = GameObject.FindGameObjectsWithTag("MQE");
        if (MQE != null && MQE.Length > 19)        {            mySkillCheck_nothide_FN(4);        }
        else { mySkillCheck_hide_FN(4); }
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
        myCDBlack[btn_skillnum].GetComponent<Image>().fillAmount = 1;
        myCDBlack[btn_skillnum].GetComponent<Image>().raycastTarget = true;
        mySkillBTN[btn_skillnum].GetComponent<Button>().enabled = false;
    }
  


    public void myTeamASkill()
    {
        /*myAudioSource.clip = mySoundEffectData[0];
        myAudioSource.enabled = false;
        myAudioSource.enabled = true;*/
        print("team a be call");
        isTeamSkillCD[0] = true;
        isSuperStarTime = true;
        isTeamSkillReady[0] = false;
        myCDBlack[0].GetComponent<Image>().fillAmount = 1;
        mySkillBTN[0].GetComponent<Button>().enabled = false;

        GameObject[] MQ = GameObject.FindGameObjectsWithTag("MQ");
        GameObject UI =  Instantiate(myskillUI[0], transform.position, Quaternion.identity) as GameObject;
        UI.transform.parent = GameObject.Find("Canvas").transform;
        UI.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        //if (MQ != null) {
        for (int a = 0; a < MQ.Length; a++)
        {
            print("發動技能-無敵星星3秒鐘");
            //MQ[a].GetComponent<onMQVer3>().SendMessage("myMQSkill");
            MQ[a].GetComponent<onMQVer3>().isSuperStarTime = true;
        }//*/

    }
    public void myTeamBSkill()
    {
       /* myAudioSource.clip = mySoundEffectData[1];
        myAudioSource.enabled = false;
        myAudioSource.enabled = true;*/

        isTeamSkillCD[1] = true;
        isTeamSkillReady[1] = false;
        myCDBlack[1].GetComponent<Image>().fillAmount = 1;
        mySkillBTN[1].GetComponent<Button>().enabled = false;
        GameObject[] MQ = GameObject.FindGameObjectsWithTag("MQ");
        GameObject UI = Instantiate(myskillUI[1], transform.position, Quaternion.identity) as GameObject;
        UI.transform.parent = GameObject.Find("Canvas").transform;
        UI.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        for (int a = 0; a < MQ.Length; a++)
        {
            print("發動技能-我的血又變滿囉！");
            //MQ[a].GetComponent<onMQVer3>().SendMessage("myMQSkill");
            MQ[a].GetComponent<onMQVer3>().myHP = MQ[a].GetComponent<onMQVer3>().myFullHP;
        }

    }
    public void myTeamCSkill()
    {
        /*myAudioSource.clip = mySoundEffectData[2];
        myAudioSource.enabled = false;
        myAudioSource.enabled = true;*/

        isTeamSkillCD[2] = true;
        isTeamSkillReady[2] = false;
        myCDBlack[2].GetComponent<Image>().fillAmount = 1;
        mySkillBTN[2].GetComponent<Button>().enabled = false;
        print("發動技能-5倍的傷害");
        GameObject[] MQ = GameObject.FindGameObjectsWithTag("MQ");
        GameObject UI = Instantiate(myskillUI[2], transform.position, Quaternion.identity) as GameObject;
        UI.transform.parent = GameObject.Find("Canvas").transform;
        UI.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        for (int a = 0; a < MQ.Length; a++) { MQ[a].GetComponent<onMQVer3>().myAttack = MQ[a].GetComponent<onMQVer3>().myAttack * 5; }

    }
    public void myTeamDSkill()
    {
      /*  myAudioSource.clip = mySoundEffectData[3];
        myAudioSource.enabled = false;
        myAudioSource.enabled = true;*/

        isTeamSkillCD[3] = true;
        isTeamSkillReady[3] = false;
        myCDBlack[3].GetComponent<Image>().fillAmount = 1;
        mySkillBTN[3].GetComponent<Button>().enabled = false;
        print("發動技能-公訴加倍");
        GameObject[] MQ = GameObject.FindGameObjectsWithTag("MQ");
        GameObject UI = Instantiate(myskillUI[3], transform.position, Quaternion.identity) as GameObject;
        UI.transform.parent = GameObject.Find("Canvas").transform;
        UI.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        for (int a = 0; a < MQ.Length; a++) { MQ[a].GetComponent<onMQVer3>().myAttackTimerTarget = (int)MQ[a].GetComponent<onMQVer3>().myAttackTimerTarget * 0.5f; }

    }
    public void myTeamESkill()
    {
      /*  myAudioSource.clip = mySoundEffectData[4];
        myAudioSource.enabled = false;
        myAudioSource.enabled = true;*/

        isTeamSkillCD[4] = true;
        isTeamSkillReady[4] = false;
        myCDBlack[4].GetComponent<Image>().fillAmount = 1;
        mySkillBTN[4].GetComponent<Button>().enabled = false;
        print("發動技能-爆告加倍");
        GameObject[] MQ = GameObject.FindGameObjectsWithTag("MQ");
        GameObject UI = Instantiate(myskillUI[4], transform.position, Quaternion.identity) as GameObject;
        UI.transform.parent = GameObject.Find("Canvas").transform;
        UI.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        for (int a = 0; a < MQ.Length; a++) { MQ[a].GetComponent<onMQVer3>().myCritHit = (int)MQ[a].GetComponent<onMQVer3>().myCritHit * 2; }

    }
    //技能CD
    public void myTeamCDController()
    {
        if (isTeamSkillCD[0]){myTeamCD_inIF_FN(0);}
        if (isTeamSkillCD[1]){myTeamCD_inIF_FN(1);}
        if (isTeamSkillCD[2]){myTeamCD_inIF_FN(2);}
        if (isTeamSkillCD[3]){myTeamCD_inIF_FN(3);}
        if (isTeamSkillCD[4]){myTeamCD_inIF_FN(4);}
    }
    public void myTeamCD_inIF_FN(int myteanskill_num)
    {
        if (isTeamSkillCDTimer[myteanskill_num] > isTeamSkillCdTime[myteanskill_num])//cd秒數
        {
            myCDBlack[myteanskill_num].GetComponent<Image>().fillAmount = 0;
            isTeamSkillCDTimer[myteanskill_num] = 0;
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
            myCDBlack[myteanskill_num].GetComponent<Image>().fillAmount = 1 - (isTeamSkillCDTimer[myteanskill_num] / isTeamSkillCdTime[myteanskill_num]);
            isTeamSkillCDTimer[myteanskill_num] += Time.deltaTime;
        }
    }
    //蚊子數量更新
    public void myAmountUpdate()
    {
        /* Text_myTeamAAmount.text = myABulletCount.ToString();//TeamAAmount.ToString();
         myTeamAmount_Image[1].text = myBBulletCount.ToString();
         myTeamAmount_Image[2].text = myCBulletCount.ToString();
         myTeamAmount_Image[3].text = myDBulletCount.ToString();
         myTeamAmount_Image[4].text = myEBulletCount.ToString();*/

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
}
