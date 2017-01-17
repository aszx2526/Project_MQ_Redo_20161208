using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onLeftBTNForHideBTN : MonoBehaviour {
    public GameObject[] myPutMQBTNList;
    public int myTeamBTNCount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        myTeamBTNCount = GameObject.Find("TeamSettingManager").GetComponent<onTeamSettingManager>().myKindOfMQCount;
        switch (myTeamBTNCount) {
            case 1:
                myPutMQBTNList[0].gameObject.SetActive(true);
                myPutMQBTNList[1].gameObject.SetActive(false);
                myPutMQBTNList[2].gameObject.SetActive(false);
                myPutMQBTNList[3].gameObject.SetActive(false);
                myPutMQBTNList[4].gameObject.SetActive(false);
                break;
            case 2:
                myPutMQBTNList[0].gameObject.SetActive(true);
                myPutMQBTNList[1].gameObject.SetActive(true);
                myPutMQBTNList[2].gameObject.SetActive(false);
                myPutMQBTNList[3].gameObject.SetActive(false);
                myPutMQBTNList[4].gameObject.SetActive(false);
                break;
            case 3:
                myPutMQBTNList[0].gameObject.SetActive(true);
                myPutMQBTNList[1].gameObject.SetActive(true);
                myPutMQBTNList[2].gameObject.SetActive(true);
                myPutMQBTNList[3].gameObject.SetActive(false);
                myPutMQBTNList[4].gameObject.SetActive(false);
                break;
            case 4:
                myPutMQBTNList[0].gameObject.SetActive(true);
                myPutMQBTNList[1].gameObject.SetActive(true);
                myPutMQBTNList[2].gameObject.SetActive(true);
                myPutMQBTNList[3].gameObject.SetActive(true);
                myPutMQBTNList[4].gameObject.SetActive(false);
                break;
            case 5:
                myPutMQBTNList[0].gameObject.SetActive(true);
                myPutMQBTNList[1].gameObject.SetActive(true);
                myPutMQBTNList[2].gameObject.SetActive(true);
                myPutMQBTNList[3].gameObject.SetActive(true);
                myPutMQBTNList[4].gameObject.SetActive(true);
                break;
        }
	}
}
