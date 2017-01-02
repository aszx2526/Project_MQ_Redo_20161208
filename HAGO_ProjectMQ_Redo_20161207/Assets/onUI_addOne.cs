using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onUI_addOne : MonoBehaviour {
    public GameObject me;
    public GameObject myChild;
    public float myUpSpeed;
    public float myFadeOutSpeed;
    public bool isUpTime;
    public float myYToFadeOut;
	// Use this for initialization
	void Start () {
        me = gameObject;
        myChild = me.transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (isUpTime) {
            Vector3 mypos = me.GetComponent<RectTransform>().localPosition;
            if (mypos.y > myYToFadeOut) {
                mypos.y += Time.deltaTime * myUpSpeed;
                me.GetComponent<RectTransform>().localPosition = mypos;
                Color a = me.GetComponent<Image>().color;
                if (a.a <= 0) {
                    Destroy(me);
                }
                else {
                    a.a -= Time.deltaTime * myFadeOutSpeed;
                    me.GetComponent<Image>().color = a;
                    myChild.GetComponent<Image>().color = me.GetComponent<Image>().color;
                }
            }
            else {
                mypos.y += Time.deltaTime * myUpSpeed;
                me.GetComponent<RectTransform>().localPosition = mypos;
            }
        }
	}
}
