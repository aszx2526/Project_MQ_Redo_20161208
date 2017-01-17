using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onCamera_dtg : MonoBehaviour {
    public float myCameraRotationSpeed;//攝影機旋轉速度
    public int myCameraMod;//攝影機的模式，簡單講就是攝影機現在看哪裡啦
    public Camera myMainCamera;//抓我的主攝影機
    public GameObject[] myMonsterList;//怪物清單
    public int myPickUpNum;//我選到哪一隻怪物 for mini map
    public GameObject[] theLookAtPointOnMonster;//hitpoint on monster
    public GameObject[] theHotPointOnMonster;
    public GameObject myLookAtPoint;//攝影機的焦點
    public bool isMoveTime;//是否為移動時間
    public float myZoonSpeed;//放大縮小的速度
  //  public Quaternion myqua;
    //------
    public GameObject myLocker;
    [Header("臨時調用參數_")]
    public float a_rota;
    [Header("臨時調用參數_")]
    public float b_zooninout;
    [Header("臨時調用參數_")]
    public float c_yupdown;

    //----------
    public Quaternion qua;
    public Vector3 myPos;
    //----------
    // Use this for initialization
    void Start () {
        myMainCamera = GameObject.Find("MainCamera").gameObject.GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
     //   myqua = transform.rotation;
        if (myPickUpNum != 0) {
            if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart) {
                //這行會讓2D物件變成billboard

               

                myLocker.transform.position = Camera.main.WorldToScreenPoint(theLookAtPointOnMonster[myCameraMod].transform.position);

             

            }
            else {
               /* transform.position = myMonsterList[myPickUpNum - 1].transform.position;
                theLookAtPointOnMonster = myMonsterList[myPickUpNum - 1].GetComponent<onMonsterVer3>().MyHitpointList;
                theHotPointOnMonster = myMonsterList[myPickUpNum - 1].GetComponent<onMonsterVer3>().myHotPointList;*/
            }
        }
        if (GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().isGameStart) { CameraRotationFN(); }
    }
    public void myFNonCamera_dtg() {

        transform.position = myMonsterList[myPickUpNum - 1].transform.position;
        theLookAtPointOnMonster = myMonsterList[myPickUpNum - 1].GetComponent<onMonsterVer3>().MyHitpointList;
        theHotPointOnMonster = myMonsterList[myPickUpNum - 1].GetComponent<onMonsterVer3>().myHotPointList;
    }
    public void CameraRotationFN() {
        switch (myMonsterList[myPickUpNum - 1].tag) {
            case "monster_bigeye":
                if (myMonsterList[myPickUpNum - 1].gameObject.transform.GetChild(0).GetComponent<onBigeyeForAniControllVer2>().isWinggood) {
                    switch (myCameraMod)
                    {
                        case 0:
                            //3.8>6.3
                            myCameraFN(0, 60, 2.3f);
                            break;
                        case 1:
                            myCameraFN(-1.3f, 40, 4.8f);
                            break;
                        case 2:
                            myCameraFN(1f, 30, 4.8f);
                            break;
                        case 3:
                            myCameraFN(0.5f, 47, 2.8f);
                            break;
                        case 4:
                            myCameraFN(-0.5f, 45, 2.8f);
                            break;
                    }
                }
                else {
                    //print("oncamera_dtg wing break");
                    switch (myCameraMod)
                    {
                        case 0:
                            //3.8>6.3
                            myCameraFN(0, 60, 2.3f);
                            break;
                        case 1:
                            myCameraFN(-1.3f, 40, 4.8f);
                            break;
                        case 2:
                            myCameraFN(1f, 30, 4.8f);
                            break;
                        case 3:
                            myCameraFN(0.5f, 47, 2.8f);
                            break;
                        case 4:
                            myCameraFN(-0.5f, 45, 2.8f);
                            break;
                    }
                }
                break;
            case "monster_icebear":
                myCameraLookAtPointMoveFN();//暫時用，讓鏡頭會看著攻擊點
                if (myMonsterList[myPickUpNum - 1].gameObject.transform.GetChild(0).GetComponent<onIceBearForAniControll>().isLeggood)
                {
                    if (myMonsterList[myPickUpNum - 1].gameObject.transform.GetChild(0).GetComponent<onIceBearForAniControll>().isQTETime)
                    {
                        myCameraFN(0.0f, 60, 1f);
                    }
                    else {
                        switch (myCameraMod)
                        {
                            case 0:
                                //myCameraFN(a_rota, b_zooninout, c_yupdown);
                                myCameraFN(-0.4f, 70f, 3f);
                                break;
                            case 1:
                                myCameraFN(0.4f, 70, 2f);
                                break;
                            case 2:
                                myCameraFN(-0.2f, 60, 0.25f);
                                break;
                            case 3:
                                myCameraFN(-0.2f, 60, -0.1f);
                                break;
                            case 4:
                                myCameraFN(0.2f, 60, -0.1f);
                                break;
                            default:
                                print("會跑到這裡表示 myCameraMod 異常");
                                break;
                        }
                    }
                }
                else {
                    if (myMonsterList[myPickUpNum - 1].gameObject.transform.GetChild(0).GetComponent<onIceBearForAniControll>().isQTETime)
                    {
                        myCameraFN(0, 30, 1f);
                    }
                    else {
                        switch (myCameraMod)
                        {
                            case 0:
                                //myCameraFN(a_rota, 60, c_yupdown);
                                myCameraFN(-0.6f, 60, 2.5f);
                                break;
                            case 1:
                                //myCameraFN(a_rota, 60, c_yupdown);
                                myCameraFN(0.6f, 40, 2f);
                                break;
                            case 2:
                                //myCameraFN(a_rota, 60, c_yupdown);
                                myCameraFN(0f, 30, 2.4f);
                                break;
                            case 3:
                                //myCameraFN(a_rota, 60, c_yupdown);
                                myCameraFN(-0.6f, 47, 1f);
                                break;
                            case 4:
                                //myCameraFN(a_rota, 60, c_yupdown);
                                myCameraFN(0.6f, 45, 1f);
                                break;
                        }
                    }

                }
                break;
            case "monster_noface":
                switch (myCameraMod)
                {
                    case 0:
                        myCameraFN(a_rota, 60, c_yupdown);
                        //myCameraFN(-0.6f, 60, 2.5f);
                        break;
                    case 1:
                        myCameraFN(a_rota, 60, c_yupdown);
                        //myCameraFN(0.6f, 40, 2f);
                        break;
                    case 2:
                        myCameraFN(a_rota, 60, c_yupdown);
                        //myCameraFN(0f, 30, 2.4f);
                        break;
                    case 3:
                        myCameraFN(a_rota, 60, c_yupdown);
                        //myCameraFN(-0.6f, 47, 1f);
                        break;
                    case 4:
                        myCameraFN(a_rota, 60, c_yupdown);
                        //myCameraFN(0.6f, 45, 1f);
                        break;
                }
                break;
            default:
                print("攝影機旋轉怪物清單為 null");
                break;
        }
    }
    //鏡頭相關的韓式，縮放阿，旋轉，移動座標等等
    public float myA = 0;//死亡旋轉用的計時器
    public void myCameraFN(float rotateValue,float myfieldOfView, float myPosYTrimming) {
        
        //怪物死亡旋轉
        if (GameObject.Find("Morale_Bar_Monster").GetComponent<Image>().fillAmount == 0)
        {
            Quaternion a = myMonsterList[myPickUpNum - 1].transform.rotation;
            myA += Time.deltaTime;
            if (myA < 3)
            {
                myA += Time.deltaTime;
                a.y = rotateValue + 2;
                transform.rotation = Quaternion.Lerp(transform.rotation, a, Time.deltaTime * myCameraRotationSpeed * 0.1f);
            }
            else if (myA > 3 && myA < 6)
            {
                myA += Time.deltaTime;
                a.y = rotateValue - 2;
                transform.rotation = Quaternion.Lerp(transform.rotation, a, Time.deltaTime * myCameraRotationSpeed * 0.1f);
            }
            else if (myA > 6) { myA = 0; }
            myLookAtPoint.transform.position = theLookAtPointOnMonster[0].transform.position;
        }
        else {
            switch (myMonsterList[myPickUpNum - 1].tag) {
                case "monster_icebear":
                    if (myMonsterList[myPickUpNum - 1].gameObject.transform.GetChild(0).GetComponent<onIceBearForAniControll>().isQTETime) {
                        if (myMonsterList[myPickUpNum - 1].gameObject.transform.GetChild(0).GetComponent<onIceBearForAniControll>().isLeggood){
                            //旋轉
                            qua = myMonsterList[myPickUpNum - 1].transform.rotation;
                            qua.y = rotateValue;
                            transform.rotation = Quaternion.Lerp(transform.rotation, qua, Time.deltaTime * myCameraRotationSpeed);

                            //縮放鏡頭
                            if (myMainCamera.fieldOfView > myfieldOfView) { myMainCamera.fieldOfView -= Time.deltaTime * myZoonSpeed; }
                            else if (myMainCamera.fieldOfView < myfieldOfView - 1) { myMainCamera.fieldOfView += Time.deltaTime * myZoonSpeed; }
                            else { myMainCamera.fieldOfView = myfieldOfView; }

                            myPos = myMonsterList[myPickUpNum - 1].transform.position;
                            myPos.y = myPos.y + myPosYTrimming;
                            transform.position = Vector3.Lerp(transform.position, myPos, Time.deltaTime * myCameraRotationSpeed);

                            myLookAtPoint.transform.position = myMonsterList[myPickUpNum - 1].gameObject.transform.GetChild(0).GetComponent<onIceBearForAniControll>().myHotPoint.GetComponent<onHotPoint_Icebear>().myQTETimeLookAtTarget[0].transform.position;
                        }
                        else {
                            //旋轉
                            qua = myMonsterList[myPickUpNum - 1].transform.rotation;
                            qua.y = rotateValue;
                            transform.rotation = Quaternion.Lerp(transform.rotation, qua, Time.deltaTime * myCameraRotationSpeed);

                            //縮放鏡頭
                            if (myMainCamera.fieldOfView > myfieldOfView) { myMainCamera.fieldOfView -= Time.deltaTime * myZoonSpeed; }
                            else if (myMainCamera.fieldOfView < myfieldOfView - 1) { myMainCamera.fieldOfView += Time.deltaTime * myZoonSpeed; }
                            else { myMainCamera.fieldOfView = myfieldOfView; }

                            myPos = myMonsterList[myPickUpNum - 1].transform.position;
                            myPos.y = myPos.y + myPosYTrimming;
                            transform.position = Vector3.Lerp(transform.position, myPos, Time.deltaTime * myCameraRotationSpeed);

                            myLookAtPoint.transform.position = myMonsterList[myPickUpNum - 1].gameObject.transform.GetChild(0).GetComponent<onIceBearForAniControll>().myHotPoint.GetComponent<onHotPoint_Icebear>().myQTETimeLookAtTarget[1].transform.position;
                        } 
                    }
                    else {
                        //旋轉
                        qua = myMonsterList[myPickUpNum - 1].transform.rotation;
                        qua.y = rotateValue;
                        transform.rotation = Quaternion.Lerp(transform.rotation, qua, Time.deltaTime * myCameraRotationSpeed);

                        //縮放鏡頭
                        if (myMainCamera.fieldOfView > myfieldOfView) { myMainCamera.fieldOfView -= Time.deltaTime * myZoonSpeed; }
                        else if (myMainCamera.fieldOfView < myfieldOfView - 1) { myMainCamera.fieldOfView += Time.deltaTime * myZoonSpeed; }
                        else { myMainCamera.fieldOfView = myfieldOfView; }

                        myPos = myMonsterList[myPickUpNum - 1].transform.position;
                        myPos.y = myPos.y + myPosYTrimming;
                        transform.position = Vector3.Lerp(transform.position, myPos, Time.deltaTime * myCameraRotationSpeed);

                        myCameraLookAtPointMoveFN();
                    }
                    break;
                default:
                    //旋轉
                    qua = myMonsterList[myPickUpNum - 1].transform.rotation;
                    qua.y = rotateValue;
                    transform.rotation = Quaternion.Lerp(transform.rotation, qua, Time.deltaTime * myCameraRotationSpeed);

                    //縮放鏡頭
                    if (myMainCamera.fieldOfView > myfieldOfView) { myMainCamera.fieldOfView -= Time.deltaTime * myZoonSpeed; }
                    else if (myMainCamera.fieldOfView < myfieldOfView - 1) { myMainCamera.fieldOfView += Time.deltaTime * myZoonSpeed; }
                    else { myMainCamera.fieldOfView = myfieldOfView; }

                    myPos = myMonsterList[myPickUpNum - 1].transform.position;
                    myPos.y = myPos.y + myPosYTrimming;
                    transform.position = Vector3.Lerp(transform.position, myPos, Time.deltaTime * myCameraRotationSpeed);

                    myCameraLookAtPointMoveFN();

                    break;
            }

         
        }     
    }

    //焦點移動韓式，如果焦點距離hitpoint 小於0.1就不要動啦，不然鏡頭一直晃不舒服
    public void myCameraLookAtPointMoveFN() {
        //if (Vector3.Distance(myLookAtPoint.transform.position, theHotPointOnMonster[myCameraMod].transform.position) < 0.1)
        if (myLookAtPoint.transform.position == theHotPointOnMonster[myCameraMod].transform.position)
        {
            isMoveTime = false;
        }
        else {
            if (isMoveTime) {
                myLookAtPoint.transform.position = Vector3.Lerp(myLookAtPoint.transform.position,
                                                                theHotPointOnMonster[myCameraMod].transform.position,
                                                                Time.deltaTime * myCameraRotationSpeed * 1.5f);
            }
        }
    }
    //控制看下一個可攻擊點或者上一個可攻擊點
    public void ScrollViewLeftControllFN()
    {
        isMoveTime = true;
        if (myCameraMod > 3) { myCameraMod = 0; }
        else { myCameraMod++; }
    }
    public void ScrollViewRightControllFN()
    {
        isMoveTime = true;
        if (myCameraMod < 1) { myCameraMod = 4; }
        else { myCameraMod--; }
    }
    public void BTN_onMiniMap_Monster1()
    {
        print("monster1 be click");
        if (myMonsterList[0].GetComponent<onMonsterVer3>().isMeDead) { myPickUpNum = 0; }
        else { myPickUpNum = 1; }
        myFNonCamera_dtg();
    }
    public void BTN_onMiniMap_Monster2() {
        print("monster2 be click");
        if (myMonsterList[1].GetComponent<onMonsterVer3>().isMeDead) { myPickUpNum = 0; }
        else { myPickUpNum = 2; }
        myFNonCamera_dtg();
    }
    public void BTN_onMiniMap_Monster3()
    {
        print("monster3 be click");
        if (myMonsterList[2].GetComponent<onMonsterVer3>().isMeDead) { myPickUpNum = 0; }
        else { myPickUpNum = 3; }
        myFNonCamera_dtg();
    }
    public void BTN_onMiniMap_Monster4()
    {
        print("monster4 be click");
        if (myMonsterList[3].GetComponent<onMonsterVer3>().isMeDead) { myPickUpNum = 0; }
        else { myPickUpNum = 4; }
        myFNonCamera_dtg();
    }
}
 