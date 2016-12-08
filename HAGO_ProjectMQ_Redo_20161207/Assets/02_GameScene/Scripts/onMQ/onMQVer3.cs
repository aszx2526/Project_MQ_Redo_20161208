using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class onMQVer3 : MonoBehaviour {
    public int WhatKindOfMQAmI;//0基本,1炸彈,2冰,3殭屍,4未定 5嫩
    [Header("蚊子滿血血量")]
    public int myFullHP;//血量
    [Header("蚊子血量")]
    public int myHP;//血量
    [Header("蚊子移動速度")]
    public float myMoveSpeed;//蚊子的跑速
    [Header("蚊子攻擊力")]
    public int myAttack;
    [Header("蚊子多久打一下(秒)")]
    public float myAttackTimerTarget;
    [Header("蚊子爆擊率")]
    public int myCritHit;


    public GameObject myTargetPoint;//蚊子咬哪邊
    public bool isAttackTime;//該打怪了嗎？
    public bool isBeHit;
    public bool isHitFlyAway;
    public bool isNeedToMoveToNextPoint;//要咬下個地方嗎？
    public bool isLockNextTarget;//鎖定要打哪裡了嗎？
    public float myScaleControl;//蚊子多大隻
    public float myAttackTimer;
    //--------------------------------------
    public bool isSuperStarTime;
    float isSuperStarTimer;
    public GameObject green;

    public bool isAttackPowerUpTime;
    float isAttackPowerUpTimer;

    public bool isAttackSpeedUpTime;
    float isAttackSpeedUpTimer;

    public bool isCritHitUpTime;
    float isCritHitUpTimer;

    //---------------------------------------
    public int myMQAniMod;
    public float myHitflyAwayTime;
    public float myHitflyAwayTimer;
    
    public GameObject DeadEffect;
    public GameObject myChildMQ;
    float deadtimer;

    Vector3 myTargetPointRandom;

    public GameObject myCameraVer2;
    public GameObject[] myHitPointListOnMonster;


    public GameObject[] myHitEffect;
    public GameObject myHitEffectPoint;
    //---------------------------------
    public GameObject[] myBodyList;
    public Material myMaterialForDie;

    //-----------------
    public int myMQMod;//0=不動了 1=戰鬥中

    // Use this for initialization
    void Start()
    {
        myHP = myFullHP;
        //DeadEffect.SetActive(false);
        //green.SetActive(false);
        transform.localScale = new Vector3(myScaleControl, myScaleControl, myScaleControl);
        //myTargetPoint = GameObject.Find("MainCamera").GetComponent<OnCameraLookAt>().HotPointList[GameObject.Find("MainCamera").GetComponent<OnCameraLookAt>().cameraMod];
        myCameraVer2 = GameObject.Find("CameraVer2_DTG");
        //↓myTargetPoint的設定修改至 OnCameraForShootMQ.cs myCreatMQFN();裡面執行 
        myTargetPoint = myCameraVer2.GetComponent<onCamera_dtg>().theLookAtPointOnMonster[myCameraVer2.GetComponent<onCamera_dtg>().myCameraMod];
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        myTargetPointRandom = myTargetPoint.transform.position;
        /*myTargetPointRandom.x = Random.Range(myTargetPoint.transform.position.x - 0.05f, myTargetPoint.transform.position.x + 0.05f);
        myTargetPointRandom.y = Random.Range(myTargetPoint.transform.position.y - 0.05f, myTargetPoint.transform.position.y + 0.05f);
        */
        //transform.rotation = GameObject.Find("MainCamera").transform.rotation;

        myHitPointListOnMonster = myCameraVer2.GetComponent<onCamera_dtg>().theLookAtPointOnMonster;
    }

    // Update is called once per frame
    void Update()
    {
        if (myHP < 1)//被打三下就得死
        {
            if (deadtimer >= 1.5f)
            {
                if (WhatKindOfMQAmI == 5) {
                    deadtimer = 0;
                    Destroy(gameObject);
                }
                else {
                    deadtimer = 0;
                    GameObject.Find("MainCamera").GetComponent<OnCameraForShootMQ>().myHowManyMQOnScene--;
                    gameObject.transform.parent = null;
                    gameObject.SetActive(false);
                    //Destroy(gameObject);
                }
            }
            else {
                /*for (int a = 0; a < myBodyList.Length - 2; a++) {
                    myBodyList[a].GetComponent<SkinnedMeshRenderer>().material = 
                }*/
                //myChildMQ.SetActive(false);
                //DeadEffect.SetActive(true);
                deadtimer += Time.deltaTime;
            }
        }
        else if (isHitFlyAway) { myBeHitThenFlyAway(); }
        else if (myTargetPoint.GetComponent<onHitPoint_UpdateHureValue>().isPartBreak)
        {
            if (myTargetPoint.name == "hitpoint-2" || myTargetPoint.name == "hitpoint-3") { }
            else {
                isAttackTime = false;
                isNeedToMoveToNextPoint = true;
            }
        }
        myMQModController();
        //mydisAtoBis = Vector3.Distance(gameObject.transform.position, myTargetPoint.transform.position);

        //myMQAnimController();
        MQBuff();
    }
    public void MQBuff() {
        if (isSuperStarTime)
        {
            if (isSuperStarTimer >= 5){isSuperStarTimer = 0;isSuperStarTime = false;}
            else {isSuperStarTimer += Time.deltaTime;}
        }
        if (isAttackPowerUpTime) {
            if (isAttackPowerUpTimer >= 5) { isAttackPowerUpTimer = 0; isAttackPowerUpTime = false; }
            else { isAttackPowerUpTimer += Time.deltaTime; }
        }
        if (isAttackSpeedUpTime) {
            if (isAttackSpeedUpTimer >= 5) { isAttackSpeedUpTimer = 0; isAttackSpeedUpTime = false; }
            else { isAttackSpeedUpTimer += Time.deltaTime; }
        }
        if (isCritHitUpTime) {
            if (isCritHitUpTimer >= 5) { isCritHitUpTimer = 0; isCritHitUpTime = false; }
            else { isCritHitUpTimer += Time.deltaTime; }
        }

    }
    public void myMQModController()
    {
        if (isBeHit) { myMQAniMod = 3; }
        else if (isAttackTime)
        {
            //print("夠近拉，可以打人了");
            if (myAttackTimer >= myAttackTimerTarget)
            {
                myMQAniMod = 0;
            }
            else {
                myMQAniMod = 1;
                myAttackTimer += Time.deltaTime;
            }
        }
        else {
            if (isNeedToMoveToNextPoint)
            {//判斷是否要飛到下一個點
                myMQAniMod = 2;
                myMoveToNextPoint();
            }
            else {
                myMQAniMod = 2;
                myFlyToTarget();
            }
        }
    }
    public void myFlyToTarget() {
        gameObject.transform.LookAt(myTargetPoint.transform);
        myTargetPointRandom = myTargetPoint.transform.position;
        transform.position = Vector3.Lerp(transform.position, myTargetPointRandom, Time.deltaTime * myMoveSpeed);
        //print("move to target");
    }
    public void myBeHitThenFlyAway() {
        if (myHitflyAwayTimer >= myHitflyAwayTime)
        {
            myHitflyAwayTimer = 0;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            isHitFlyAway = false;
            myMoveSpeed = 1.5f;
        }
        else {
            myHitflyAwayTimer += Time.deltaTime;
            gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward*-8;
            isAttackTime = false;
            transform.parent = null;
        }
    }
    public void myMoveToNextPoint() {
        //讓蚊子飛到下一個點
        myMoveSpeed = 1;
        if (!isLockNextTarget) {
            switch (myTargetPoint.GetComponent<onHitPoint_UpdateHureValue>().myFather.name) {
                case "Bigeye_":
                    if (myTargetPoint.name == "hitpoint-1")
                    {
                      //  print("hitpoint is 1");
                        if (GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[3].GetComponent<onHitPoint_UpdateHureValue>().isPartBreak ||
                            GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[4].GetComponent<onHitPoint_UpdateHureValue>().isPartBreak)
                        {
                            int a = Random.Range(0, 2);
                            if (a == 0) { myTargetPoint = GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[1]; isLockNextTarget = true; }
                            else { myTargetPoint = GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[2]; isLockNextTarget = true; }
                        }
                        else {
                            int a = Random.Range(0, 2);
                            if (a == 0) { myTargetPoint = GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[3]; isLockNextTarget = true; }
                            else { myTargetPoint = GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[4]; isLockNextTarget = true; }
                            
                        }
                    }
                    else if (myTargetPoint.name == "hitpoint-4" || myTargetPoint.name == "hitpoint-5")
                    {
                        if (GameObject.Find("hitpoint-1").GetComponent<onHitPoint_UpdateHureValue>().isPartBreak)
                        {
                            int a = Random.Range(0, 2);
                            if (a == 0) { myTargetPoint = GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[1]; isLockNextTarget = true; }
                            else { myTargetPoint = GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[2]; isLockNextTarget = true; }
                        }
                        else { myTargetPoint = GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[0]; isLockNextTarget = true; }
                    }
                    break;
                case "Bear":
                    if (myTargetPoint.name == "hitpoint-1")
                    {
                        if (GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[3].GetComponent<onHitPoint_UpdateHureValue>().isPartBreak ||
                            GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[4].GetComponent<onHitPoint_UpdateHureValue>().isPartBreak)
                        {
                            int a = Random.Range(0, 2);
                            if (a == 0) { myTargetPoint = GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[3]; isLockNextTarget = true; }
                            else { myTargetPoint = GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[4]; isLockNextTarget = true; }
                        }
                        else {
                            int a = Random.Range(0, 2);
                            if (a == 0) { myTargetPoint = GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[1]; isLockNextTarget = true; }
                            else { myTargetPoint = GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[2]; isLockNextTarget = true; }
                        }
                    }
                    else if (myTargetPoint.name == "hitpoint-4" || myTargetPoint.name == "hitpoint-5")
                    {
                        if (GameObject.Find("hitpoint-1").GetComponent<onHitPoint_UpdateHureValue>().isPartBreak)
                        {
                            int a = Random.Range(0, 2);
                            if (a == 0) { myTargetPoint = GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[1]; isLockNextTarget = true; }
                            else { myTargetPoint = GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[2]; isLockNextTarget = true; }
                        }
                        else { myTargetPoint = GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[0]; isLockNextTarget = true; }
                    }
                    break;
                default:
                    break;
            }
            
        }
       // if (transform.parent.gameObject.name != myTargetPoint.name&& transform.parent != null) { transform.parent = null; }
        myFlyToTarget();
    }
    public void myMQSkill() {
        if (GameObject.Find("MainCamera").GetComponent<OnCameraForShootMQ>().myTeamBTNClick == WhatKindOfMQAmI) {
            switch (WhatKindOfMQAmI)
            {
                case 1:
                    print("onMQVer3 Team A mq skill be call");
                    break;
                case 2:
                    print("onMQVer3 Team B mq skill be call");
                    break;
                case 3:
                    print("onMQVer3 Team C mq skill be call");
                    break;
                case 4:
                    print("onMQVer3 Team D mq skill be call");
                    break;
                case 5:
                    print("onMQVer3 Team E mq skill be call");
                    break;
                default:
                    break;
            }
        }
    }
    public void forHitEffect_Ver2(int if0IsPush1IsCritis,int myHurtValue) {
        switch (if0IsPush1IsCritis) {
            case 0:
                GameObject pusheffect = Instantiate(myHitEffect[0], myHitEffectPoint.transform.position, myHitEffectPoint.transform.rotation) as GameObject;
                break;
            case 1:
                GameObject critiseffect = Instantiate(myHitEffect[1], myHitEffectPoint.transform.position, myHitEffectPoint.transform.rotation) as GameObject;
                critiseffect.transform.GetChild(1).GetComponent<onHitUI>().myBigHitValue = myHurtValue;
                critiseffect.transform.GetChild(1).GetComponent<onHitUI>().isBigHit = if0IsPush1IsCritis;
                /* critiseffect.transform.GetChild(1).transform.parent = GameObject.Find("Canvas").transform;
                 critiseffect.transform.GetChild(1).transform.position = Camera.main.WorldToScreenPoint(critiseffect.transform.position);
                 critiseffect.transform.GetChild(1).GetComponent<onHitUI>().myBigHitValue = myHurtValue;*/
                break;
            default:
                break;
        }
    }
}

/*public void forHitEffect(int hurtValue,int isBigHit)
//public void forHitEffect(int isBigHit, string hurt, string RGB)
    {
        //print(gameObject.name + "forhiteffect");
        GameObject hiteffect = Instantiate(myHitEffect[isBigHit], Vector3.zero, Quaternion.identity) as GameObject;
        hiteffect.GetComponent<onHitUI>().myBigHitValue = hurtValue;
        hiteffect.GetComponent<onHitUI>().isBigHit = isBigHit;
        hiteffect.transform.parent = GameObject.Find("Canvas").transform;
        Vector2 a = Vector2.zero; //= myHPText.GetComponent<RectTransform>().anchoredPosition;

        hiteffect.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(a.x - 150, a.x + 150), Random.Range(a.y - 50, a.y + 100));
        //hiteffect.GetComponentInChildren<Text>().text = hurt;
        switch (RGB)
        {
            case "R":
                Color c = hiteffect.GetComponentInChildren<Text>().color;
                c.r = 255;
                c.g = c.b = 0;
                hiteffect.GetComponentInChildren<Text>().color = c;
                break;
            case "B":
                Color cc = hiteffect.GetComponentInChildren<Text>().color;
                cc.b = 255;
                cc.r = cc.g = 0;
                hiteffect.GetComponentInChildren<Text>().color = cc;
                break;
        }
    }*/
/*public void Hitmob(int _minus, int isCriticalHit)
{
  //if (mymonsterMod != 2)
  //{//攻擊結束才扣血
    //  mobHP -= _minus;
 if (isCriticalHit == 0)
 {
     //forHitEffect(0, _minus.ToString(), "R");
     forHitEffect(_minus,0);
 }
 else {
     //forHitEffect(1, _minus.ToString(), "R");
     forHitEffect(_minus, 1);
 }
 //ValueShowOut.Born(gameObject, _minus,1);
 //setMobText();
 //}
}*/

/* if (Input.GetKeyDown(",")){
     if (myMQAniMod < 0) { myMQAniMod = 4; }
     else { myMQAniMod--; }
 }
 if (Input.GetKeyDown("."))
 {
     if (myMQAniMod > 4) { myMQAniMod = 0; }
     else { myMQAniMod++; }
 }*/
