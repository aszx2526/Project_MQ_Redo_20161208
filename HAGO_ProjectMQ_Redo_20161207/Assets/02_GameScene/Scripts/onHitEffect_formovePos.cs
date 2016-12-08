using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHitEffect_formovePos : MonoBehaviour {
    public Vector3 myNewPos;

	// Use this for initialization
	void Start () {
        //myNewPos = transform.parent
        Camera camera = GameObject.Find("MainCamera").GetComponent<Camera>();
        myNewPos = camera.ScreenToWorldPoint(new Vector3(100, 100, camera.nearClipPlane));
        transform.parent = null;
        transform.position = myNewPos;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
