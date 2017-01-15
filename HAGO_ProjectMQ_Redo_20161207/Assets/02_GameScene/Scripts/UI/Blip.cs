using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Blip : MonoBehaviour {
    [Header("設定怪物編號：")]
    public int myMonsterID;
    [Header("設定怪物品種：")]
    public int myKindOfMonsterID;//0=眼怪 1=熊
    [Header("設定怪物起始士氣值：")]
    public float myMonsterBasicMorale;
    [Header("設定怪物回氣值：")]
    public float myMonsterMoraleRestoreValue;
    [Header("蚊子傷害變數：")]
    public float myMonsterMoraleBloodValue;
    [Header("設定原生蚊種類：")]
    public int myLocalMQ_Mob;//123 等阿龐給我對應表
    [Header("設定原生蚊數量：")]
    public int myLocalMQ_Amount;
    [Header("設定原生蚊1秒產出量")]
    public float myLocalMQ_CreateSpeed;
    public Transform miniTarget;// 小地圖的目標物件，搞定比例尺
    public Transform Target;//場景上的怪物物件
    public string[] MQTalkString;//MQ哀哀叫的字串
    public GameObject[] MQEnmotion;//MQ表情符號
    public Text myMQTalkText;
    public Image[] UI_myIconOnMiniMap;//0怪 1 MQ
    public Sprite[] UI_whenSomeOneDead;
    //MiniMap map;
    /*[Header("免設定，自動抓")]
    public RectTransform myRectTransform;*/
    public float zoonlevel;// = 10f;
    
    void Star() {
        //UI_myIconOnMiniMap[0] = GetComponent<RectTransform>().GetChild(0).gameObject;
     //   myMQTalkText = gameObject.GetComponent<RectTransform>().GetChild(1).GetComponent<RectTransform>().GetChild(0).GetComponent<RectTransform>().GetChild(0).GetComponent<Text>();
     // myRectTransform = transform.GetChild(0).GetCo mponent<RectTransform>();
    }
    void Update() {
        if (Target.GetComponent<onMonsterVer3>().isMeDead) {
            //怪物死掉，換小地圖上怪物icon的圖
            UI_myIconOnMiniMap[0].sprite = UI_whenSomeOneDead[0];
            myMQTalkText.text = MQTalkString[5];//MQ say good
        }
        if (myMonsterBasicMorale >= 100) {
            //怪物士氣100=蚊子死光光，換小地圖蚊子icon的圖
            UI_myIconOnMiniMap[1].sprite = UI_whenSomeOneDead[1];
            myMQTalkText.text = MQTalkString[4];//MQ say GG
        }
        else {
            if (myMonsterBasicMorale > 40 && myMonsterBasicMorale < 50) {
                MQEnmotion[0].SetActive(true);
                MQEnmotion[1].SetActive(false);
                MQEnmotion[2].SetActive(false);
                MQEnmotion[3].SetActive(false);
                MQEnmotion[4].SetActive(false);
            }//50
            if (myMonsterBasicMorale > 50 && myMonsterBasicMorale < 60) {
                MQEnmotion[0].SetActive(false);
                MQEnmotion[1].SetActive(true);
                MQEnmotion[2].SetActive(false);
                MQEnmotion[3].SetActive(false);
                MQEnmotion[4].SetActive(false);
            }//40
            if (myMonsterBasicMorale > 60 && myMonsterBasicMorale < 70) {
                MQEnmotion[0].SetActive(false);
                MQEnmotion[1].SetActive(false);
                MQEnmotion[2].SetActive(true);
                MQEnmotion[3].SetActive(false);
                MQEnmotion[4].SetActive(false);
            }//30
            if (myMonsterBasicMorale > 70 && myMonsterBasicMorale < 80) {
                MQEnmotion[0].SetActive(false);
                MQEnmotion[1].SetActive(false);
                MQEnmotion[2].SetActive(false);
                MQEnmotion[3].SetActive(true);
                MQEnmotion[4].SetActive(false);
            }//20
            if (myMonsterBasicMorale > 80 && myMonsterBasicMorale < 90) {
                MQEnmotion[0].SetActive(false);
                MQEnmotion[1].SetActive(false);
                MQEnmotion[2].SetActive(false);
                MQEnmotion[3].SetActive(false);
                MQEnmotion[4].SetActive(true);
            }//10
        }

        if (Target.GetComponent<onMonsterVer3>().isMeToFight) {
            //將本來出戰按鈕上的圖片換成您選到的怪物
            //不過現在沒有用了
            //因為直接點選怪物就會進入戰鬥畫面了
        //    GameObject.Find("btn_battle").GetComponent<onBTN_Battle>().myBtnIcon_image.sprite = GameObject.Find("btn_battle").GetComponent<onBTN_Battle>().myBattleBtnImageList[myKindOfMonsterID];
        }
        //同步數值用，把在小地圖icon上的數值同步到Canvas 去做總控制
        if (myMonsterID == GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().myPickUpNum) {
            onCanvasForUIControll myCFUIC = GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>();
            myCFUIC.myMonsterBasicMorale = myMonsterBasicMorale;
            myCFUIC.myMonsterMoraleRestoreValue = myMonsterMoraleRestoreValue;
            myCFUIC.myMonsterMoraleBloodValue = myMonsterMoraleBloodValue;
            myCFUIC.myLocalMQ_Mob = myLocalMQ_Mob;
            myCFUIC.myLocalMQ_Amount = myLocalMQ_Amount;
            myCFUIC.myLocalMQ_CreateSpeed = myLocalMQ_CreateSpeed;
        }
        if (Target) {
            Vector3 offset = Target.position - miniTarget.position;
            Vector2 newPosition = new Vector2(offset.x, offset.z);
            newPosition *= zoonlevel;
            //myRectTransform.anchoredPosition = newPosition;
            //transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = newPosition;
            GetComponent<RectTransform>().anchoredPosition = newPosition;
        }

    }
}
