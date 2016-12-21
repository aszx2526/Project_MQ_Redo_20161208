using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onCloudForHidden : MonoBehaviour {
    public bool isTimeToDisappear;
    public bool isDisappeared;
    [Header("移動方向.右始.瞬轉(1-8)")]
    public int myMoveWayID;
    public float myCloudMoveSpeed;
	// Use this for initialization
	void Start () {
        myCloudMoveSpeed = Random.Range(40, 60);

    }
	
	// Update is called once per frame
	void Update () {
        if (!isDisappeared && isTimeToDisappear) {
            Color a = GetComponent<Image>().color;
            a.a -= Time.deltaTime;
            GetComponent<Image>().color = a;

            Vector3 myPos = gameObject.GetComponent<RectTransform>().localPosition;

            switch (myMoveWayID) {
                case 1://左
                    myPos.x -= Time.deltaTime * myCloudMoveSpeed;
                    gameObject.GetComponent<RectTransform>().localPosition = myPos;
                    break;
                case 2://左上
                    myPos.x -= Time.deltaTime * myCloudMoveSpeed;
                    myPos.y += Time.deltaTime * myCloudMoveSpeed;
                    gameObject.GetComponent<RectTransform>().localPosition = myPos;
                    break;
                case 3://上
                    myPos.y += Time.deltaTime * myCloudMoveSpeed;
                    gameObject.GetComponent<RectTransform>().localPosition = myPos;
                    break;
                case 4://右上
                    myPos.y += Time.deltaTime * myCloudMoveSpeed;
                    myPos.x += Time.deltaTime * myCloudMoveSpeed;
                    gameObject.GetComponent<RectTransform>().localPosition = myPos;
                    break;
                case 5://右
                    myPos.x += Time.deltaTime * myCloudMoveSpeed;
                    gameObject.GetComponent<RectTransform>().localPosition = myPos;
                    break;
                case 6://右下
                    myPos.x += Time.deltaTime * myCloudMoveSpeed;
                    myPos.y -= Time.deltaTime * myCloudMoveSpeed;
                    gameObject.GetComponent<RectTransform>().localPosition = myPos;
                    break;
                case 7://下
                    myPos.y -= Time.deltaTime * myCloudMoveSpeed;
                    gameObject.GetComponent<RectTransform>().localPosition = myPos;
                    break;
                case 8://左下
                    myPos.x -= Time.deltaTime * myCloudMoveSpeed;
                    myPos.y -= Time.deltaTime * myCloudMoveSpeed;
                    gameObject.GetComponent<RectTransform>().localPosition = myPos;
                    break;
            }
            if (a.a <= 0)
            {
                isDisappeared = true;
                gameObject.SetActive(false);
            }
        }
	}
}
