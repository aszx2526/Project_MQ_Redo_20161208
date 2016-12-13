using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_onSkillBoxUP : MonoBehaviour {
    public GameObject mySkillBTN;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = mySkillBTN.transform.position;
	}
}
