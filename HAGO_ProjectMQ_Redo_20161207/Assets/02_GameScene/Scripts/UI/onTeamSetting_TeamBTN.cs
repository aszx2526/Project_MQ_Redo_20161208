using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onTeamSetting_TeamBTN : MonoBehaviour {
    [Header("我的隊伍")]
    public int myTeamID;
    [Header("我的蚊子種類")]
    public int myMQTypeID;
    [Header("蚊子的價位")]
    public int myMQPrice;
    [Header("蚊子的數量")]
    public int myMQAmount;
    [Header("蚊子的最大數量")]
    public int myMaxMQAmount;
    [Header("蚊子的數量_text")]
    public Text myMQAmount_text;
    [Header("隊伍選擇框")]
    public GameObject myTeamSelectBox;

    public Image myImage;
	// Use this for initialization
	void Start () {
        myImage = GetComponent<Image>();
        myPickUpMQImageUpdateFN();
    }
	
	// Update is called once per frame
	void Update () {
        myMQAmount_text.text = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myTeamMQAmount[myTeamID-1].ToString() + "/" + myMaxMQAmount.ToString();
        if (GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myPickUpTeamID == myTeamID) {
            myPickUpMQImageUpdateFN();
            myTeamSelectBox.SetActive(true);
        }
        else {
            myTeamSelectBox.SetActive(false);
        }
        
    }

    public void myPickUpMQImageUpdateFN()
    {
        myMQTypeID = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myPickUpMQID;
        switch (myMQTypeID)
        {
            case 1:
                myImage.sprite = GameObject.Find("MQYouPickImage").GetComponent<onMQYouPickUpImage>().myMQIconList[myMQTypeID ];
                myMQPrice = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myMQBTNList[myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQPrice;
                break;
            case 2:
                myImage.sprite = GameObject.Find("MQYouPickImage").GetComponent<onMQYouPickUpImage>().myMQIconList[myMQTypeID ];
                myMQPrice = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myMQBTNList[myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQPrice;
                break;
            case 3:
                myImage.sprite = GameObject.Find("MQYouPickImage").GetComponent<onMQYouPickUpImage>().myMQIconList[myMQTypeID ];
                myMQPrice = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myMQBTNList[myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQPrice;
                break;
            case 4:
                myImage.sprite = GameObject.Find("MQYouPickImage").GetComponent<onMQYouPickUpImage>().myMQIconList[myMQTypeID ];
                myMQPrice = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myMQBTNList[myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQPrice;
                break;
            case 5:
                myImage.sprite = GameObject.Find("MQYouPickImage").GetComponent<onMQYouPickUpImage>().myMQIconList[myMQTypeID ];
                myMQPrice = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myMQBTNList[myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQPrice;
                break;
            case 6:
                myImage.sprite = GameObject.Find("MQYouPickImage").GetComponent<onMQYouPickUpImage>().myMQIconList[myMQTypeID ];
                myMQPrice = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myMQBTNList[myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQPrice;
                break;
            case 7:
                myImage.sprite = GameObject.Find("MQYouPickImage").GetComponent<onMQYouPickUpImage>().myMQIconList[myMQTypeID ];
                myMQPrice = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myMQBTNList[myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQPrice;
                break;
            case 8:
                myImage.sprite = GameObject.Find("MQYouPickImage").GetComponent<onMQYouPickUpImage>().myMQIconList[myMQTypeID ];
                myMQPrice = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myMQBTNList[myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQPrice;
                break;
            case 9:
                myImage.sprite = GameObject.Find("MQYouPickImage").GetComponent<onMQYouPickUpImage>().myMQIconList[myMQTypeID ];
                myMQPrice = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myMQBTNList[myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQPrice;
                break;
            case 10:
                myImage.sprite = GameObject.Find("MQYouPickImage").GetComponent<onMQYouPickUpImage>().myMQIconList[myMQTypeID ];
                myMQPrice = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myMQBTNList[myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQPrice;
                break;
            case 11:
                myImage.sprite = GameObject.Find("MQYouPickImage").GetComponent<onMQYouPickUpImage>().myMQIconList[myMQTypeID ];
                myMQPrice = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myMQBTNList[myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQPrice;
                break;
            case 12:
                myImage.sprite = GameObject.Find("MQYouPickImage").GetComponent<onMQYouPickUpImage>().myMQIconList[myMQTypeID ];
                myMQPrice = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myMQBTNList[myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQPrice;
                break;
            case 13:
                myImage.sprite = GameObject.Find("MQYouPickImage").GetComponent<onMQYouPickUpImage>().myMQIconList[myMQTypeID ];
                myMQPrice = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myMQBTNList[myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQPrice;
                break;
            case 14:
                myImage.sprite = GameObject.Find("MQYouPickImage").GetComponent<onMQYouPickUpImage>().myMQIconList[myMQTypeID ];
                myMQPrice = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myMQBTNList[myMQTypeID - 1].GetComponent<onBTN_MQList>().myMQPrice;
                break;
            default:
                myImage.sprite = GameObject.Find("MQYouPickImage").GetComponent<onMQYouPickUpImage>().myMQIconList[0];
              //  print("myPickUpMQID is out of range");
                break;
        }
    }
}
