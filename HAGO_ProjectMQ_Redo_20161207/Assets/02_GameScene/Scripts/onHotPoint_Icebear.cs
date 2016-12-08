using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHotPoint_Icebear : MonoBehaviour {
    public GameObject[] myHitPoint;
    public Vector3[] myHitpointBasicPos;
    [Header("布置微調用")]
    public Vector3 myForSetting;
    public bool isSavePos;
    [Header("QTE用焦點清單")]
    public GameObject[] myQTETimeLookAtTarget;//0 = isleggood , 1 = !isleggood


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = myMonster.transform.position;
        if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart)
        {
            if (!isSavePos) { mySavePos(); }

            if (transform.parent.gameObject.transform.GetChild(0).GetComponent<onIceBearForAniControll>().isLeggood)
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
                            //myHitPoint[a].transform.position = myHitpointBasicPos[a] + myForSetting;//微調用，將攝影機焦點移動到怪物部位破壞後的位置
                            sudden = myHitpointBasicPos[a]+ new Vector3(-0.34f, -0.76f, -2.28f);
                            break;
                        case 1:
                            sudden = myHitpointBasicPos[a] + new Vector3(-0.33f, -0.5f, -1.97f);

                            break;
                        case 2:
                            sudden = myHitpointBasicPos[a] + new Vector3(-0.3f, 0.36f, -1.25f);
                            break;
                        case 3:
                            sudden = myHitpointBasicPos[a] + new Vector3(-0.3f, 0.39f, -0.21f);
                            break;
                        case 4:
                            sudden = myHitpointBasicPos[a] + new Vector3(-0.3f, 0.39f, -0.21f);
                            break;
                        default:
                            print("on hotpoint_icebear the a is null");
                            break;
                    }

                    myHitPoint[a].transform.position = sudden;
                }
            }

        }


    }
    public void mySavePos()
    {
        isSavePos = true;
        for (int a = 0; a < myHitPoint.Length; a++)
        {
            myHitpointBasicPos[a] = myHitPoint[a].transform.position;
        }
    }
}
