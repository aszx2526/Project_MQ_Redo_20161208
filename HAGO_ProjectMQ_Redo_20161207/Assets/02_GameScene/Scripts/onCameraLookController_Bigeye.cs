using UnityEngine;
using System.Collections;

public class onCameraLookController_Bigeye : MonoBehaviour {
    public GameObject[] myBigeye;
    public int myPickUpNum;
    public GameObject mylookatpoint;
    public Vector3 myBasicPos;
    public Vector3 mydis;
	// Use this for initialization
	void Start () {
      //  transform.position = myBigeye.transform.position;
        //myBasicPos = mylookatpoint.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        /* if(myBigeye.GetComponent<onBigeyeForAniControllVer2>().isWinggood == false){
             mylookatpoint.transform.position = myBigeye.transform.position+mydis;
             //transform.rotation = myBigeye.transform.rotation;
         }
         else{
 //            mylookatpoint.transform.position = myBasicPos;
            // if (Vector3.Distance(transform.position, myBigeye.transform.position) == 0) { myBasicPos = mylookatpoint.transform.position; }
             //mylookatpoint.transform.position = myBasicPos;
             transform.position = myBigeye.transform.position;
             //transform.rotation = myBigeye.transform.rotation;
         }*/
        if (myPickUpNum != 0) { transform.position = myBigeye[myPickUpNum].transform.position; }
        
    }
}
