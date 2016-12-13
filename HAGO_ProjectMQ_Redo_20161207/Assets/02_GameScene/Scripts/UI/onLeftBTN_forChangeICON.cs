using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onLeftBTN_forChangeICON : MonoBehaviour {
    public Image[] myMQIconList;
    public Image[] myMQIconBGList;
    public Image[] myMQSkillIconList;
    public Image[] myMQSkillIconBGList;

    public Sprite[] myMQIcon_sprite;
    public Sprite[] myMQIconBG_sprite;
    public Sprite[] myMQSkillIcon_sprite;
    public Sprite[] myMQSkillIconBG_sprite;
    public OnCameraForShootMQ myOCFSMQ;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        myIconUpdate();
    }
    public void myIconUpdate() {
        switch (myOCFSMQ.myTeamAMQTypeID)
        {
            case 1:
                myMQIconList[0].sprite = myMQIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQIconBGList[0].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconList[0].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconBGList[0].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                break;
            case 2:
                myMQIconList[0].sprite = myMQIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQIconBGList[0].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconList[0].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconBGList[0].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                break;
            case 3:
                myMQIconList[0].sprite = myMQIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQIconBGList[0].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconList[0].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconBGList[0].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                break;
            case 4:
                myMQIconList[0].sprite = myMQIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQIconBGList[0].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconList[0].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconBGList[0].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                break;
            case 5:
                myMQIconList[0].sprite = myMQIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQIconBGList[0].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconList[0].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconBGList[0].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                break;
            case 6:
                myMQIconList[0].sprite = myMQIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQIconBGList[0].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconList[0].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconBGList[0].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                break;
            case 7:
                myMQIconList[0].sprite = myMQIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQIconBGList[0].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconList[0].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconBGList[0].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                break;
            case 8:
                myMQIconList[0].sprite = myMQIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQIconBGList[0].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconList[0].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconBGList[0].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                break;
            case 9:
                myMQIconList[0].sprite = myMQIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQIconBGList[0].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconList[0].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconBGList[0].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                break;
            case 10:
                myMQIconList[0].sprite = myMQIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQIconBGList[0].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconList[0].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconBGList[0].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                break;
            case 11:
                myMQIconList[0].sprite = myMQIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQIconBGList[0].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconList[0].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconBGList[0].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                break;
            case 12:
                myMQIconList[0].sprite = myMQIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQIconBGList[0].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconList[0].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconBGList[0].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                break;
            case 13:
                myMQIconList[0].sprite = myMQIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQIconBGList[0].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconList[0].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconBGList[0].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                break;
            case 14:
                myMQIconList[0].sprite = myMQIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQIconBGList[0].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconList[0].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamAMQTypeID];
                myMQSkillIconBGList[0].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamAMQTypeID];
                break;
        }
        switch (myOCFSMQ.myTeamBMQTypeID)
        {
            case 1:
                myMQIconList[1].sprite = myMQIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQIconBGList[1].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconList[1].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconBGList[1].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                break;
            case 2:
                myMQIconList[1].sprite = myMQIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQIconBGList[1].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconList[1].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconBGList[1].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                break;
            case 3:
                myMQIconList[1].sprite = myMQIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQIconBGList[1].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconList[1].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconBGList[1].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                break;
            case 4:
                myMQIconList[1].sprite = myMQIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQIconBGList[1].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconList[1].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconBGList[1].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                break;
            case 5:
                myMQIconList[1].sprite = myMQIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQIconBGList[1].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconList[1].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconBGList[1].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                break;
            case 6:
                myMQIconList[1].sprite = myMQIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQIconBGList[1].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconList[1].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconBGList[1].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                break;
            case 7:
                myMQIconList[1].sprite = myMQIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQIconBGList[1].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconList[1].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconBGList[1].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                break;
            case 8:
                myMQIconList[1].sprite = myMQIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQIconBGList[1].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconList[1].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconBGList[1].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                break;
            case 9:
                myMQIconList[1].sprite = myMQIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQIconBGList[1].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconList[1].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconBGList[1].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                break;
            case 10:
                myMQIconList[1].sprite = myMQIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQIconBGList[1].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconList[1].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconBGList[1].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                break;
            case 11:
                myMQIconList[1].sprite = myMQIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQIconBGList[1].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconList[1].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconBGList[1].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                break;
            case 12:
                myMQIconList[1].sprite = myMQIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQIconBGList[1].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconList[1].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconBGList[1].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                break;
            case 13:
                myMQIconList[1].sprite = myMQIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQIconBGList[1].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconList[1].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconBGList[1].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                break;
            case 14:
                myMQIconList[1].sprite = myMQIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQIconBGList[1].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconList[1].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamBMQTypeID];
                myMQSkillIconBGList[1].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamBMQTypeID];
                break;
        }
        switch (myOCFSMQ.myTeamCMQTypeID)
        {
            case 1:
                myMQIconList[2].sprite = myMQIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQIconBGList[2].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconList[2].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconBGList[2].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                break;
            case 2:
                myMQIconList[2].sprite = myMQIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQIconBGList[2].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconList[2].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconBGList[2].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                break;
            case 3:
                myMQIconList[2].sprite = myMQIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQIconBGList[2].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconList[2].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconBGList[2].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                break;
            case 4:
                myMQIconList[2].sprite = myMQIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQIconBGList[2].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconList[2].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconBGList[2].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                break;
            case 5:
                myMQIconList[2].sprite = myMQIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQIconBGList[2].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconList[2].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconBGList[2].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                break;
            case 6:
                myMQIconList[2].sprite = myMQIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQIconBGList[2].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconList[2].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconBGList[2].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                break;
            case 7:
                myMQIconList[2].sprite = myMQIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQIconBGList[2].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconList[2].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconBGList[2].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                break;
            case 8:
                myMQIconList[2].sprite = myMQIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQIconBGList[2].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconList[2].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconBGList[2].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                break;
            case 9:
                myMQIconList[2].sprite = myMQIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQIconBGList[2].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconList[2].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconBGList[2].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                break;
            case 10:
                myMQIconList[2].sprite = myMQIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQIconBGList[2].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconList[2].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconBGList[2].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                break;
            case 11:
                myMQIconList[2].sprite = myMQIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQIconBGList[2].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconList[2].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconBGList[2].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                break;
            case 12:
                myMQIconList[2].sprite = myMQIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQIconBGList[2].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconList[2].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconBGList[2].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                break;
            case 13:
                myMQIconList[2].sprite = myMQIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQIconBGList[2].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconList[2].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconBGList[2].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                break;
            case 14:
                myMQIconList[2].sprite = myMQIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQIconBGList[2].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconList[2].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamCMQTypeID];
                myMQSkillIconBGList[2].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamCMQTypeID];
                break;
        }
        switch (myOCFSMQ.myTeamDMQTypeID)
        {
            case 1:
                myMQIconList[3].sprite = myMQIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQIconBGList[3].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconList[3].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconBGList[3].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                break;
            case 2:
                myMQIconList[3].sprite = myMQIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQIconBGList[3].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconList[3].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconBGList[3].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                break;
            case 3:
                myMQIconList[3].sprite = myMQIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQIconBGList[3].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconList[3].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconBGList[3].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                break;
            case 4:
                myMQIconList[3].sprite = myMQIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQIconBGList[3].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconList[3].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconBGList[3].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                break;
            case 5:
                myMQIconList[3].sprite = myMQIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQIconBGList[3].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconList[3].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconBGList[3].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                break;
            case 6:
                myMQIconList[3].sprite = myMQIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQIconBGList[3].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconList[3].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconBGList[3].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                break;
            case 7:
                myMQIconList[3].sprite = myMQIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQIconBGList[3].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconList[3].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconBGList[3].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                break;
            case 8:
                myMQIconList[3].sprite = myMQIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQIconBGList[3].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconList[3].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconBGList[3].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                break;
            case 9:
                myMQIconList[3].sprite = myMQIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQIconBGList[3].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconList[3].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconBGList[3].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                break;
            case 10:
                myMQIconList[3].sprite = myMQIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQIconBGList[3].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconList[3].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconBGList[3].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                break;
            case 11:
                myMQIconList[3].sprite = myMQIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQIconBGList[3].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconList[3].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconBGList[3].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                break;
            case 12:
                myMQIconList[3].sprite = myMQIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQIconBGList[3].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconList[3].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconBGList[3].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                break;
            case 13:
                myMQIconList[3].sprite = myMQIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQIconBGList[3].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconList[3].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconBGList[3].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                break;
            case 14:
                myMQIconList[3].sprite = myMQIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQIconBGList[3].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconList[3].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamDMQTypeID];
                myMQSkillIconBGList[3].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamDMQTypeID];
                break;
        }
        switch (myOCFSMQ.myTeamEMQTypeID)
        {
            case 1:
                myMQIconList[4].sprite = myMQIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQIconBGList[4].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconList[4].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconBGList[4].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                break;
            case 2:
                myMQIconList[4].sprite = myMQIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQIconBGList[4].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconList[4].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconBGList[4].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                break;
            case 3:
                myMQIconList[4].sprite = myMQIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQIconBGList[4].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconList[4].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconBGList[4].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                break;
            case 4:
                myMQIconList[4].sprite = myMQIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQIconBGList[4].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconList[4].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconBGList[4].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                break;
            case 5:
                myMQIconList[4].sprite = myMQIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQIconBGList[4].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconList[4].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconBGList[4].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                break;
            case 6:
                myMQIconList[4].sprite = myMQIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQIconBGList[4].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconList[4].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconBGList[4].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                break;
            case 7:
                myMQIconList[4].sprite = myMQIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQIconBGList[4].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconList[4].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconBGList[4].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                break;
            case 8:
                myMQIconList[4].sprite = myMQIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQIconBGList[4].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconList[4].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconBGList[4].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                break;
            case 9:
                myMQIconList[4].sprite = myMQIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQIconBGList[4].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconList[4].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconBGList[4].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                break;
            case 10:
                myMQIconList[4].sprite = myMQIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQIconBGList[4].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconList[4].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconBGList[4].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                break;
            case 11:
                myMQIconList[4].sprite = myMQIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQIconBGList[4].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconList[4].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconBGList[4].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                break;
            case 12:
                myMQIconList[4].sprite = myMQIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQIconBGList[4].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconList[4].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconBGList[4].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                break;
            case 13:
                myMQIconList[4].sprite = myMQIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQIconBGList[4].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconList[4].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconBGList[4].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                break;
            case 14:
                myMQIconList[4].sprite = myMQIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQIconBGList[4].sprite = myMQIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconList[4].sprite = myMQSkillIcon_sprite[myOCFSMQ.myTeamEMQTypeID];
                myMQSkillIconBGList[4].sprite = myMQSkillIconBG_sprite[myOCFSMQ.myTeamEMQTypeID];
                break;
        }
    }
}
