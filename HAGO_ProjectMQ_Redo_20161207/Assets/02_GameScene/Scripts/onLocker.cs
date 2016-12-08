using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onLocker : MonoBehaviour {
    public Image[] mylocker;
    Vector3 myrota;
    public float myRotateSpeed;
    public float myFadeinoutTimer;
    bool isBorS;
    bool isCross;
    // Use this for initialization

    /*
    //這行會讓2D物件變成billboard
     myLocker.transform.position = Camera.main.WorldToScreenPoint(theLookAtPointOnMonster[myCameraMod].transform.position);
    */
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart) {
        //以下三行會旋轉
        Vector3 myrota = mylocker[0].gameObject.transform.eulerAngles;
        myrota.z -= Time.deltaTime * myRotateSpeed;
        mylocker[0].gameObject.transform.eulerAngles = myrota;
/*
        Vector3 myrotab = mylocker[2].gameObject.transform.eulerAngles;
        myrotab.z += Time.deltaTime * myRotateSpeed;
        mylocker[2].gameObject.transform.eulerAngles = myrotab;
        */

        myLokcerBSFN();
        //myCrossBSFN();

        //  }
    }
    //下面這個會讓圖片放大縮小
    public void myLokcerBSFN() {
        if (isBorS)
        {
            if (mylocker[0].gameObject.GetComponent<RectTransform>().localScale.x > 2.9) { isBorS = false; }
            else {
                Vector3 a = mylocker[0].gameObject.GetComponent<RectTransform>().localScale;
                a.x += Time.deltaTime * 4f;
                a.y += Time.deltaTime * 4f;
                mylocker[0].gameObject.GetComponent<RectTransform>().localScale = a;
            }

        }
        else {
            if (mylocker[0].gameObject.GetComponent<RectTransform>().localScale.x < 1.2) { isBorS = true; }
            else {
                Vector3 a = mylocker[0].gameObject.GetComponent<RectTransform>().localScale;
                a.x -= Time.deltaTime * 4f;
                a.y -= Time.deltaTime * 4f;
                mylocker[0].gameObject.GetComponent<RectTransform>().localScale = a;
            }
        }
    }
    public void myCrossBSFN()
    {
        if (isCross)
        {
            if (mylocker[2].gameObject.GetComponent<RectTransform>().localScale.x > 2.5) { isCross = false; }
            else {
                Vector3 a = mylocker[2].gameObject.GetComponent<RectTransform>().localScale;
                a.x += Time.deltaTime * 5.5f;
                a.y += Time.deltaTime * 5.5f;
                mylocker[2].gameObject.GetComponent<RectTransform>().localScale = a;
            }

        }
        else {
            if (mylocker[2].gameObject.GetComponent<RectTransform>().localScale.x < 1.7) { isCross = true; }
            else {
                Vector3 a = mylocker[2].gameObject.GetComponent<RectTransform>().localScale;
                a.x -= Time.deltaTime * 5.5f;
                a.y -= Time.deltaTime * 5.5f;
                mylocker[2].gameObject.GetComponent<RectTransform>().localScale = a;
            }
        }
    }
}
