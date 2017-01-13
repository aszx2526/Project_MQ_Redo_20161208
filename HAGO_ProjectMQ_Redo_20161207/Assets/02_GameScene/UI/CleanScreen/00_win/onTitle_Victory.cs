using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTitle_Victory : MonoBehaviour {
    public GameObject myShowPoint;
    public float myMoveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, myShowPoint.transform.position, Time.deltaTime * myMoveSpeed);
	}
}
