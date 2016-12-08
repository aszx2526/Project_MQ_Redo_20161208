using UnityEngine;
using System.Collections;
using UnityEngine.UI;	// uGUIの機能を使うお約束
using UnityEngine.SceneManagement;

public class OnCanvas_StoryMod : MonoBehaviour {
    public Texture character_A;
    public Texture character_B;
    public Texture Nothing;
    public RawImage myRawImage_A;
    public RawImage myRawImage_B;
    public int myTalkingConter;//024A 135B
    public Button Button_A;
    public Button Button_B;
    public Button Button_C;
    [SerializeField]
    Text uiText_A;
    [SerializeField]
    Text uiText_B;
    [SerializeField]
    Text uiText_Chose1;
    [SerializeField]
    Text uiText_Chose2;
    [SerializeField]
    Text uiText_Chose3;


    public string[] scenarios_A_Chinese;
    public string[] scenarios_B_Chinese;
    public string[] chose1_Chinese;
    public string[] chose2_Chinese;
    public string[] chose3_Chinese;
    public string[] scenarios_A_English;
    public string[] scenarios_B_English;
    public string[] chose1_English;
    public string[] chose2_English;
    public string[] chose3_English;

    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalForCharacterDisplay = 0.05f;  // 1文字の表示にかかる時間
    //-250160---300160
    private int currentLine_A = 0;
    private string currentText_A = string.Empty;  // 現在の文字列
    private float timeUntilDisplay_A = 0;     // 表示にかかる時間
    private float timeElapsed_A = 1;          // 文字列の表示を開始した時間
    private int lastUpdateCharacter_A = -1;       // 表示中の文字数

    private int currentLine_B = 0;
    private string currentText_B = string.Empty;  // 現在の文字列
    private float timeUntilDisplay_B = 0;     // 表示にかかる時間
    private float timeElapsed_B = 1;          // 文字列の表示を開始した時間
    private int lastUpdateCharacter_B = -1;       // 表示中の文字数
    public int isChinese;//0=中文 1=英文
    public float myGameStartCount = 0;
    //BattleInfoView myBIV;
    public GameObject myStoryMovie;
    void Start()
    {
        // maybework.SetActive(false);
        myStoryMovie = GameObject.Find("StoryMovieCanvas");
        GameObject myBattle = GameObject.Find("UIcontroller");
        //myBIV = myBattle.GetComponent<BattleInfoView>();

        HidButton();
        if (character_A) { myRawImage_A.texture = character_A; } else { myRawImage_A.texture = Nothing; }
        if (character_B) { myRawImage_B.texture = character_B; } else { myRawImage_B.texture = Nothing; }
        if (Application.systemLanguage.ToString() == "Chinese")
        {
            print("現在的語言為：" + Application.systemLanguage.ToString());
            isChinese = 0;
        }
        else if (Application.systemLanguage.ToString() == "English")
        {
            print("Your language is:" + Application.systemLanguage.ToString());
            isChinese = 1;
        }
        myTalkingConter = 0;
        //ASetNextLine();
    }
    void Update()
    {
        switch (isChinese)
        {
            case 0:
                if (myTalkingConter == 5)
                {
                    //ASetNextLine();
                    if (myGameStartCount >= 3)
                    {//劇情表演結束了，數三秒，暫停結束，把表演的道具藏起來，開始玩！！！

                        //myBIV.pauseCheck = false;
                        myStoryMovie.SetActive(false);
                        GameObject.Find("youcan'tsetwunze").SetActive(false);
                    }
                    else { myGameStartCount += Time.deltaTime; }
                }
                if (myTalkingConter == 4) { }
                else {
                    if (currentLine_A < scenarios_A_Chinese.Length && Input.GetMouseButtonDown(0))// && (this.name == "Image_A" || this.name == "Image_B"))
                    {
                        if (myTalkingConter % 2 == 0)
                        {
                            ASetNextLine();
                            myTalkingConter++;
                        }
                        else {
                            if (myTalkingConter == 3)
                            {
                                ShowButton();
                                BSetNextLine();
                                myTalkingConter++;
                            }
                            else {
                                BSetNextLine();
                                myTalkingConter++;
                            }
                        }
                    }
                }

                break;
            case 1:
                if (myTalkingConter == 4) { }
                else {
                    if (currentLine_A < scenarios_A_English.Length && Input.GetMouseButtonDown(0))// && (this.name == "Image_A" || this.name == "Image_B"))
                    {
                        if (myTalkingConter % 2 == 0)
                        {
                            ASetNextLine();
                            myTalkingConter++;
                        }
                        else {
                            if (myTalkingConter == 3)
                            {
                                ShowButton();
                                BSetNextLine();
                                myTalkingConter++;
                            }
                            else {
                                BSetNextLine();
                                myTalkingConter++;
                            }
                        }
                    }
                }
                break;
            default:
                break;
        }


        int displayCharacterCount_A = (int)(Mathf.Clamp01((Time.time - timeElapsed_A) / timeUntilDisplay_A) * currentText_A.Length);
        if (displayCharacterCount_A != lastUpdateCharacter_A)
        {
            uiText_A.text = currentText_A.Substring(0, displayCharacterCount_A);
            lastUpdateCharacter_A = displayCharacterCount_A;
        }
        int displayCharacterCount_B = (int)(Mathf.Clamp01((Time.time - timeElapsed_B) / timeUntilDisplay_B) * currentText_B.Length);
        if (displayCharacterCount_B != lastUpdateCharacter_B)
        {
            uiText_B.text = currentText_B.Substring(0, displayCharacterCount_B);
            lastUpdateCharacter_B = displayCharacterCount_B;
        }
    }
    void ASetNextLine()
    {
        if (isChinese == 0)
        {
            currentText_A = scenarios_A_Chinese[currentLine_A];
        }
        else {
            currentText_A = scenarios_A_English[currentLine_A];

        }
        currentLine_A++;
        timeUntilDisplay_A = currentText_A.Length * intervalForCharacterDisplay;
        timeElapsed_A = Time.time;
        lastUpdateCharacter_A = -1;
    }
    void BSetNextLine()
    {
        if (isChinese == 0)
        {
            currentText_B = scenarios_B_Chinese[currentLine_B];
        }
        else {
            currentText_B = scenarios_B_English[currentLine_B];
        }
        currentLine_B++;
        timeUntilDisplay_B = currentText_B.Length * intervalForCharacterDisplay;
        timeElapsed_B = Time.time;
        lastUpdateCharacter_B = -1;
    }
    void OnMouseUp()
    {
        Debug.Log("Mouse click");
    }
    void OnClick()
    {

    }
    void Chose1()
    {
        Debug.Log("選一一一一一一一一一一一拉！！！");
        myTalkingConter++;
        ASetNextLine();
        HidButton();
    }
    void Chose2()
    {
        Debug.Log("選二二二二二二二二二二二拉！！！");
        myTalkingConter++;
        ASetNextLine();
        HidButton();
    }
    void Chose3()
    {
        Debug.Log("選三三三三三三三三三三三拉！！！");
        myTalkingConter++;
        ASetNextLine();
        HidButton();
    }
    void HidButton()
    {
        Button_A.image.enabled = false;
        Button_A.enabled = false;
        uiText_Chose1.enabled = false;
        Button_B.image.enabled = false;
        Button_B.enabled = false;
        uiText_Chose2.enabled = false;
        Button_C.image.enabled = false;
        Button_C.enabled = false;
        uiText_Chose3.enabled = false;
    }
    void ShowButton()
    {
        //Debug.Log("shw");
        if (isChinese == 0)
        {
            uiText_Chose1.text = chose1_Chinese[0];
            uiText_Chose2.text = chose2_Chinese[0];
            uiText_Chose3.text = chose3_Chinese[0];
        }
        else {
            uiText_Chose1.text = chose1_English[0];
            uiText_Chose2.text = chose2_English[0];
            uiText_Chose3.text = chose3_English[0];
        }
        Button_A.image.enabled = true;
        Button_A.enabled = true;
        uiText_Chose1.enabled = true;
        Button_B.image.enabled = true;
        Button_B.enabled = true;
        uiText_Chose2.enabled = true;
        Button_C.image.enabled = true;
        Button_C.enabled = true;
        uiText_Chose3.enabled = true;
    }
    public void BTN_backtomainscene()
    {
        SceneManager.LoadScene("MainScene");
        //Application.LoadLevel("MainScene");
    }
}
