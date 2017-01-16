using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onNofaceController : MonoBehaviour {
    public GameObject myAnoface;
    public GameObject myBnoface;
    public GameObject myBmask;
    public int myModID;
    // Use this for initialization
    void Start()
    {
        myModID = 0;
        myAnoface.SetActive(true);
        myBnoface.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (myModID)
        {
            case 0:
                if (myAnoface.GetComponent<onNoFaceForAniControl>().myFaceGetHurtValue >= myAnoface.GetComponent<onNoFaceForAniControl>().myFaceGetHurtValue_Full)
                {
                    myBnoface.SetActive(true);
                    myBnoface.GetComponent<onNoFaceForAniControl>().isFacegood = true;
                    myBnoface.GetComponent<onNoFaceForAniControl>().myFaceGetHurtValue = myAnoface.GetComponent<onNoFaceForAniControl>().myFaceGetHurtValue;
                    myAnoface.SetActive(false);
                    myModID = 1;
                }
                break;
            case 1:
                if (myBnoface.GetComponent<onNoFaceForAniControl>().isFacegood == false){myBmask.SetActive(false);}
                break;
        }
    }
}
