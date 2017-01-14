using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMQ_LoseFlyInLastFrame : MonoBehaviour {
    public bool isLastFram;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void myFlyLastFram() {
        isLastFram = true;
        this.gameObject.SetActive(false);
    }
}
