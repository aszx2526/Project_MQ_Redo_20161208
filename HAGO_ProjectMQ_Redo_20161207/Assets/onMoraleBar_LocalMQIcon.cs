using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onMoraleBar_LocalMQIcon : MonoBehaviour {
    public Image myMoraleBarLocalMQIcon;
    public Sprite[] myLocalMQSpriteList;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLocalMQ_Mob)
        {
            case 1:
                myMoraleBarLocalMQIcon.sprite = myLocalMQSpriteList[0];
                break;
            case 2:
                myMoraleBarLocalMQIcon.sprite = myLocalMQSpriteList[1];
                break;
            case 3:
                myMoraleBarLocalMQIcon.sprite = myLocalMQSpriteList[2];
                break;
            case 4:
                myMoraleBarLocalMQIcon.sprite = myLocalMQSpriteList[3];
                break;
            case 5:
                myMoraleBarLocalMQIcon.sprite = myLocalMQSpriteList[4];
                break;
            case 6:
                myMoraleBarLocalMQIcon.sprite = myLocalMQSpriteList[5];
                break;
            case 7:
                myMoraleBarLocalMQIcon.sprite = myLocalMQSpriteList[6];
                break;
            case 8:
                myMoraleBarLocalMQIcon.sprite = myLocalMQSpriteList[7];
                break;
            case 9:
                myMoraleBarLocalMQIcon.sprite = myLocalMQSpriteList[8];
                break;
            case 10:
                myMoraleBarLocalMQIcon.sprite = myLocalMQSpriteList[9];
                break;
            case 11:
                myMoraleBarLocalMQIcon.sprite = myLocalMQSpriteList[10];
                break;
            case 12:
                myMoraleBarLocalMQIcon.sprite = myLocalMQSpriteList[11];
                break;
            case 13:
                myMoraleBarLocalMQIcon.sprite = myLocalMQSpriteList[12];
                break;
            case 14:
                myMoraleBarLocalMQIcon.sprite = myLocalMQSpriteList[13];
                break;
        }
    }
}
