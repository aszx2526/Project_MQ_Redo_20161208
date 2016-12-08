using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class onHitUI : MonoBehaviour {
    public float riseSpeed;
    public float fadeSpeed;
    public float beBigSpeed;
    public GameObject[] myBigHitNumString;
    public GameObject[] myBigHitNumString1_Child;
    public GameObject[] myBigHitNumString2_Child;
    public Sprite[] myNumSprite;
    //---------
    public GameObject myFather;

    //public float myScalecontrol;
    public bool isTwoOrThree;
    public int myBigHitValue;
    public int isBigHit;

    bool myIsBigest;


    public int s;
    public float b;
    public float myEffectWaitTime;
    float myEffectWaitTimer;

    float myEffectkillTimer = 0;//普攻0.5秒自殺
    public bool isChangeScal;
    public float myScaleValue;
    // Use this for initialization
    void Start () {
        myFather = transform.parent.gameObject;
        transform.parent = GameObject.Find("Canvas").transform;
        transform.position = Camera.main.WorldToScreenPoint(myFather.transform.position);

        Vector3 rotate = GetComponent<RectTransform>().eulerAngles;
        rotate = Vector3.zero;
        GetComponent<RectTransform>().eulerAngles = rotate;


        if (isChangeScal) {
            Vector3 myscal = transform.localScale;
            myscal.x = myScaleValue;
            myscal.y = myscal.x;
            transform.localScale = myscal;
        }
        //s = gameObject.GetComponentInChildren<Text>().fontSize;
        //if()
        //myBigHitValue = Random.Range(0, 1000);
        if (isBigHit == 0) { }
        else{
            myBigHitValueCheckFN();
        }
        
    }

    // Update is called once per frame
    void Update () {

        /*Vector2 Posy =  gameObject.GetComponent<RectTransform>().anchoredPosition;
        Posy.y += Time.deltaTime* Random.Range(riseSpeed,riseSpeed+5);
        gameObject.GetComponent<RectTransform>().anchoredPosition = Posy;*/
        /*
        Color c = gameObject.GetComponent<Image>().color;
        Color c2 = gameObject.GetComponentInChildren<Text>().color;
        
        float f = Random.Range(fadeSpeed, fadeSpeed + 2);
        c.a -= Time.deltaTime * f;
        c2.a -= Time.deltaTime * f;
        gameObject.GetComponent<Image>().color = c;
        */
        //        gameObject.GetComponentInChildren<Text>().color = c2;

        //gameObject.GetComponentInChildren<Text>().fontSize=0;
        //b += Time.deltaTime*beBigSpeed;
        /*if (b >= s) { gameObject.GetComponentInChildren<Text>().fontSize = s; }
        else {
            gameObject.GetComponentInChildren<Text>().fontSize = (int)b;
        }*/
        somethingInUpdate();
       /* if (myEffectWaitTimer >= myEffectWaitTime) {
            
        }
        else {
            myEffectWaitTimer += Time.deltaTime;
        }*/

    }
    public void somethingInUpdate() {

        Color c = gameObject.GetComponent<Image>().color;
        float f = Random.Range(fadeSpeed, fadeSpeed + 2);
        c.a -= Time.deltaTime * f;
        gameObject.GetComponent<Image>().color = c;

        myEffectkillTimer += Time.deltaTime;


        if (isBigHit == 0)
        {
            if (myEffectkillTimer > 0.5f)
            {
                Destroy(myFather);
                Destroy(gameObject);
            }
        }
        else {
            if (isTwoOrThree)
            {
                Vector3 myscale = myBigHitNumString[1].GetComponent<RectTransform>().localScale;
                if (myIsBigest)
                {
                    if (myEffectWaitTimer > myEffectWaitTime) {
                        Vector2 Posy = myBigHitNumString[1].GetComponent<RectTransform>().anchoredPosition;
                        Posy.y += Time.deltaTime * Random.Range(riseSpeed, riseSpeed + 25);
                        myBigHitNumString[1].GetComponent<RectTransform>().anchoredPosition = Posy;
                        Color c2 = myBigHitNumString2_Child[0].GetComponent<Image>().color;
                        c2.a -= Time.deltaTime * f;
                        for (int a = 0; a < 3; a++)
                        {
                            myBigHitNumString2_Child[a].GetComponent<Image>().color = c2;
                        }
                        if (c2.a <= 0)
                        {
                            Destroy(myFather);
                            Destroy(gameObject);
                        }
                    }
                    else {
                        myEffectWaitTimer += Time.deltaTime;
                    }
                    myscale.x = 1.8f;
                    myscale.y = 1.8f;
                    myBigHitNumString[1].GetComponent<RectTransform>().localScale = myscale;
                }
                else {
                    if (myscale.y >= 2)
                    {
                        myIsBigest = true;
                    }
                    else {
                        myscale.x += Time.deltaTime * f * 20;
                        myscale.y += Time.deltaTime * f * 20;
                        myBigHitNumString[1].GetComponent<RectTransform>().localScale = myscale;
                    }
                }
               
            }
            else {
                Vector3 myscale = myBigHitNumString[0].GetComponent<RectTransform>().localScale;
                if (myIsBigest)
                {
                    if (myEffectWaitTimer > myEffectWaitTime) {
                        Vector2 Posy = myBigHitNumString[0].GetComponent<RectTransform>().anchoredPosition;
                        Posy.y += Time.deltaTime * Random.Range(riseSpeed, riseSpeed + 25);
                        myBigHitNumString[0].GetComponent<RectTransform>().anchoredPosition = Posy;
                        Color c2 = myBigHitNumString1_Child[0].GetComponent<Image>().color;
                        c2.a -= Time.deltaTime * f;
                        for (int a = 0; a < 2; a++)
                        {
                            myBigHitNumString1_Child[a].GetComponent<Image>().color = c2;
                        }
                        if (c2.a <= 0)
                        {
                            Destroy(myFather);
                            Destroy(gameObject);
                        }
                    }
                    else {
                        myEffectWaitTimer += Time.deltaTime;
                    }
                    myscale.x = 1.8f;
                    myscale.y = 1.8f;
                    myBigHitNumString[0].GetComponent<RectTransform>().localScale = myscale;
                }
                else {
                    if (myscale.y >= 2)
                    {
                        myIsBigest = true;
                    }
                    else {
                        myscale.x += Time.deltaTime * f * 20;
                        myscale.y += Time.deltaTime * f * 20;
                        myBigHitNumString[0].GetComponent<RectTransform>().localScale = myscale;

                    }
                }
               
            }
        }
    }
    public void myBigHitValueCheckFN() {
        if (myBigHitValue > 99) {//三位數
            isTwoOrThree = true;
            myBigHitNumString[0].SetActive(false);//把另外一個位數的關掉
            //string numcheck = myBigHitValue.ToString();
            for (int a = 0; a < 10; a++) {
                if (myBigHitValue.ToString().Substring(0, 1) == a.ToString()) { myBigHitNumString2_Child[0].GetComponent<Image>().sprite = myNumSprite[a];
                    Vector2 aaa = myBigHitNumString2_Child[0].GetComponent<RectTransform>().localScale;
                    float myrandomscal = Random.Range(1.0f, 2.0f);
                    aaa.x = myrandomscal;
                    aaa.y = myrandomscal;
                    myBigHitNumString2_Child[0].GetComponent<RectTransform>().localScale = aaa;
                }
                if (myBigHitValue.ToString().Substring(1, 1) == a.ToString()) { myBigHitNumString2_Child[1].GetComponent<Image>().sprite = myNumSprite[a];
                    Vector2 aaa = myBigHitNumString2_Child[1].GetComponent<RectTransform>().localScale;
                    float myrandomscal = Random.Range(1.0f, 2.0f);
                    aaa.x = myrandomscal;
                    aaa.y = myrandomscal;
                    myBigHitNumString2_Child[0].GetComponent<RectTransform>().localScale = aaa;
                }
                if (myBigHitValue.ToString().Substring(2, 1) == a.ToString()) { myBigHitNumString2_Child[2].GetComponent<Image>().sprite = myNumSprite[a];
                    Vector2 aaa = myBigHitNumString2_Child[2].GetComponent<RectTransform>().localScale;
                    float myrandomscal = Random.Range(1.0f, 2.0f);
                    aaa.x = myrandomscal;
                    aaa.y = myrandomscal;
                    myBigHitNumString2_Child[0].GetComponent<RectTransform>().localScale = aaa;
                }
            }
        }
        else {//兩位數
            isTwoOrThree = false;
            myBigHitNumString[1].SetActive(false);
            for (int a = 0; a < 10; a++)
            {
                if (myBigHitValue.ToString().Substring(0, 1) == a.ToString()) { myBigHitNumString1_Child[0].GetComponent<Image>().sprite = myNumSprite[a];
                    Vector2 aaa = myBigHitNumString1_Child[0].GetComponent<RectTransform>().localScale;
                    float myrandomscal = Random.Range(1.0f, 2.0f);
                    aaa.x = myrandomscal;
                    aaa.y = myrandomscal;
                    myBigHitNumString2_Child[0].GetComponent<RectTransform>().localScale = aaa;
                }
                if (myBigHitValue.ToString().Substring(1, 1) == a.ToString()) { myBigHitNumString1_Child[1].GetComponent<Image>().sprite = myNumSprite[a];
                    Vector2 aaa = myBigHitNumString1_Child[1].GetComponent<RectTransform>().localScale;
                    float myrandomscal = Random.Range(1.0f, 2.0f);
                    aaa.x = myrandomscal;
                    aaa.y = myrandomscal;
                    myBigHitNumString2_Child[0].GetComponent<RectTransform>().localScale = aaa;
                }
               
            }
        }
    }
}
