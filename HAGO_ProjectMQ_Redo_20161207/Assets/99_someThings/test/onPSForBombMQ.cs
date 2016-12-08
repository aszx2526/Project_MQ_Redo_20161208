using UnityEngine;
using System.Collections;

public class onPSForBombMQ : MonoBehaviour {
    public GameObject theFuse;
    public Vector3 mydis;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = theFuse.transform.position + mydis;
	}
}
