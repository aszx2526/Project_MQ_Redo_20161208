using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onMQYouPickUpImage : MonoBehaviour {
    [Header("蚊子的種類")]
    public int myPickUpMQID;
    [Header("蚊子的icon清單")]
    public Sprite[] myMQIconList;
    [Header("蚊子的數量_text")]
    public Text myMQAmount_text;
    public Image myImage;
    public GameObject[] myTeamBTNList;
    public int myPickUpTeamID;
    public int myMQAmount;
    // Use this for initialization
    void Start () {
        myImage = GetComponent<Image>();

    }
	
	// Update is called once per frame
	void Update () {
        myTeamBTNList = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myTeamBTNList;
        myPickUpTeamID = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myPickUpTeamID;
        myMQAmount = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myTeamMQAmount[myPickUpTeamID - 1];
        myMQAmount_text.text = "出戰兵力：" + myMQAmount.ToString() + "/" + myTeamBTNList[myPickUpTeamID - 1].GetComponent<onTeamSetting_TeamBTN>().myMaxMQAmount.ToString();
        myPickUpMQImageUpdateFN();

    }
    public void myPickUpMQImageUpdateFN() {
        myPickUpMQID = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myPickUpMQID;
        switch (myPickUpMQID) {
            case 1: myImage.sprite = myMQIconList[myPickUpMQID]; break;
            case 2: myImage.sprite = myMQIconList[myPickUpMQID]; break;
            case 3: myImage.sprite = myMQIconList[myPickUpMQID]; break;
            case 4: myImage.sprite = myMQIconList[myPickUpMQID]; break;
            case 5: myImage.sprite = myMQIconList[myPickUpMQID]; break;
            case 6: myImage.sprite = myMQIconList[myPickUpMQID]; break;
            case 7: myImage.sprite = myMQIconList[myPickUpMQID]; break;
            case 8: myImage.sprite = myMQIconList[myPickUpMQID]; break;
            case 9: myImage.sprite = myMQIconList[myPickUpMQID]; break;
            case 10: myImage.sprite = myMQIconList[myPickUpMQID]; break;
            case 11: myImage.sprite = myMQIconList[myPickUpMQID]; break;
            case 12: myImage.sprite = myMQIconList[myPickUpMQID]; break;
            case 13: myImage.sprite = myMQIconList[myPickUpMQID]; break;
            case 14: myImage.sprite = myMQIconList[myPickUpMQID]; break;
            default:
                myImage.sprite = myMQIconList[0];
                break;
        }
    }
}
