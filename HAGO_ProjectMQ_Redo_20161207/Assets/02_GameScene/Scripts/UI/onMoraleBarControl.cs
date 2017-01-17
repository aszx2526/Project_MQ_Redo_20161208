using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onMoraleBarControl : MonoBehaviour {
    //public 
    public Image myUI_MoraleBar_MQ;
    public Image myUI_MoraleBar_Monster;
    public Image myUI_LocalMQ_Amount;
    public GameObject myUI_LocalMQ_AmountMark;
    public GameObject myUI_MonsterMQ_Mark;
    public Image myUI_MoraleBar_Icon_MQ;
    public Sprite[] myUI_MoraleBar_Icon_MQ_Sprite;
    public Image myUI_MoraleBar_Icon_Monster;
    public Sprite[] myUI_MoraleBar_Icon_Monster_Sprite;
    float myMoraleAddTimer;
    public float monstermorale;
    public float monstermoraleTarget;
    public float myMoralUpdateSpeed;
    public float myLocalMQ_AmountTarget;
    // Use this for initialization
    void Start () {
      /*  myUI_LocalMQ_Amount = transform.GetChild(2).GetComponent<Image>();
        myUI_MoraleBar_MQ = transform.GetChild(3).GetComponent<Image>();
        myUI_MoraleBar_Monster = transform.GetChild(4).GetComponent<Image>();
        myUI_LocalMQ_AmountMark = transform.GetChild(5).gameObject;
        myUI_MonsterMQ_Mark = transform.GetChild(6).gameObject;*/
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart) {
            //控制原生蚊bar標記
            Vector3 myAmountMarkPos = myUI_LocalMQ_AmountMark.GetComponent<RectTransform>().localPosition;
            myAmountMarkPos.x = (-270)+(myUI_LocalMQ_Amount.fillAmount * 580);
            myUI_LocalMQ_AmountMark.GetComponent<RectTransform>().localPosition = myAmountMarkPos;

            //450 460
            //控制怪物bar標記
            Vector3 myMonsterMarkPos = myUI_MonsterMQ_Mark.GetComponent<RectTransform>().localPosition;
            myMonsterMarkPos.x = (-266) + (myUI_MoraleBar_MQ.fillAmount * 562);
            myUI_MonsterMQ_Mark.GetComponent<RectTransform>().localPosition = myMonsterMarkPos;

            if (myUI_MoraleBar_Monster.fillAmount == 0) {
                //怪物死調惹
                //print("怪物死調惹_onMoraleBarControl");
                GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myAttackPartLocker.SetActive(false);
            }
            else if (myUI_MoraleBar_Monster.fillAmount == 1) {
                //怪物銀惹
                print("怪物銀惹_onMoraleBarControl");
                GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart = false;
                GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLevelClear.SetActive(true);
                GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myAttackPartLocker.SetActive(false);
            }
            else {
                GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myAttackPartLocker.SetActive(true);
                if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLocalMQ_Amount == 0) {//如果原生蚊放完了，怪物士氣增加速度提升，本來是1秒調整一次，現在0.1秒調整一次
                    myMoraleAddTimer += Time.deltaTime;
                    if (myMoraleAddTimer >= 0.05f)//0.1秒
                    {
                        myMoraleAddTimer = 0;
                        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale += GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMoraleRestoreValue;
                    }
                }
                else {
                    myMoraleAddTimer += Time.deltaTime;
                    if (myMoraleAddTimer >= 1)//1秒調整
                    {
                        myMoraleAddTimer = 0;
                        if (GameObject.Find("MainCamera").GetComponent<OnCameraForShootMQ>().myMQSkillSettingMenu.MQ04_skill.isSkillWorking) { }
                        else {
                            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale += GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMoraleRestoreValue;
                        }
                    }
                }
                myUI_MoraleBar_MQ.fillAmount = 1 - myUI_MoraleBar_Monster.fillAmount;
            }
            //把士氣值的數值從canvas 那邊幹過來，換算成圖片需要的數值
            monstermorale = GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale;
            if (monstermoraleTarget < monstermorale) {
                if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLocalMQ_Amount == 0) {
                    monstermoraleTarget += Time.deltaTime * myMoralUpdateSpeed*10;
                    myUI_MoraleBar_Monster.fillAmount = monstermoraleTarget / 100;
                }
                else {
                    monstermoraleTarget += Time.deltaTime * myMoralUpdateSpeed;
                    myUI_MoraleBar_Monster.fillAmount = monstermoraleTarget / 100;
                }
                
            }
            else {
                monstermoraleTarget -= Time.deltaTime * myMoralUpdateSpeed;
                myUI_MoraleBar_Monster.fillAmount = monstermoraleTarget / 100;
            }

            //把原生蚊的數值從canvas 那邊幹過來，換算成圖片需要的數值
            if (myLocalMQ_AmountTarget> (float)GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLocalMQ_Amount) {
                myLocalMQ_AmountTarget -= Time.deltaTime * myMoralUpdateSpeed;
                myUI_LocalMQ_Amount.fillAmount = myLocalMQ_AmountTarget / (float)GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLocalMQ_AmountFull;
            }
            //更新士氣值蚊子及怪地的icon
        //    myMonsterMQMoraleBarIconUpdateFN();
        }
    }
    public void myMonsterMQMoraleBarIconUpdateFN() {
        if (myUI_MoraleBar_Monster.fillAmount > 0 && myUI_MoraleBar_Monster.fillAmount < 0.35f) { myUI_MoraleBar_Icon_Monster.sprite = myUI_MoraleBar_Icon_Monster_Sprite[2]; }
        if (myUI_MoraleBar_Monster.fillAmount > 0.35f && myUI_MoraleBar_Monster.fillAmount < 0.70f) { myUI_MoraleBar_Icon_Monster.sprite = myUI_MoraleBar_Icon_Monster_Sprite[0]; }
        if (myUI_MoraleBar_Monster.fillAmount > 0.70f && myUI_MoraleBar_Monster.fillAmount < 1.0f) { myUI_MoraleBar_Icon_Monster.sprite = myUI_MoraleBar_Icon_Monster_Sprite[1]; }

        if (myUI_MoraleBar_Icon_MQ.fillAmount > 0 && myUI_MoraleBar_Icon_MQ.fillAmount < 0.35f) { myUI_MoraleBar_Icon_MQ.sprite = myUI_MoraleBar_Icon_MQ_Sprite[2]; }
        if (myUI_MoraleBar_Icon_MQ.fillAmount > 0.35f && myUI_MoraleBar_Icon_MQ.fillAmount < 0.70f) { myUI_MoraleBar_Icon_MQ.sprite = myUI_MoraleBar_Icon_MQ_Sprite[0]; }
        if (myUI_MoraleBar_Icon_MQ.fillAmount > 0.70f && myUI_MoraleBar_Icon_MQ.fillAmount < 1.0f) { myUI_MoraleBar_Icon_MQ.sprite = myUI_MoraleBar_Icon_MQ_Sprite[1]; }


    }
}
