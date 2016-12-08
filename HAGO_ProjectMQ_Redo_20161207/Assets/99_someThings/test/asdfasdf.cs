using UnityEngine;
using System.Collections;

public class asdfasdf : MonoBehaviour {
    public GameObject aa;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 a = aa.transform.position;
            a.x += 10;
            aa.transform.position = a;
            //Destroy(aa);
        }
	}
}
