using UnityEngine;
using System.Collections;

public class onMQ_AnimControll_01_Basic : MonoBehaviour {
    public int myMQAniMod;//0攻擊1待機234
    public Animator myAniam;
    public GameObject myFather;
    // Use this for initialization
    void Start()
    {
        myAniam = gameObject.GetComponent<Animator>();
    }

    onMQVer3 onMQ3;
    // Update is called once per frame
    void Update()
    {
        myMQAniMod = myFather.GetComponent<onMQVer3>().myMQAniMod;
        myMQAnimController();
    }
    public void myMQAnimController()
    {
        switch (myMQAniMod)
        {
            case 0:
                myAniam.Play("SoliderAttack");
                break;
            case 1:
                myAniam.Play("SoliderBasic");
                break;
            case 2:
                myAniam.Play("SoldierCharge_loop");
                break;
            case 3:
                myAniam.Play("SoliderHit");
                break;
            case 4:
                myAniam.Play("SoliderRotation");
                break;
            default:
                break;
        }
    }
    public void OnLastFram_Attack()
    {
        //print("1s OnLastFram_Attack be call");
        myFather.GetComponent<onMQVer3>().myAttackTimer = 0;
        //1秒打一下
        GameObject myTargetObject = myFather.GetComponent<onMQVer3>().myTargetPoint;
        switch (myTargetObject.GetComponent<onHitPoint_UpdateHureValue>().myFather.name) {
            case "Bigeye_"://↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓大眼怪的攻擊判定↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
                switch (myTargetObject.name) {
                    case "hitpoint-1":
                        int h1 = Random.Range(0, 101);
                        if (h1 < myFather.GetComponent<onMQVer3>().myCritHit)
                        {
                            int crithit = (int)Random.Range(myFather.GetComponent<onMQVer3>().myAttack * 2, myFather.GetComponent<onMQVer3>().myAttack * 2.8f);
                            onMQ3 = myFather.GetComponent<onMQVer3>();
                            onMQ3.forHitEffect_Ver2(1, crithit);
                            myTargetObject.GetComponent<onHitPoint_UpdateHureValue>().myFather.GetComponent<onBigeyeForAniControllVer2>().myBigeyeGetHurtValue += crithit;
                            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= (float)crithit * GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMoraleBloodValue;
                        }
                        else {
                            onMQ3 = myFather.GetComponent<onMQVer3>();
                            onMQ3.forHitEffect_Ver2(0, 0);
                            myTargetObject.GetComponent<onHitPoint_UpdateHureValue>().myFather.GetComponent<onBigeyeForAniControllVer2>().myBigeyeGetHurtValue += myFather.GetComponent<onMQVer3>().myAttack;
                            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= (float)myFather.GetComponent<onMQVer3>().myAttack * GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMoraleBloodValue;
                        }
                        break;
                    case "hitpoint-2":
                    case "hitpoint-3":
                        int h23 = Random.Range(0, 101);
                        if (h23 < myFather.GetComponent<onMQVer3>().myCritHit)
                        {
                            int crithit = (int)Random.Range(myFather.GetComponent<onMQVer3>().myAttack * 2, myFather.GetComponent<onMQVer3>().myAttack * 2.8f);
                            onMQ3 = myFather.GetComponent<onMQVer3>();
                            onMQ3.forHitEffect_Ver2(1, crithit);
                            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= (float)crithit * GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMoraleBloodValue;
                        }
                        else {
                            onMQ3 = myFather.GetComponent<onMQVer3>();
                            onMQ3.forHitEffect_Ver2(0, 0);
                            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= (float)myFather.GetComponent<onMQVer3>().myAttack * GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMoraleBloodValue;
                        }
                        break;
                    case "hitpoint-4":
                    case "hitpoint-5":
                        int h45 = Random.Range(0, 101);
                        if (h45 < myFather.GetComponent<onMQVer3>().myCritHit)
                        {
                            int crithit = (int)Random.Range(myFather.GetComponent<onMQVer3>().myAttack * 2, myFather.GetComponent<onMQVer3>().myAttack * 2.8f);
                            onMQ3 = myFather.GetComponent<onMQVer3>();
                            onMQ3.forHitEffect_Ver2(1, crithit);
                            myTargetObject.GetComponent<onHitPoint_UpdateHureValue>().myFather.GetComponent<onBigeyeForAniControllVer2>().myWingGetHurtValue += crithit;
                            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= (float)crithit * GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMoraleBloodValue;
                        }
                        else {
                            onMQ3 = myFather.GetComponent<onMQVer3>();
                            onMQ3.forHitEffect_Ver2(0, 0);
                            myTargetObject.GetComponent<onHitPoint_UpdateHureValue>().myFather.GetComponent<onBigeyeForAniControllVer2>().myWingGetHurtValue += myFather.GetComponent<onMQVer3>().myAttack;
                            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= (float)myFather.GetComponent<onMQVer3>().myAttack * GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMoraleBloodValue;
                        }
                        break;
                    default:
                        break;
                }
                break;
            case "Bear"://↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓熊的攻擊判定↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
                switch (myTargetObject.name)
                {
                    case "hitpoint-1":
                        int h1 = Random.Range(0, 101);
                        if (h1 < myFather.GetComponent<onMQVer3>().myCritHit)
                        {
                            int crithit = (int)Random.Range(myFather.GetComponent<onMQVer3>().myAttack * 2, myFather.GetComponent<onMQVer3>().myAttack * 2.8f);
                            onMQ3 = myFather.GetComponent<onMQVer3>();
                            onMQ3.forHitEffect_Ver2(1, crithit);
                            myTargetObject.GetComponent<onHitPoint_UpdateHureValue>().myFather.GetComponent<onIceBearForAniControll>().myHeadGetHurtValue += crithit;
                            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= (float)crithit * GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMoraleBloodValue;
                        }
                        else {
                            onMQ3 = myFather.GetComponent<onMQVer3>();
                            onMQ3.forHitEffect_Ver2(0, 0);
                            myTargetObject.GetComponent<onHitPoint_UpdateHureValue>().myFather.GetComponent<onIceBearForAniControll>().myHeadGetHurtValue += myFather.GetComponent<onMQVer3>().myAttack;
                            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= (float)myFather.GetComponent<onMQVer3>().myAttack * GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMoraleBloodValue;
                        }
                        break;
                    case "hitpoint-2":
                    case "hitpoint-3":
                        int h23 = Random.Range(0, 101);
                        if (h23 < myFather.GetComponent<onMQVer3>().myCritHit)
                        {
                            int crithit = (int)Random.Range(myFather.GetComponent<onMQVer3>().myAttack * 2, myFather.GetComponent<onMQVer3>().myAttack * 2.8f);
                            onMQ3 = myFather.GetComponent<onMQVer3>();
                            onMQ3.forHitEffect_Ver2(1, crithit);
                            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= (float)crithit * GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMoraleBloodValue;
                        }
                        else {
                            onMQ3 = myFather.GetComponent<onMQVer3>();
                            onMQ3.forHitEffect_Ver2(0, 0);
                            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= (float)myFather.GetComponent<onMQVer3>().myAttack * GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMoraleBloodValue;
                        }
                        break;
                    case "hitpoint-4":
                    case "hitpoint-5":
                        int h45 = Random.Range(0, 101);
                        if (h45 < myFather.GetComponent<onMQVer3>().myCritHit)
                        {
                            int crithit = (int)Random.Range(myFather.GetComponent<onMQVer3>().myAttack * 2, myFather.GetComponent<onMQVer3>().myAttack * 2.8f);
                            onMQ3 = myFather.GetComponent<onMQVer3>();
                            onMQ3.forHitEffect_Ver2(1, crithit);
                            myTargetObject.GetComponent<onHitPoint_UpdateHureValue>().myFather.GetComponent<onIceBearForAniControll>().myLegGetHurtValue += crithit;
                            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= (float)crithit * GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMoraleBloodValue;
                        }
                        else {
                            onMQ3 = myFather.GetComponent<onMQVer3>();
                            onMQ3.forHitEffect_Ver2(0, 0);
                            myTargetObject.GetComponent<onHitPoint_UpdateHureValue>().myFather.GetComponent<onIceBearForAniControll>().myLegGetHurtValue += myFather.GetComponent<onMQVer3>().myAttack;
                            GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMorale -= (float)myFather.GetComponent<onMQVer3>().myAttack * GameObject.Find("Canvas").GetComponent<onCanvasForUIControll>().myMonsterMoraleBloodValue;
                        }
                        break;
                    default:
                        break;
                }
                break;
            default:
                print("這隻怪物尚未進行蚊子的攻擊判定");
                break;
        }
    }
    public void onFirstFram_Hit() {myAniam.speed = 1.5f;}
    public void OnMiddleFram_Hit(){}
    public void OnLastFram_Hit()
    {
        myAniam.speed = 1;
        myFather.GetComponent<onMQVer3>().isBeHit = false;
    }
}
