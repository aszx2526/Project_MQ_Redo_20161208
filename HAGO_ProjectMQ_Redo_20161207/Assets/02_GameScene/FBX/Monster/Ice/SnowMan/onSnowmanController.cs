using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onSnowmanController : MonoBehaviour {
    public GameObject myAsnowman;
    public GameObject myBsnowman;
    public GameObject myBweapon;
    public int myModID;
    // Use this for initialization
    void Start () {
        myModID = 0;
        myAsnowman.SetActive(true);
        myBsnowman.SetActive(false);
        //myBweapon.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        switch (myModID) {
            case 0:
                if (myAsnowman.GetComponent<onSnowManForAniControl>().myHandGetHurtValue >= myAsnowman.GetComponent<onSnowManForAniControl>().myHandGetHurtValue_Full)
                {
                    myBsnowman.SetActive(true);
                    myBsnowman.GetComponent<onSnowManForAniControl>().isHandgood = true;
                    myBsnowman.GetComponent<onSnowManForAniControl>().myHandGetHurtValue = myAsnowman.GetComponent<onSnowManForAniControl>().myHandGetHurtValue;
                    myAsnowman.SetActive(false);
                    myModID = 1;
                }
                break;
            case 1:
                if (myBsnowman.GetComponent<onSnowManForAniControl>().isHandgood == false)
                {
                    myBweapon.SetActive(false);
                }
                break;
        }
	}
}
