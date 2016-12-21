using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onMap_ForAllLevelControl : MonoBehaviour {
    [Header("森林開關星星數量：")]
    public int LevelOpenStarCount_Forest;
    [Header("荒漠開關星星數量：")]
    public int LevelOpenStarCount_Wild;
    [Header("藤蔓開關星星數量：")]
    public int LevelOpenStarCount_Wetland;
    [Header("星星總量計算：")]
    public int myAllStarCount;

    public int myLandMod;
    public bool[] isLevelClear;
    [Header("迷霧")]
    public GameObject[] myCloud;
    public int[] myLevelGetStarCount;
    // Use this for initialization
    void Start () {
        myLevelStarCountFN();
      //  print("start");
    }
    void Awake() {
        myLevelStarCountFN();
       // print("awake");
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            PlayerPrefs.DeleteAll();
        }
        myLandModControl();
        if (Input.GetKeyUp("a")) { myLandMod++; }
     /*   if (myAllStarCount >= LevelOpenStarCount_Wetland) { myLandMod = 4; }
        else {
            if (myAllStarCount >= LevelOpenStarCount_Wild) { myLandMod = 3; }
            else {
                if (myAllStarCount >= LevelOpenStarCount_Forest) { myLandMod = 2; }
                else {
                    myLandMod = 1;
                }
            }
        }*/
    }
    public void myLandModControl() {
        switch (myLandMod) {
            case 1:
                myCloud[myLandMod - 1].GetComponent<onIsland_Cloud>().isNeedToHideCloud = true;
                break;
            case 2:
                myCloud[myLandMod - 1].GetComponent<onIsland_Cloud>().isNeedToHideCloud = true;
                break;
            case 3:
                myCloud[myLandMod - 1].GetComponent<onIsland_Cloud>().isNeedToHideCloud = true;
                break;
            case 4:
                myCloud[myLandMod - 1].GetComponent<onIsland_Cloud>().isNeedToHideCloud = true;
                break;
            default:
                print("hehehaha");
                break;
        }
    }
    public void myLevelStarCountFN() {
        for (int a = 0; a < myLevelGetStarCount.Length; a++) {
            myLevelGetStarCount[a] = PlayerPrefs.GetInt("level_"+(a+1).ToString()+"_starcount");
        }
        
    }
}
