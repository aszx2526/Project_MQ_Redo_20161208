using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onTeamSettingManager : MonoBehaviour {
    [Header("選到的隊伍ID")]
    public int myPickUpTeamID;
    [Header("選到的蚊子ID")]
    public int myPickUpMQID;
    [Header("各隊蚊子的種類")]
    public int[] myTeamMQTypeID;
    [Header("各隊蚊子的數量")]
    public int[] myTeamMQAmount;
    [Header("隊伍按鈕清單")]
    public GameObject[] myTeamBTNList;
    [Header("蚊子按鈕清單")]
    public GameObject[] myMQBTNList;
    [Header("玩家有多少錢")]
    public int myCoin;
    [Header("玩家有多少錢_Text")]
    public Text myCoin_text;
    [Header("買蚊子多少錢_Text")]
    public Text myBuyMQPrice_text;
    [Header("賣蚊子有多少錢_Text")]
    public Text mySellMQPrice_text;
    public GameObject myBuyBTN;
    public GameObject myBuyBTNCoinImage;
    public GameObject myBuyBTNHideImage;
    public bool isBuyBTNDown;
    public bool isSellBTNDown;
    public bool isSellBuyBTNCanWorking;
    public GameObject myAddOneUI;
    public GameObject myAddOne_SpawnPoint;
    public float mySellBuyTimer;
    public float mySellBuyTime;
    public float mySellBuyTimeRate;

    public GameObject UI_TeamSetting;

    public int myMQListPageNum;
    public GameObject myMQList;
    public GameObject[] myMQListPagePoint;
    public float myMQListChangeSpeed;

    public int[] myKindOfMQCounter;
    public int myKindOfMQCount;
    // Use this for initialization
    void Start () {
        myPickUpTeamID = 1;
        myMQListPageNum = 0;

        myKindOfMQCounterFN();

    }
	
	// Update is called once per frame
	void Update () {
       
        //更新字串
        myCoin_text.text = myCoin.ToString();
        myBuyMQPrice_text.text = myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQPrice.ToString();
        mySellMQPrice_text.text = ((int)(float)myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQPrice * 0.8f).ToString();

        myTeamMQTypeID[myPickUpTeamID - 1] = myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID;

        myBuySellFN();

        //讓蚊子列表華上滑下
        if (myMQListPageNum == 0) {
            myMQList.transform.position = Vector3.Lerp(myMQList.transform.position, myMQListPagePoint[0].transform.position, Time.deltaTime * myMQListChangeSpeed);
        }
        else {
            myMQList.transform.position = Vector3.Lerp(myMQList.transform.position, myMQListPagePoint[1].transform.position, Time.deltaTime * myMQListChangeSpeed);
        }

        if (myPickUpMQID-1 < 0 || myPickUpTeamID -1< 0|| myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID - 1<0) { }
        else {
            //如果是原生蚊就把買的按鈕遮起來
            if (myMQBTNList[myPickUpMQID - 1].GetComponent<onBTN_MQList>().isLocalMQ) { myBuyBTNHideImage.SetActive(true); }
            else { myBuyBTNHideImage.SetActive(false); }


            if (myMQBTNList[myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQAmount > 0)
            {
                myBuyBTN.transform.GetChild(0).GetComponent<Text>().text = "補充";
                myBuyBTNCoinImage.SetActive(false);
               // myAddMQFromeBagFN();
            }
            else {
                myBuyBTN.transform.GetChild(0).GetComponent<Text>().text = "Buy";
                myBuyBTNCoinImage.SetActive(true);
              //
            }
        }


       
    }
    //變更選擇的隊伍，並將該隊蚊子的種類抓過來
    public void BTN_myTeamAClick() { myPickUpTeamID = 1; myPickUpMQID = myTeamBTNList[0].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID; }
    public void BTN_myTeamBClick() { myPickUpTeamID = 2; myPickUpMQID = myTeamBTNList[1].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID; }
    public void BTN_myTeamCClick() { myPickUpTeamID = 3; myPickUpMQID = myTeamBTNList[2].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID; }
    public void BTN_myTeamDClick() { myPickUpTeamID = 4; myPickUpMQID = myTeamBTNList[3].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID; }
    public void BTN_myTeamEClick() { myPickUpTeamID = 5; myPickUpMQID = myTeamBTNList[4].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID; }

    //變更蚊子的種類
    public void BTN_myMQ_01_Click() { myPutTeamMQBackBagFN(); myPickUpMQID = 1; myCheckISBagHavaMQFN(); }
    public void BTN_myMQ_02_Click() { myPutTeamMQBackBagFN(); myPickUpMQID = 2; myCheckISBagHavaMQFN(); }
    public void BTN_myMQ_03_Click() { myPutTeamMQBackBagFN(); myPickUpMQID = 3; myCheckISBagHavaMQFN(); }
    public void BTN_myMQ_04_Click() { myPutTeamMQBackBagFN(); myPickUpMQID = 4; myCheckISBagHavaMQFN(); }
    public void BTN_myMQ_05_Click() { myPutTeamMQBackBagFN(); myPickUpMQID = 5; myCheckISBagHavaMQFN(); }
    public void BTN_myMQ_06_Click() { myPutTeamMQBackBagFN(); myPickUpMQID = 6; myCheckISBagHavaMQFN(); }
    public void BTN_myMQ_07_Click() { myPutTeamMQBackBagFN(); myPickUpMQID = 7; myCheckISBagHavaMQFN(); }
    public void BTN_myMQ_08_Click() { myPutTeamMQBackBagFN(); myPickUpMQID = 8; myCheckISBagHavaMQFN(); }
    public void BTN_myMQ_09_Click() { myPutTeamMQBackBagFN(); myPickUpMQID = 9; myCheckISBagHavaMQFN(); }
    public void BTN_myMQ_10_Click() { myPutTeamMQBackBagFN(); myPickUpMQID = 10; myCheckISBagHavaMQFN(); }
    public void BTN_myMQ_11_Click() { myPutTeamMQBackBagFN(); myPickUpMQID = 11; myCheckISBagHavaMQFN(); }
    public void BTN_myMQ_12_Click() { myPutTeamMQBackBagFN(); myPickUpMQID = 12; myCheckISBagHavaMQFN(); }
    public void BTN_myMQ_13_Click() { myPutTeamMQBackBagFN(); myPickUpMQID = 13; myCheckISBagHavaMQFN(); }
    public void BTN_myMQ_14_Click() { myPutTeamMQBackBagFN(); myPickUpMQID = 14; myCheckISBagHavaMQFN(); }

    public void myPutTeamMQBackBagFN() {
        if (myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQAmount > 0) {
         //   print("現在本隊的蚊子將被存到倉庫");
            if (myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID == 0){}
            else {
                myMQBTNList[myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQAmount += myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQAmount;
                myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQAmount = 0;
                myTeamMQAmount[myPickUpTeamID - 1] = 0;
            } 
        }
    }
    public void myCheckISBagHavaMQFN() {
        if (myMQBTNList[myPickUpMQID - 1].GetComponent<onBTN_MQList>().myMQAmount > 0) {
          //  print("現在倉庫的蚊子將灌到隊伍");
            if (myMQBTNList[myPickUpMQID - 1].GetComponent<onBTN_MQList>().myMQAmount > myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMaxMQAmount)
            {
                myTeamMQAmount[myPickUpTeamID - 1] = myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMaxMQAmount;
                myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQAmount = myTeamMQAmount[myPickUpTeamID - 1];
                myMQBTNList[myPickUpMQID - 1].GetComponent<onBTN_MQList>().myMQAmount -= myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMaxMQAmount;
            }
            else {
                myTeamMQAmount[myPickUpTeamID - 1] = myMQBTNList[myPickUpMQID - 1].GetComponent<onBTN_MQList>().myMQAmount;
                myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQAmount = myTeamMQAmount[myPickUpTeamID - 1];
                myMQBTNList[myPickUpMQID - 1].GetComponent<onBTN_MQList>().myMQAmount -= myMQBTNList[myPickUpMQID - 1].GetComponent<onBTN_MQList>().myMQAmount;
            }
            
        }
    }
    //買賣蚊子控制函式
    public void myBuySellFN() {
        if (isSellBuyBTNCanWorking)
        {
            if (isBuyBTNDown)
            {
                if (mySellBuyTime < 0.0001) { mySellBuyTime = 0.0001f; }
                else { mySellBuyTime = mySellBuyTime * mySellBuyTimeRate; }
                //如果滿了就不要加了
                if (myTeamMQAmount[myPickUpTeamID - 1] < myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMaxMQAmount)
                {
                    //如果倉庫還有就直接從倉庫抓過來，倉庫沒了才花錢買
                    if (myMQBTNList[myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQAmount > 0)
                    {
                        myTeamMQAmount[myPickUpTeamID - 1]++;
                        myMQBTNList[myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQAmount--;
                        myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQAmount = myTeamMQAmount[myPickUpTeamID - 1];
                        myAddOneUiFN();
                    }
                    else {
                        myTeamMQAmount[myPickUpTeamID - 1]++;
                        myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQAmount = myTeamMQAmount[myPickUpTeamID - 1];
                        myCoin -= myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQPrice;
                        myAddOneUiFN();
                    }
                }
                isSellBuyBTNCanWorking = false;
            }
            else if (isSellBTNDown)
            {
                if (mySellBuyTime < 0.0001) { mySellBuyTime = 0.0001f; }
                else { mySellBuyTime = mySellBuyTime * mySellBuyTimeRate; }
                if (myTeamMQAmount[myPickUpTeamID - 1] > 0)
                {
                    myTeamMQAmount[myPickUpTeamID - 1]--;
                    myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQAmount = myTeamMQAmount[myPickUpTeamID - 1];
                    myCoin += (int)((float)myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMQPrice * 0.8f);//打8折賣回去
                }
                isSellBuyBTNCanWorking = false;
            }
        }
        else {
            if (mySellBuyTimer < mySellBuyTime)
            {
                mySellBuyTimer += Time.deltaTime;
            }
            else {
                isSellBuyBTNCanWorking = true;
                mySellBuyTimer = 0;
            }
        }
    }
    //買賣按鈕偵聽
    public void BTN_SellDown() { if(myPickUpMQID!=0)isSellBTNDown = true; }
    public void BTN_SellUp() { isSellBTNDown = false; mySellBuyTime = 0.5f; }
    public void BTN_BuyDown() { if (myPickUpMQID != 0) isBuyBTNDown = true; }
    public void BTN_BuyUp() { isBuyBTNDown = false; mySellBuyTime = 0.5f; }
    //離開隊伍設定
    public void BTN_TeamSettingExit() { UI_TeamSetting.SetActive(false); }
    //增加蚊子的時候跳出+1
    public void myAddOneUiFN() {
        GameObject UIAddone = Instantiate(myAddOneUI) as GameObject;
        UIAddone.transform.parent = GameObject.Find("Canvas").transform;
        UIAddone.GetComponent<onUI_addOne>().isUpTime = true;
        Vector3 pos = myAddOne_SpawnPoint.GetComponent<RectTransform>().localPosition;
        pos.x = Random.Range(pos.x - 50.0f, pos.x + 50.0f);
        UIAddone.GetComponent<RectTransform>().localPosition = pos;
    }
    public void myKindOfMQCounterFN() {
        for (int a = 0; a < myMQBTNList.Length; a++)
        {
            if (myMQBTNList[a].GetComponent<onBTN_MQList>().isLocalMQ)
            {
                if (myMQBTNList[a].GetComponent<onBTN_MQList>().myMQAmount > 0)
                {
                    myKindOfMQCounter[a] = 1;
                }
            }
            else {
                myKindOfMQCounter[a] = 1;
            }
        }
        for (int b = 0; b < myKindOfMQCounter.Length; b++)
        {
            myKindOfMQCount += myKindOfMQCounter[b];
        }
    }
}
