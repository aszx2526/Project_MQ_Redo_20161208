using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onIsland_Cloud : MonoBehaviour {
    public GameObject[] myChildCloudList;
    public bool isNeedToHideCloud;
    int aForfor = 0;
    public float myAaddtime;
    public float myAaddtimer;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isNeedToHideCloud) {
            if (myAaddtimer > myAaddtime) {
                myAaddtimer = 0;
                if (aForfor < myChildCloudList.Length) {
                    myChildCloudList[aForfor].GetComponent<onCloudForHidden>().isTimeToDisappear = true;
                    aForfor++;
                }
                else {isNeedToHideCloud = false;}
            }
            else {myAaddtimer += Time.deltaTime;}
        }
	}
}
