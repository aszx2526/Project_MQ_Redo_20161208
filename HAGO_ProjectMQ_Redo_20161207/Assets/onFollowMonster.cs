using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class onFollowMonster : MonoBehaviour {
    public GameObject myFollowObject;
    public bool isNeedToFollow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isNeedToFollow) {
            if (!myFollowObject.GetComponent<onMonsterVer3>().isMeToFight)
            {
                gameObject.transform.position = myFollowObject.transform.position;
            }
            if (!myFollowObject) { Destroy(gameObject); }
        }
        
	}
}
