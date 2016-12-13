using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class onUI_5Skill : MonoBehaviour {
    public float riseSpeed;
    public float fadeSpeed;
    public float beBigSpeed;
    public int s;
    public float b;

    // Use this for initialization
    void Start()
    {
        s = GetComponentInChildren<Text>().fontSize;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Posy = gameObject.GetComponent<RectTransform>().anchoredPosition;
        Posy.y += Time.deltaTime * Random.Range(riseSpeed, riseSpeed + 5);
        gameObject.GetComponent<RectTransform>().anchoredPosition = Posy;

        //Color c = gameObject.GetComponent<Image>().color;
        Color c2 = gameObject.GetComponentInChildren<Text>().color;
        float f = Random.Range(fadeSpeed, fadeSpeed + 2);
        //c.a -= Time.deltaTime * f;
        c2.a -= Time.deltaTime * f;
        //gameObject.GetComponent<Image>().color = c;
        gameObject.GetComponentInChildren<Text>().color = c2;

        gameObject.GetComponentInChildren<Text>().fontSize = 0;
        b += Time.deltaTime * beBigSpeed;
        if (b >= s) { gameObject.GetComponentInChildren<Text>().fontSize = s; }
        else {
            gameObject.GetComponentInChildren<Text>().fontSize = (int)b;
        }
        if (c2.a <= 0)
        {
            Destroy(gameObject);
        }

    }
}
