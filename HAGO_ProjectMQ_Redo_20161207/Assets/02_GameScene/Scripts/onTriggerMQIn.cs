using UnityEngine;
using System.Collections;

public class onTriggerMQIn : MonoBehaviour {
    public GameObject myFather;
    public int myTriggerMod;//0=bigeye 1=icebear
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other) {
        if (other.tag == "MQ") {
            switch (myTriggerMod) {
                case 0://bigeye
                    if (myFather.GetComponent<onHitPoint_UpdateHureValue>().isPartBreak)
                    {
                        if (myFather.name == "hitpoint-2" || myFather.name == "hitpoint-3")
                        {
                            other.GetComponent<onMQVer3>().myMoveSpeed = 0;
                            other.GetComponent<onMQVer3>().isAttackTime = true;
                            other.GetComponent<onMQVer3>().isLockNextTarget = false;
                            other.GetComponent<onMQVer3>().isNeedToMoveToNextPoint = false;
                            other.transform.parent = myFather.transform;
                        }
                        else {
                            other.GetComponent<onMQVer3>().isAttackTime = false;
                            other.GetComponent<onMQVer3>().isNeedToMoveToNextPoint = true;
                            other.transform.parent = null;
                        }
                    }
                    else {
                        if (myFather.name == other.GetComponent<onMQVer3>().myTargetPoint.name)
                        {
                            other.GetComponent<onMQVer3>().myMoveSpeed = 0;
                            other.GetComponent<onMQVer3>().isAttackTime = true;
                            other.GetComponent<onMQVer3>().isLockNextTarget = false;
                            other.GetComponent<onMQVer3>().isNeedToMoveToNextPoint = false;
                            other.transform.parent = myFather.transform;
                        }
                        else {
                            other.GetComponent<onMQVer3>().isAttackTime = false;
                            other.GetComponent<onMQVer3>().isNeedToMoveToNextPoint = true;
                            other.transform.parent = null;
                        }
                    }
                    break;
                case 1://icebear
                    if (myFather.GetComponent<onHitPoint_UpdateHureValue>().isPartBreak)
                    {
                        if (myFather.name == "hitpoint-2" || myFather.name == "hitpoint-3")
                        {
                            other.GetComponent<onMQVer3>().myMoveSpeed = 0;
                            other.GetComponent<onMQVer3>().isAttackTime = true;
                            other.GetComponent<onMQVer3>().isLockNextTarget = false;
                            other.GetComponent<onMQVer3>().isNeedToMoveToNextPoint = false;
                            other.transform.parent = myFather.transform;
                        }
                        else {
                            other.GetComponent<onMQVer3>().isAttackTime = false;
                            other.GetComponent<onMQVer3>().isNeedToMoveToNextPoint = true;
                            other.transform.parent = null;
                        }
                    }
                    else {
                        if (myFather.name == other.GetComponent<onMQVer3>().myTargetPoint.name)
                        {
                            other.GetComponent<onMQVer3>().myMoveSpeed = 0;
                            other.GetComponent<onMQVer3>().isAttackTime = true;
                            other.GetComponent<onMQVer3>().isLockNextTarget = false;
                            other.GetComponent<onMQVer3>().isNeedToMoveToNextPoint = false;
                            other.transform.parent = myFather.transform;
                        }
                        else {
                            other.GetComponent<onMQVer3>().isAttackTime = false;
                            other.GetComponent<onMQVer3>().isNeedToMoveToNextPoint = true;
                            other.transform.parent = null;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
    void onTriggerStay(Collider other) {
        if (other.tag == "MQ")
        {
            if (other.GetComponent<onMQVer3>().myTargetPoint.name != myFather.name) {
                other.GetComponent<onMQVer3>().myMoveSpeed = 1;
                other.GetComponent<onMQVer3>().isAttackTime = false;
                other.GetComponent<onMQVer3>().isLockNextTarget = false;
                other.GetComponent<onMQVer3>().isNeedToMoveToNextPoint = true;
                other.transform.parent = null;
            }
        }
    }
}
