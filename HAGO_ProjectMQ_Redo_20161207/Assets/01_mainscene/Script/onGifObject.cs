using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class onGifObject : MonoBehaviour {
    public Image myobject;
    public Sprite[] gif;
    float giftimer;
    public float gifdeltimer;
    public int mygifmod;
    public bool isloop;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        giftimer += Time.deltaTime;
        if (giftimer >= gifdeltimer)
        {
            giftimer = 0;
            if (mygifmod < (gif.Length-1)) { mygifmod++; }
            else {
                if (isloop==false) { mygifmod = 0; }
                else {
                }
            }
        }
        myChangeSprite();

    }
    public void myChangeSprite()
    {
        myobject.sprite = gif[mygifmod];
    }
}
