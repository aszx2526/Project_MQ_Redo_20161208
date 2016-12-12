using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMQ_AnimControll_14_BlackHole : MonoBehaviour {
    public int myMQAniMod;//0攻擊1待機2衝鋒3被打4螺旋衝
    public Animator myAniam;
    public GameObject myFather;
    // Use this for initialization
    void Start()
    {
        myAniam = gameObject.GetComponent<Animator>();
        myFather = transform.parent.gameObject;
    }


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
                myAniam.Play("attack");
                break;
            case 1:
                myAniam.Play("basic");
                break;
            case 2:
                myAniam.Play("charge");
                break;
            case 3:
                myAniam.Play("behit");
                break;
            case 4:
                myAniam.Play("rotation");
                break;
            default:
                break;
        }
    }

    public void onFirstFram_Hit() { myAniam.speed = 1.5f; }
    public void OnMiddleFram_Hit() { }
    public void OnLastFram_Hit()
    {
        myAniam.speed = 1;
        myFather.GetComponent<onMQVer3>().isBeHit = false;
    }
}
