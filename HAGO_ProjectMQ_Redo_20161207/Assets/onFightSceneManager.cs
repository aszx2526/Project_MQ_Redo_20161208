using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onFightSceneManager : MonoBehaviour {
    public int myRandomMod;
    public GameObject[] myFightScene;
    public GameObject myBigScene;
    public GameObject myMonsterSpawnPoint;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (myRandomMod) {
            case 0:
                myBigScene.SetActive(false);
                myFightScene[0].SetActive(true);
                myFightScene[1].SetActive(false);
                myFightScene[2].SetActive(false);
                myFightScene[3].SetActive(false);
                myFightScene[4].SetActive(false);
                break;
            case 1:
                myBigScene.SetActive(false);
                myFightScene[0].SetActive(false);
                myFightScene[1].SetActive(true);
                myFightScene[2].SetActive(false);
                myFightScene[3].SetActive(false);
                myFightScene[4].SetActive(false);
                break;
            case 2:
                myBigScene.SetActive(false);
                myFightScene[0].SetActive(false);
                myFightScene[1].SetActive(false);
                myFightScene[2].SetActive(true);
                myFightScene[3].SetActive(false);
                myFightScene[4].SetActive(false);
                break;
            case 3:
                myBigScene.SetActive(false);
                myFightScene[0].SetActive(false);
                myFightScene[1].SetActive(false);
                myFightScene[2].SetActive(false);
                myFightScene[3].SetActive(true);
                myFightScene[4].SetActive(false);
                break;
            case 4:
                myBigScene.SetActive(false);
                myFightScene[0].SetActive(false);
                myFightScene[1].SetActive(false);
                myFightScene[2].SetActive(false);
                myFightScene[3].SetActive(false);
                myFightScene[4].SetActive(true);
                break;
            case 5:
                myBigScene.SetActive(true);
                myFightScene[0].SetActive(false);
                myFightScene[1].SetActive(false);
                myFightScene[2].SetActive(false);
                myFightScene[3].SetActive(false);
                myFightScene[4].SetActive(false);
                break;
        }
	}
}
