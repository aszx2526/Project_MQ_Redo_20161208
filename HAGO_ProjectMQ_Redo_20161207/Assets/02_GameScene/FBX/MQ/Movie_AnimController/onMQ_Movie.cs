using UnityEngine;
using System.Collections;

public class onMQ_Movie : MonoBehaviour {
    public Animator myAniam;
    public int myMQAniMod;
    public bool isMove;
    public GameObject myTarget;

    public float movespeed;

    // Use this for initialization
    void Start() { myAniam = gameObject.GetComponent<Animator>(); }

    // Update is called once per frame
    void Update () {
        if (isMove) { transform.position = Vector3.MoveTowards(transform.position, myTarget.transform.position, Time.deltaTime*movespeed); }
        myMQAnimController();

    }
    public void myMQAnimController()
    {
        switch (myMQAniMod)
        {
            case 0:
                myAniam.Play("SoliderBasic");
                break;
            case 1:
                myAniam.Play("SoldierCharge_loop");
                break;
            case 2:
                myAniam.Play("SoliderRotation");
                break;
            default:
                break;
        }
    }
}
