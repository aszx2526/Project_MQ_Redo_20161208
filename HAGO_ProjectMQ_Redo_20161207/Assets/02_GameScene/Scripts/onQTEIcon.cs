using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onQTEIcon : MonoBehaviour {
    [Header("QTE icon模式,0=點擊後消失,1=連打,2=點擊後消失(有倒數)")]
    public int myMod;
    public GameObject myFather;
    public GameObject my_text;
    public float myTimer;
   // Use this for initialization
    void Start () {
        switch (myMod)
        {
            case 0:
                my_text.GetComponent<Text>().text = "點我";
                break;
            case 1:
                my_text.GetComponent<Text>().text = "瘋狂點我";
                //myFather.GetComponent<onIceBearForAniControll>().myQTE_B_Count++;
                break;
            case 2:
                break;
            default:
                print("my qte icon mod out of range");
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        switch (myFather.name)
        {
            case "Bear":
                if (myFather.GetComponent<onIceBearForAniControll>().isShowQTEUI == false) { Destroy(this.gameObject); }
                switch (myMod)
                {
                    case 0:
                        break;
                    case 1:
                        //myFather.GetComponent<onIceBearForAniControll>().myQTE_B_Count++;
                        break;
                    case 2:
                        if (myTimer < 0){Destroy(this.gameObject);}
                        else {
                            myTimer -= Time.deltaTime;
                            int a = (int)myTimer;
                            my_text.GetComponent<Text>().text = a.ToString();
                        }
                        break;
                    default:
                        print("my qte icon mod out of range");
                        break;
                }
                break;
            default:
                print("怪物 " + myFather.name + " 的QTE Icon沒有寫唷！");
                break;
        }

        
	}
    public void btn_qtebeClick() {
        switch (myFather.name) {
            case "Bear":
                //myFather.GetComponent<onIceBearForAniControll>()
                switch (myMod)
                {
                    case 0:
                        myFather.GetComponent<onIceBearForAniControll>().myQTE_A_Count++;
                        Destroy(this.gameObject);
                        break;
                    case 1:
                        myFather.GetComponent<onIceBearForAniControll>().myQTE_B_Count++;
                        break;
                    case 2:
                        print("2 click");
                        myFather.GetComponent<onIceBearForAniControll>().myQTE_C_Count++;
                        Destroy(this.gameObject);
                        break;
                    default:
                        
                        print("my qte icon mod out of range");

                        break;
                }
                break;
            default:
                print("怪物 "+myFather.name+" 的QTE Icon沒有寫唷！");
                break;
        }
    }
}
