using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onUI_EventClear : MonoBehaviour {
    public GameObject myLocalMQGet;
    public GameObject myScore_eventGet;
    public GameObject myScore_total;
    public GameObject myMainMenu;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        myLocalMQGet.GetComponent<Text>().text = "拯救原生蚊："+ GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLocalMQ_Amount.ToString()+ "隻";
        myScore_eventGet.GetComponent<Text>().text = "本回得分：" + GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount.ToString();
        int a = GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount + GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount_All;
        myScore_total.GetComponent<Text>().text = "累計得分：" +a.ToString();
    }
    public void BTN_BackToMapFN() {
        //原生蚊還沒有存起來
        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount_All += GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount;
        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount = 0;
        GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart = false;
        GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().myMonsterList[GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().myPickUpNum - 1].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("CameraVer2_DTG").GetComponent<onCamera_dtg>().myPickUpNum = 0;
        myMainMenu.SetActive(true);
        GameObject.Find("btn_battle").transform.position = GameObject.Find("btn_battle").GetComponent<onBTN_Battle>().myBasicPos.transform.position;
        gameObject.SetActive(false);
    }
}
