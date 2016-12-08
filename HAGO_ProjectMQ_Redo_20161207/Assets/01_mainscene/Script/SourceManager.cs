using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SourceManager : MonoBehaviour {

    public GameObject sourceBar;
    public GameObject sourceInfo;
    public GameObject targetPos;

    public Text infoText;

    public float maxSource;
    public float source;

    public string sourceName;

    float source_Percent;

    //Vector3 targetPos;

    bool down = false;
    bool ignoreClick;
    // Use this for initialization
    void Start () {
        //暫時還沒有做資料儲存，所以先沒有用
        //maxSource = PlayerPrefs.GetFloat("Max"+sourceName);
        //source = PlayerPrefs.GetFloat(sourceName);
    }
	
	// Update is called once per frame
	void Update () {
        SourceBarView();
        SourceInfoBack();
        SourceInfo();
        SourceMove();
    }

    void SourceBarView()
    {
        source_Percent = source / maxSource;
        if (source > maxSource) source = maxSource;
        else if (source <= 0) source = 0;
        sourceBar.transform.localPosition = new Vector3(-100 + 100 * source_Percent, 0.0f, 0.0f);
    }

    void SourceInfo()
    {
        infoText.text = source + "/" + maxSource;
    }

    void SourceMove()
    {
        if(down)
            sourceInfo.transform.position = Vector3.Lerp(sourceInfo.transform.position,targetPos.transform.position, Time.deltaTime*10);
        else
            sourceInfo.transform.position = Vector3.Lerp(sourceInfo.transform.position, this.transform.position, Time.deltaTime * 10);
    }   
    
    public void TargetPosChange()
    {   
        down = !down;
    } 

    void SourceInfoBack() {
        if (ignoreClick)
        {
            return;
        }
        if (Input.GetMouseButton(0)) {
            if (down) down = false;
        }
    }
    public void On()
    {
        ignoreClick = true;
    }
    public void Off()
    {
        ignoreClick = false;
    }
}
