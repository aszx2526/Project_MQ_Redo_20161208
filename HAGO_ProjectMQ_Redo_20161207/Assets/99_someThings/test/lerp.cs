using UnityEngine;
using System.Collections;

public class lerp : MonoBehaviour {
    public GameObject Bpoint;
    public float mymovespeed;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, Bpoint.transform.position, mymovespeed * Time.deltaTime);
    }
}
