using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class OnMiniMap : MonoBehaviour {
    public bool isPressAddBTN;
    public int TeamAAmount;
    public int TeamBAmount;
    public int TeamCAmount;
    public int TeamDAmount;
    public int TeamEAmount;

    float myTimer;
    
    public Text Text_onAddBTN;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isPressAddBTN) {
            myTimer += Time.deltaTime;
            if (myTimer >= 0.05) {
                myTimer = 0;
                TeamAAmount++;
            }
        }
        //Text_onAddBTN.text = "數量：" + TeamAAmount.ToString();
       
    }
    public void PointDown()
    {
        isPressAddBTN = true;
    }
    public void PointUp()
    {
        isPressAddBTN = false;
    }
}
