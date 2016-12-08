using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMainCameraVer2 : MonoBehaviour {
    public GameObject myLookAtPoint;
    public bool isNeedToFollow;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(myLookAtPoint.transform.position);
	}
   

}
