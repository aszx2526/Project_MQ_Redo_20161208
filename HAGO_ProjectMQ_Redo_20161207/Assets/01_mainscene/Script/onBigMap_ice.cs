using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class onBigMap_ice : MonoBehaviour {

    public int inwhichlevelmod;
    public int[] myLevelStarCount;
    public GameObject[] myLevelLock;
    public int myAllStarInIceCount;
    public int[] isBossBeKill;
    public Text[] mystar_text;

    [Header("==============")]
    public Slider loadingBar;
    public GameObject loadingImage;
    private AsyncOperation _async;

    // Use this for initialization
    void Start () {
        loadingImage.SetActive(false);
        //gameObject.SetActive(false);
        for (int a = 0; a < isBossBeKill.Length; a++) {
            isBossBeKill[a] = PlayerPrefs.GetInt("level_" + (a+1).ToString() + "_Bossbekill");
        }
        for (int a = 0; a < myLevelStarCount.Length; a++) {
            myLevelStarCount[a] = PlayerPrefs.GetInt("level_" + (a + 1).ToString() + "_starcount");
            mystar_text[a].text = myLevelStarCount[a].ToString() + "顆星";
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        //if (myLevelStarCount[0] > 0) { myLevelLock[0].GetComponent<onLockForHidden>().isTimeToDisappear = true; }
        if (isBossBeKill[0] == 1) { myLevelLock[0].GetComponent<onLockForHidden>().isTimeToDisappear = true; }
        if (isBossBeKill[1] == 1) { myLevelLock[1].GetComponent<onLockForHidden>().isTimeToDisappear = true; }
        if (isBossBeKill[2] == 1) { myLevelLock[2].GetComponent<onLockForHidden>().isTimeToDisappear = true; }
        if (isBossBeKill[3] == 1) { myLevelLock[3].GetComponent<onLockForHidden>().isTimeToDisappear = true; }

        myAllStarInIceCount = myLevelStarCount[0] + myLevelStarCount[1] + myLevelStarCount[2] + myLevelStarCount[3];
    }
    public void level1()
    {
        /*
        if (PlayerPrefs.GetInt("TeamASetting") == 0 || PlayerPrefs.GetInt("TeamBSetting") == 0) //|| PlayerPrefs.GetInt("TeamCSetting") == 0 || PlayerPrefs.GetInt("TeamDSetting") == 0 || PlayerPrefs.GetInt("TeamESetting") == 0)
        {
            GameObject.Find("Map").GetComponent<onMap>().TeamNotSetting.SetActive(true);
        }
        else {
            inwhichlevelmod = 1;
            GameObject.Find("Map").GetComponent<onMap>().beforeIntoGameScene.SetActive(true);
            GameObject.Find("Map").GetComponent<onMap>().forgetSpend();
        }*/
        loadingImage.SetActive(true);
        StartCoroutine(LoadLevelWithBar("GameScene_1"));
    //    SceneManager.LoadScene("GameScene_1");
        //Application.LoadLevel("Ver3_Prototype_");
    }
    public void level2() { SceneManager.LoadScene("GameScene_2"); }
    public void level3() { SceneManager.LoadScene("GameScene_3"); }
    public void level4() { SceneManager.LoadScene("GameScene_4"); }
    public void level5() { SceneManager.LoadScene("GameScene_5"); }

    IEnumerator LoadLevelWithBar(string level)
    {
        _async = Application.LoadLevelAsync(level);
        while (!_async.isDone)
        {
            loadingBar.value = _async.progress;
            yield return null;
        }
    }

    /*  private IEnumerator StartLoading_1(int scene)
      {
          AsyncOperation op = Application.LoadLevelAsync(scene);
          while (!op.isDone)
          {
            //  SetLoadingPercentage(op.progress * 100);

              yield return new WaitForEndOfFrame();
          }
      }*/

    public void BTN_forFight() {
        switch (inwhichlevelmod) {
            case 1:
                SceneManager.LoadScene("test1");
                //Application.LoadLevel("test1");
                break;
        }
    }
    public void BTN_forBack() {
        inwhichlevelmod = 0;
        //GameObject.Find("Map").GetComponent<onMap>().beforeIntoGameScene.SetActive(false);
    }
    public void BTN_forFTS() {
        GameObject.Find("Map").GetComponent<onMap>().TeamNotSetting.SetActive(false);
    }
}
