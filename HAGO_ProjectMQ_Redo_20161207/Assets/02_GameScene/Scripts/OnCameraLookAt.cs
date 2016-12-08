using UnityEngine;
using System.Collections;

public class OnCameraLookAt : MonoBehaviour {
    public GameObject lookatTarget;
    public GameObject[] myTargetBigeye;
    public GameObject[] HotPointList;
    public GameObject[] lookatTargetList;
    public GameObject[] cameraMovePoint;
    public int cameraMod = 1;
    public float cameraMoveSpeed;
    public bool isNeedToFollow;

    public GameObject[] miniMap;
    public GameObject[] myBigeye;
    public GameObject myCameraLookControll_bigeye;
    public int myBigeyeID;
    public Vector3 mydis;
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        myBigeyeID = myCameraLookControll_bigeye.GetComponent<onCameraLookController_Bigeye>().myPickUpNum;
        if (Input.GetKeyUp("f")) {
            isNeedToFollow = true;
        }
        if (isNeedToFollow) {
            if (Input.GetKeyUp("c"))
            {
                if (cameraMod > 4) { cameraMod = 1; }
                else { cameraMod++; }
            }
            forCameraMoveLookat(cameraMod);
            miniMap[0].transform.position = Vector3.Lerp(miniMap[0].transform.position, miniMap[2].transform.position, Time.deltaTime * 10);
        }
    }
    public void BTNClick_L()
    {
        if (cameraMod <2) { cameraMod = 5; }
        else { cameraMod--; }
    }
    public void BTNClick_R()
    {
        if (cameraMod > 4) { cameraMod = 1; }
        else { cameraMod++; }
    }
    public void forCameraMoveLookat(int cameramod) {
        if (myBigeye[myBigeyeID].GetComponent<onBigeyeForAniControllVer2>().isWinggood == false){
            lookatTarget.transform.position = Vector3.Lerp(lookatTarget.transform.position, lookatTargetList[cameramod].transform.position+mydis, Time.deltaTime * cameraMoveSpeed * 10);
        }
        else {
            lookatTarget.transform.position = Vector3.Lerp(lookatTarget.transform.position, lookatTargetList[cameramod].transform.position, Time.deltaTime * cameraMoveSpeed * 10);
        }
        gameObject.transform.LookAt(lookatTarget.transform);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cameraMovePoint[cameramod].transform.position, Time.deltaTime * cameraMoveSpeed);
    }
    public void BTN_onBigeye1() {
        //isNeedToFollow = true;
        /*gameObject.GetComponent<OnCameraForShootMQ>().myABulletCount = GameObject.Find("MiniMap").GetComponent<OnMiniMap>().TeamAAmount;
        gameObject.GetComponent<OnCameraForShootMQ>().myBBulletCount = GameObject.Find("MiniMap").GetComponent<OnMiniMap>().TeamBAmount;
        gameObject.GetComponent<OnCameraForShootMQ>().myCBulletCount = GameObject.Find("MiniMap").GetComponent<OnMiniMap>().TeamCAmount;
        gameObject.GetComponent<OnCameraForShootMQ>().myDBulletCount = GameObject.Find("MiniMap").GetComponent<OnMiniMap>().TeamDAmount;
        gameObject.GetComponent<OnCameraForShootMQ>().myEBulletCount = GameObject.Find("MiniMap").GetComponent<OnMiniMap>().TeamEAmount;*/
        myCameraLookControll_bigeye.GetComponent<onCameraLookController_Bigeye>().myPickUpNum = 1;
    }
    public void BTN_onBigeye2() { myCameraLookControll_bigeye.GetComponent<onCameraLookController_Bigeye>().myPickUpNum = 2; }
    public void BTN_onBigeye3() { myCameraLookControll_bigeye.GetComponent<onCameraLookController_Bigeye>().myPickUpNum = 3 ; }

    public void BTN_TestPress() {
        print("aaa");
    }
}
