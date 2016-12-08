using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class onLoadingScene : MonoBehaviour {
    public Sprite[] myCG;
    public SpriteRenderer mySpR;
    public int myLoadScene;
	// Use this for initialization
	void Start () {
        int a = Random.Range(0, myCG.Length + 1);
        mySpR = gameObject.GetComponent<SpriteRenderer>();
        mySpR.sprite = myCG[a];

    }
	
	// Update is called once per frame
	void Update () {
        switch (myLoadScene) {
            case 1:
                SceneManager.LoadScene(myLoadScene);
                break;
            case 2:
                SceneManager.LoadScene(myLoadScene);
                break;
        }

    }
}
