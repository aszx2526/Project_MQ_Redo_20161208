﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onLoseController : MonoBehaviour {
    public int myMod;
    public GameObject myMQFlyIn;
    public GameObject myMQDown;
    public GameObject myMQDownLoop;
    public GameObject myMQLoseTitle;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (myMQFlyIn.GetComponent<onMQ_LoseFlyInLastFrame>().isLastFram) {myMod = 1;}
        if (myMQDown.GetComponent<onGifObject>().mygifmod == 6 && myMod == 1) { myMod = 2; }

        switch (myMod) {
            case 0:
                myMQFlyIn.gameObject.SetActive(true);
                break;
            case 1:
                myMQFlyIn.gameObject.SetActive(false);
                myMQDown.SetActive(true);
                break;
            case 2:
                myMQDown.SetActive(false);
                myMQLoseTitle.SetActive(true);
                myMQDownLoop.SetActive(true);
                break;
        }

	}
}
