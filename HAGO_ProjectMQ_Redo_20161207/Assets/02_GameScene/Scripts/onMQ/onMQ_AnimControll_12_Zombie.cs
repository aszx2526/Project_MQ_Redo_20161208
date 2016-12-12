using UnityEngine;
using System.Collections;

public class onMQ_AnimControll_12_Zombie : MonoBehaviour {
    public int myMQAniMod;//0攻擊1待機234
    public Animator myAniam;
    public GameObject myFather;
    // Use this for initialization
    void Start()
    {
        myAniam = gameObject.GetComponent<Animator>();
        myFather = transform.parent.gameObject;
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
                myAniam.Play("ZombieAttack");
                break;
            case 1:
                myAniam.Play("ZombieBasic");
                break;
            case 2:
                myAniam.Play("ZombieCharge_loop");
                break;
            case 3:
                myAniam.Play("ZombieHit");
                break;
            case 4:
                myAniam.Play("ZombieRotation");
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
