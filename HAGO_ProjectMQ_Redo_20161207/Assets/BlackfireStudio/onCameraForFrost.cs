using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCameraForFrost : MonoBehaviour {
    public float aa;
    public float aaTarget;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(aa - aaTarget) < 0.01) { }
        else {
            if (aa < aaTarget) { aa += Time.deltaTime * speed; }
            else if (aa > aaTarget) { aa -= Time.deltaTime * speed; }
        }
    }
}