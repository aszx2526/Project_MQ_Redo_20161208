using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHitPoint_UpdateHureValue : MonoBehaviour {
    public GameObject myFather;
    public GameObject myBigFather;
    public float myHurtValueCount;
    public bool isPartBreak;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (myFather.name) {
            case "Bigeye_":
                switch (gameObject.name) {
                    case "hitpoint-1":
                        myHurtValueCount = myFather.GetComponent<onBigeyeForAniControllVer2>().myBigeyeGetHurtValue;
                        if (myFather.GetComponent<onBigeyeForAniControllVer2>().myBigeyeGetHurtValue > myFather.GetComponent<onBigeyeForAniControllVer2>().myBigeyeGetHurtValue_Full){isPartBreak = true;}
                        else {isPartBreak = false;}
                        break;
                    case "hitpoint-2":
                        break;
                    case "hitpoint-3":
                        break;
                    case "hitpoint-4":
                        myHurtValueCount = myFather.GetComponent<onBigeyeForAniControllVer2>().myWingGetHurtValue;
                        if (myFather.GetComponent<onBigeyeForAniControllVer2>().myWingGetHurtValue > myFather.GetComponent<onBigeyeForAniControllVer2>().myWingGetHurtValue_Full) { isPartBreak = true; }
                        else { isPartBreak = false; }
                        break;
                    case "hitpoint-5":
                        myHurtValueCount = myFather.GetComponent<onBigeyeForAniControllVer2>().myWingGetHurtValue;
                        if (myFather.GetComponent<onBigeyeForAniControllVer2>().myWingGetHurtValue > myFather.GetComponent<onBigeyeForAniControllVer2>().myWingGetHurtValue_Full) { isPartBreak = true; }
                        else { isPartBreak = false; }
                        break;
                    default:
                        break;
                }
                break;
            case "Bear":
                switch (gameObject.name)
                {
                    case "hitpoint-1":
                        myHurtValueCount = myFather.GetComponent<onIceBearForAniControll>().myHeadGetHurtValue;
                        if (myFather.GetComponent<onIceBearForAniControll>().myHeadGetHurtValue > myFather.GetComponent<onIceBearForAniControll>().myHeadGetHurtValue_Full) { isPartBreak = true; }
                        else { isPartBreak = false; }
                        break;
                    case "hitpoint-2":
                        myHurtValueCount = myFather.GetComponent<onIceBearForAniControll>().myMouthGetHurtValue;
                        if (myFather.GetComponent<onIceBearForAniControll>().myMouthGetHurtValue > myFather.GetComponent<onIceBearForAniControll>().myMouthGetHurtValue_Full) { isPartBreak = true; }
                        else { isPartBreak = false; }
                        break;
                    case "hitpoint-3":
                        break;
                    case "hitpoint-4":
                        myHurtValueCount = myFather.GetComponent<onIceBearForAniControll>().myLegGetHurtValue;
                        if (myFather.GetComponent<onIceBearForAniControll>().myLegGetHurtValue > myFather.GetComponent<onIceBearForAniControll>().myLegGetHurtValue_Full) { isPartBreak = true; }
                        else { isPartBreak = false; }
                        break;
                    case "hitpoint-5":
                        myHurtValueCount = myFather.GetComponent<onIceBearForAniControll>().myLegGetHurtValue;
                        if (myFather.GetComponent<onIceBearForAniControll>().myLegGetHurtValue > myFather.GetComponent<onIceBearForAniControll>().myLegGetHurtValue_Full) { isPartBreak = true; }
                        else { isPartBreak = false; }
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
	}
}
