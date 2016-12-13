using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onSkillBTN_ForShowHideControll : MonoBehaviour {
    public GameObject myPoint_Show;
    public GameObject myPoint_Hide;
    public GameObject mySkillBTN;
    public float mySkillBTNMoveSpeed;
    public bool isShowTime;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isShowTime) {
            mySkillBTN.transform.position = Vector3.Lerp(mySkillBTN.transform.position, myPoint_Show.transform.position, Time.deltaTime * mySkillBTNMoveSpeed);
        }
        else {
            mySkillBTN.transform.position = Vector3.Lerp(mySkillBTN.transform.position, myPoint_Hide.transform.position, Time.deltaTime * mySkillBTNMoveSpeed);
        }
        	
	}
}
