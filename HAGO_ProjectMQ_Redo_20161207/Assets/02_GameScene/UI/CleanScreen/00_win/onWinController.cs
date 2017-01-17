using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onWinController : MonoBehaviour {
    public int myMod;
    public GameObject myMQFlyIn;
    //public GameObject myMQDown;
    public GameObject myMQWinLoop;
    public GameObject myMQWinTitle;
    float myChangeTimer;
    float myChangeTime;
    // Use this for initialization
    void Start()
    {
        myChangeTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (myMQFlyIn.GetComponent<onMQ_WinFlyInLastFrame>().isLastFram) { myMod = 1; }
     //   if (myMQDown.GetComponent<onGifObject>().mygifmod == 6 && myMod == 1) { myMod = 2; }

        switch (myMod)
        {
            case 0:
                myMQFlyIn.gameObject.SetActive(true);
                break;
            case 1:
                myMQFlyIn.gameObject.SetActive(false);
                myMQWinTitle.SetActive(true);
                myMQWinLoop.SetActive(true);
                break;
        }
        if (myMod == 1) {
            if (myChangeTimer >= myChangeTime) {
                if (GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().theLookAtPointOnMonster[0].GetComponent<onHitPoint_UpdateHureValue>().myBigFather.GetComponent<onMonsterVer3>().isBoss)
                {
                    GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLevelClear.SetActive(true);
                }
                else {
                    myChangeTimer = 0;
                    GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMainUI.SetActive(true);
                    GameObject.Find("MoraleBar").GetComponent<onMoraleBarControl>().myUI_MoraleBar_Monster.fillAmount = 0.5f;
                    GameObject.Find("FightSceneManager").GetComponent<onFightSceneManager>().myRandomMod = 5;
                    Destroy(gameObject);
                }
            }
            else {
                myChangeTimer += Time.deltaTime;
            }
        }

    }
}
