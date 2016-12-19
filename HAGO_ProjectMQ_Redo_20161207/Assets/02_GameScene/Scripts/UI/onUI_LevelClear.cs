using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onUI_LevelClear : MonoBehaviour {
    [Header("全星積分")]
    public int myScoreGetAllStar;
    [Header("我的積分")]
    public int myScore;
    [Header("我的coco")]
    public int myCoin;
    public Text myScore_Text;
    public Text myCoin_Text;
    public float myCountScore;
    public Image myStar_Image;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        myScore = GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myScoreCount_All;
        myCountScore = (float)myScore / (float)myScoreGetAllStar;
        myStar_Image.fillAmount = myCountScore;
        myScore_Text.text = "得分：" + myScore.ToString();
        if (myCountScore >= 1)//3星
        {
            float a;
            a = (float)myScore * 2;
            myCoin_Text.text = "$$：" + ((int)a).ToString();
        }
        else if (myCountScore <= 1 && myCountScore >= 0.6)//2星
        {
            float a;
            a = (float)myScore * 1.25f;
            myCoin_Text.text = "$$：" + ((int)a).ToString();
        }
        else if (myCountScore <= 0.6 && myCountScore >= 0.25)//1星
        {
            float a;
            a = (float)myScore * 1;
            myCoin_Text.text = "$$：" + ((int)a).ToString();
        }
        else if (myCountScore <= 0.25)//0星
        {
            float a;
            a = (float)myScore * 1;
            myCoin_Text.text = "$$：" + ((int)a).ToString();
        }
    }
    public void BTN_BackToBigMap() {
        if (myCountScore >= 1)//3星
        {
            PlayerPrefs.SetInt("level_" + GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLevelID.ToString() + "_starcount",3);
        }
        else if (myCountScore <= 1 && myCountScore >= 0.6)//2星
        {
            PlayerPrefs.SetInt("level_" + GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLevelID.ToString() + "_starcount", 2);
        }
        else if (myCountScore <= 0.6 && myCountScore >= 0.25)//1星
        {
            PlayerPrefs.SetInt("level_" + GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLevelID.ToString() + "_starcount", 1);
        }
        else if (myCountScore <= 0.25)//0星
        {

        }
        PlayerPrefs.SetInt("level_" + GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myLevelID.ToString() + "_Bossbekill", 1);
        Application.LoadLevel("MainScene");
    }
}
