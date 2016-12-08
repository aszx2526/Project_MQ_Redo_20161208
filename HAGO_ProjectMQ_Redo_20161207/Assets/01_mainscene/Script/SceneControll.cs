using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SceneControll : MonoBehaviour {


    bool changeScene = false;
    private string levelToLoad;
    
        
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (changeScene)
        {
            StartCoroutine(DisplayLoadingScreen(levelToLoad));
        }
	}
    IEnumerator DisplayLoadingScreen(string level)
    {
        /*//將進度讀取介面打開
        background.SetActive(true);
        text.SetActive(true);
        progressBar.SetActive(true);

        /*progressBar.transform.localScale = new Vector3(loadProgress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);

        text.GetComponent<GUIText>().text = "Loading... " + loadProgress + "%";*/

        //設置一個異步讀取的對象   進行異步讀取場景 level 就是要讀取的場景
        AsyncOperation async = Application.LoadLevelAsync(level);

        while (!async.isDone)
        /*{
            //將讀取的進度值 *100 使之最大可到 100 ，之後轉換為整數
            loadProgress = (int)(async.progress * 100);

            //讀取條表現方式控制碼
            progressBar.transform.localScale = new Vector3(async.progress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);

            //Unity 5 之後要使用 GUIText 就要是用下面的方式來抓取 GUIText 裡的參數
            text.GetComponent<GUIText>().text = "Loading... " + loadProgress + "%";

            *///回傳 null ，此方法會回到上層的 StartCoroutine ，重新呼叫一次
            yield return null;
        //}
    }
    //public void GotoLibrary()
    //{
    //    PlayerPrefs.SetString("Scene", stage);
    //    levelToLoad = "Library";
    //    changeScene = true;
    //}
    //public void GotoShop()
    //{
    //    PlayerPrefs.SetString("Scene", stage);
    //    levelToLoad = "Shop";
    //    changeScene = true;
    //}
    //public void GotoMain()
    //{
    //    PlayerPrefs.SetString("Scene", stage);
    //    levelToLoad = "MainScreen";
    //    changeScene = true;
    //}
    public void SceneChange(string stage)
    {
        PlayerPrefs.SetString("Scene",stage);
        levelToLoad = "SceneChange";
        changeScene = true;        
    }
    void myToMainScene()
    {
        Debug.Log("debug log by LT:myToMainScene()");
        SceneManager.LoadScene("MainScene");
        //Application.LoadLevel("MainScene");
    }
    void myToLibrary()
    {
        Debug.Log("debug log by LT:myToLibrary()");
        SceneManager.LoadScene("library");
        //Application.LoadLevel("library");
    }
    void myToShop()
    {
        Debug.Log("debug log by LT:myToShop()");
        SceneManager.LoadScene("shop");
        //Application.LoadLevel("shop");
    }
    void myToTeamSetting() {
        Debug.Log("debug log by LT:myToTeamSetting()");
        SceneManager.LoadScene("TeamSetting");
        //Application.LoadLevel("TeamSetting");
    }
    void myExit() {
        Application.Quit();
    }
    public void myResetBTN() {
        PlayerPrefs.DeleteAll();
    }

    //void LoadingPic()
    //{
    //    int number = Random.Range(1,10);
    //    switch (number)
    //    {

    //    }
    //}
}
