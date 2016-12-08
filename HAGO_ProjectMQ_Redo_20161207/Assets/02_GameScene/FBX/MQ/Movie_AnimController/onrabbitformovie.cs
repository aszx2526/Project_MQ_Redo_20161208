using UnityEngine;
using System.Collections;

public class onrabbitformovie : MonoBehaviour {
    public Animator myAniam;
    public int myMQAniMod;
    public bool isMove;
    public GameObject myTarget;

    public float movespeed;

    // Use this for initialization
    void Start() { myAniam = gameObject.GetComponent<Animator>(); }

    // Update is called once per frame
    void Update()
    {
        if (isMove) { transform.position = Vector3.MoveTowards(transform.position, myTarget.transform.position, Time.deltaTime * movespeed); }
        myMQAnimController();

    }
    public void myMQAnimController()
    {
        switch (myMQAniMod)
        {
            case 0:
                myAniam.Play("Fight_powrHit");
                break;
            case 1:
                myAniam.Play("Fight_powerHit_LookGood");
                break;
            default:
                break;
        }
    }
}
