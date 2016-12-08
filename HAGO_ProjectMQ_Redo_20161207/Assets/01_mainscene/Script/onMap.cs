using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class onMap : MonoBehaviour {
    public GameObject[] mybigmap;
    public GameObject mywhitelight;
    //public GameObject beforeIntoGameScene;
    public GameObject TeamNotSetting;
   

    // Use this for initialization
    void Start () {
        mywhitelight.SetActive(false);
   
    }

    // Update is called once per frame
    void Update () {
	
	}
    public void btn_01_iceisland() {
        mywhitelight.SetActive(true);
        mybigmap[2].SetActive(true);
    }
    public void btn_island1() {
    //    SceneManager.LoadScene(3);
       /* mywhitelight.SetActive(true);
        mybigmap[1].SetActive(true);*/
    }
    public void btn_island2() {
        mywhitelight.SetActive(true);
        mybigmap[2].SetActive(true);
    }
    public void btn_island3() {
        mywhitelight.SetActive(true);
        mybigmap[3].SetActive(true);
    }
    public void btn_island4() {
        mywhitelight.SetActive(true);
        mybigmap[4].SetActive(true);
    }
    public void btn_whitelight() {
        mywhitelight.SetActive(false);
        for (int a = 1; a < mybigmap.Length; a++) {
            mybigmap[a].SetActive(false);
        }   
    }
  
}
