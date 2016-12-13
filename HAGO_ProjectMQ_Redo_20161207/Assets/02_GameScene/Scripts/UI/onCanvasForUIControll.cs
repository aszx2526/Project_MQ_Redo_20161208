using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class onCanvasForUIControll : MonoBehaviour {
    [Header("Level編號")]
    public int myLevelID;
    public GameObject myMainUI;
    public GameObject myMiniMap;
    public GameObject myMission;
    public GameObject myArmyInfo;
    public GameObject myAddMQ;
    public GameObject myChangeArmy;
    public GameObject mySupplyStation;
    public GameObject myLevelClear;
    public GameObject myEventClear;
    public GameObject myAttackPartLocker;
    public AudioClip[] mySoundEffectData;
    public AudioSource myAudioSource;
    [Header("=======================")]
    public bool isGameStart;
    public bool isPlayerLose;
    public int myAllLocalMQCount;
    [Header("全星積分")]
    public int myScoreGetAllStar;
    public int myScoreCount_All;//得分總計
    //public  myScoreCount_All;//得分總計
    public int myScoreCount;//得分小記
    public int myCoinCount;//金幣
    public int myStarGet;//取得星星數
    [Header("=======================")]
    [Header("怪物起始士氣值：")]
    public float myMonsterBasicMorale;
    [Header("設定怪物回氣值：")]
    public float myMonsterMoraleRestoreValue;
    [Header("蚊子傷害變數：")]
    public float myMonsterMoraleBloodValue;
    [Header("原生蚊種類：")]
    public int myLocalMQ_Mob;//123 等阿龐給我對應表
    [Header("原生蚊數量：")]
    public int myLocalMQ_Amount;
    [Header("原生蚊1秒產出量")]
    public float myLocalMQ_CreateSpeed;
    public int myLocalMQ_AmountFull;
    [Header("怪物士氣值：")]
    public float myMonsterMorale;
    [Header("=======================")]
    //public float myMonsterMoraleBloodValue;
    public GameObject[] myMonsterMoraleCounter;
    public float myMonsterMoralCounterTimer;
    [Header("=======================")]
    public GameObject myUICenter;
    // Use this for initialization
    void Start () {
        myScoreGetAllStar = myLevelClear.GetComponent<onUI_LevelClear>().myScoreGetAllStar;
        isGameStart = false;
        myAudioSource = gameObject.GetComponent<AudioSource>();
        myMiniMap.SetActive(true);
        myMission.SetActive(false);
        myArmyInfo.SetActive(false);
        myAddMQ.SetActive(false);
        myChangeArmy.SetActive(false);
        mySupplyStation.SetActive(false);
        myLevelClear.SetActive(false);
        myEventClear.SetActive(false);
        myAllLocalMQCount = myMonsterMoraleCounter[0].GetComponent<Blip>().myLocalMQ_Amount + myMonsterMoraleCounter[1].GetComponent<Blip>().myLocalMQ_Amount + myMonsterMoraleCounter[2].GetComponent<Blip>().myLocalMQ_Amount + myMonsterMoraleCounter[3].GetComponent<Blip>().myLocalMQ_Amount;
    }
	
	// Update is called once per frame
	void Update () {
        //關卡通關成功失敗判定
        if (isPlayerLose) {
            myLevelClear.SetActive(true);
        }
        else if (myAllLocalMQCount<=0) {
            myLevelClear.SetActive(true);
        }



        //小地圖士氣增加
        if (myMonsterMoralCounterTimer >= 1) {
            myMonsterMoralCounterTimer = 0;
            for (int a = 0; a < myMonsterMoraleCounter.Length; a++) {
                if (myMonsterMoraleCounter[a].GetComponent<Blip>().myMonsterBasicMorale > 100 || myMonsterMoraleCounter[a].GetComponent<Blip>().myMonsterBasicMorale < 0) { }//如果分勝負就不要做加減
                else if (myMonsterMoraleCounter[a].GetComponent<Blip>().Target.GetComponent<onMonsterVer3>().isMeToFight) { }//如果怪物被選到了也不做增減
                else {//小地圖士氣增加1/10
                    myMonsterMoraleCounter[a].GetComponent<Blip>().myMonsterBasicMorale += myMonsterMoraleCounter[a].GetComponent<Blip>().myMonsterMoraleRestoreValue * 0.1f;
                }
                
            }
        }
        else {//士氣增加計時器
            myMonsterMoralCounterTimer += Time.deltaTime;
        }

    }
    public void BTN_Left1() {

        mySoundEffectFN();
        myMiniMap.SetActive(true);
        myMission.SetActive(false);
        myArmyInfo.SetActive(false);
        myAddMQ.SetActive(false);
        myChangeArmy.SetActive(false);
        mySupplyStation.SetActive(false);
        mySoundEffectFN();
    }
    public void BTN_Left2() {
        mySoundEffectFN();
        myMiniMap.SetActive(false);
        myMission.SetActive(true);
        myArmyInfo.SetActive(false);
        myAddMQ.SetActive(false);
        myChangeArmy.SetActive(false);
        mySupplyStation.SetActive(false);
        
    }
    public void BTN_Left3() {
        mySoundEffectFN();
        myMiniMap.SetActive(false);
        myMission.SetActive(false);
        myArmyInfo.SetActive(true);
        myAddMQ.SetActive(false);
        myChangeArmy.SetActive(false);
        mySupplyStation.SetActive(false);
        
    }
    public void BTN_Left4() {
        mySoundEffectFN();
        myMiniMap.SetActive(false);
        myMission.SetActive(false);
        myArmyInfo.SetActive(false);
        myAddMQ.SetActive(false);
        myChangeArmy.SetActive(false);
        mySupplyStation.SetActive(true);
        
    }
    public void BTN_Left5() {
        //回大地圖
        /*mySoundEffectFN();
        SceneManager.LoadScene(4);*/
        myLevelClear.SetActive(true);

    }
    public void BTN_Left6() {
        //大地圖戰鬥
        mySoundEffectFN();
        myLocalMQ_AmountFull = myLocalMQ_Amount;
        myMonsterMorale = myMonsterBasicMorale;
        myAttackPartLocker.SetActive(true);
        GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().isMoveTime = true;
        isGameStart = true;
        GameObject.Find("MainCamera").GetComponent<onMainCameraVer2>().isNeedToFollow = true;
        GameObject.Find("MainCamera").GetComponent<OnCameraForShootMQ>().myTeamMQCount[0] = GameObject.Find("MiniMap").GetComponent<OnMiniMap>().TeamAAmount;
        GameObject.Find("MainCamera").GetComponent<OnCameraForShootMQ>().myTeamMQCount[1] = GameObject.Find("MiniMap").GetComponent<OnMiniMap>().TeamBAmount;
        GameObject.Find("MainCamera").GetComponent<OnCameraForShootMQ>().myTeamMQCount[2] = GameObject.Find("MiniMap").GetComponent<OnMiniMap>().TeamCAmount;
        GameObject.Find("MainCamera").GetComponent<OnCameraForShootMQ>().myTeamMQCount[3] = GameObject.Find("MiniMap").GetComponent<OnMiniMap>().TeamDAmount;
        GameObject.Find("MainCamera").GetComponent<OnCameraForShootMQ>().myTeamMQCount[4] = GameObject.Find("MiniMap").GetComponent<OnMiniMap>().TeamEAmount;

        //GameObject.Find("MainCamera").GetComponent<OnCameraForShootMQ>().SendMessage("myGameAwakeTestFN");
       
        //myMonsterMoraleBloodValue = myMonsterBasicMorale / (float)GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().myMonsterList[GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().myPickUpNum - 1].GetComponent<onMonsterVer3>().myFullHP;
        myMainUI.SetActive(false);
        
    }
    public void BTN_forAddMQ() {
        mySoundEffectFN();
        myAddMQ.SetActive(true);
        
    }
    public void BTN_forAddMQExit() {
        mySoundEffectFN();
        myAddMQ.SetActive(false);
        
    }
    public void BTN_forChangeArmy() {
        mySoundEffectFN();
        myChangeArmy.SetActive(true);
        
    }
    public void BTN_forChangeArmyExit() {
        mySoundEffectFN();
        myChangeArmy.SetActive(false);
        
    }
    /*public void BTN_forSetting() {
        //if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart) { }
        isGameStart = false;
        mySoundEffectFN();
        myMainUI.SetActive(true);
    }*/

    public void mySoundEffectFN() {
       // print("UI sound");
        myAudioSource.clip = mySoundEffectData[0];
        myAudioSource.enabled = false;
        myAudioSource.enabled = true;
    }
    /*
    public void Testbtn1() { }// GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().SendMessage("changeViewControllFN"); }
    public void Testbtn2() { GameObject.Find("MainCamera").GetComponent<OnCameraForShootMQ>().SendMessage("myCreatAMQ"); }*/
}
