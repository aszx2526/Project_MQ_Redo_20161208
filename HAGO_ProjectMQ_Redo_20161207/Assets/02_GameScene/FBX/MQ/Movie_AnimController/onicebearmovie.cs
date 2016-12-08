using UnityEngine;
using System.Collections;

public class onicebearmovie : MonoBehaviour {
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
                myAniam.Play("walk_ing");
                break;
            case 1:
                myAniam.Play("skill1_fishHit");
                break;
            case 2:
                myAniam.Play("skill2_jumpHit");
                break;
            default:
                break;
        }
    }
}
