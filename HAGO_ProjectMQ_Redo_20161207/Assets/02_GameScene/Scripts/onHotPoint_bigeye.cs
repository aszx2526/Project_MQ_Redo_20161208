using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHotPoint_bigeye : MonoBehaviour {
    public GameObject myfather;
    public GameObject[] myHitPoint;
    public Vector3[] myHitpointBasicPos;
    public bool isSavePos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // transform.position = myMonster.transform.position;
        if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart) {
            if (!isSavePos) { mySavePos(); }

            if (transform.parent.gameObject.transform.GetChild(0).GetComponent<onBigeyeForAniControllVer2>().isWinggood)
            {
                for (int a = 0; a < myHitPoint.Length; a++)
                {
                    myHitPoint[a].transform.position = myHitpointBasicPos[a];
                }
            }
            else {
                for (int a = 0; a < myHitPoint.Length; a++)
                {
                    Vector3 sudden = myHitpointBasicPos[a];
                    switch (a)
                    {
                        case 0:
                            sudden.y = myHitpointBasicPos[a].y - 2.1f;
                            break;
                        case 1:
                            sudden.y = myHitpointBasicPos[a].y - 2.1f;
                            break;
                        case 2:
                            sudden.y = myHitpointBasicPos[a].y - 2.1f;
                            break;
                        case 3:
                            sudden.y = myHitpointBasicPos[a].y - 2.1f;
                            break;
                        case 4:
                            sudden.y = myHitpointBasicPos[a].y - 2.1f;
                            break;
                        default:
                            print("on hotpoint_bigeye the a is null");
                            break;
                    }
                    
                    myHitPoint[a].transform.position = sudden;
                }
            }

        }

        
    }
    public void mySavePos() {
        isSavePos = true;
        for (int a = 0; a < myHitPoint.Length; a++)
        {
            myHitpointBasicPos[a] = myHitPoint[a].transform.position;
        }
    }
}
