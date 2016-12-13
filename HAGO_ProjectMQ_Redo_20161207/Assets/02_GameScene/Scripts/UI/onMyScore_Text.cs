using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onMyScore_Text : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "myScore is ：" + GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount_All.ToString();
	}
}
