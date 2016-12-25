using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onBTN_MQList : MonoBehaviour {
    [Header("是否為原生蚊")]
    public bool isLocalMQ;
    [Header("蚊子的種類")]
    public int myMQTypeID;
    [Header("蚊子的數量")]
    public int myMQAmount;
    [Header("蚊子的價位")]
    public int myMQPrice;
    [Header("蚊子是否被設定了")]
    public bool isMQBePickUp;
    [Header("蚊子被選遮罩")]
    public GameObject myHideImage;
    [Header("庫存數量_text")]
    public GameObject myBag_text;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isMQBePickUp) { myHideImage.SetActive(true); }
        else { myHideImage.SetActive(false); }
        myCheckFN_for_isThisMQBePickUp();
        myBag_text.GetComponent<Text>().text = myMQAmount.ToString();
    }
    public void myCheckFN_for_isThisMQBePickUp() {
        for (int a = 0; a < GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myTeamBTNList.Length; a++) {
            if (myMQTypeID == GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myTeamBTNList[0].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID) { isMQBePickUp = true; }
            else if (myMQTypeID == GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myTeamBTNList[1].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID) { isMQBePickUp = true; }
            else if (myMQTypeID == GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myTeamBTNList[2].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID) { isMQBePickUp = true; }
            else if (myMQTypeID == GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myTeamBTNList[3].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID) { isMQBePickUp = true; }
            else if (myMQTypeID == GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myTeamBTNList[4].GetComponent<onTeamSetting_TeamBTN>().myMQTypeID) { isMQBePickUp = true; }
            else { isMQBePickUp = false; }
        }
        
    }
}
