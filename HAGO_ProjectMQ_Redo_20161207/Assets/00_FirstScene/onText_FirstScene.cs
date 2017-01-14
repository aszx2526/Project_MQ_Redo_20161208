using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onText_FirstScene : MonoBehaviour {
    public GameObject myText;
    public float myTargetYValue;
    public float myUpSpeed;
    public float myFadeOutSpeed;
    public int myLoadSceneID;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 pos = myText.GetComponent<RectTransform>().localPosition;
        pos.y += Time.deltaTime * myUpSpeed;
        myText.GetComponent<RectTransform>().localPosition = pos;

        if (pos.y > myTargetYValue) {
            Color a = myText.GetComponent<Text>().color;
            a.a -= Time.deltaTime*myFadeOutSpeed;
            myText.GetComponent<Text>().color = a;
            if (a.a <= 0) {
                print("載入教學場景");
                PlayerPrefs.SetString("isFirstTimePlay", "yes");
                Application.LoadLevel(myLoadSceneID);
            }
        }

    }
}
