using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onLockForHidden : MonoBehaviour
{
    public bool isTimeToDisappear;
    public bool isDisappeared;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDisappeared && isTimeToDisappear)
        {
            Color a = GetComponent<Image>().color;
            a.a -= Time.deltaTime;
            GetComponent<Image>().color = a;
            if (a.a <= 0)
            {
                isDisappeared = true;
                gameObject.SetActive(false);
            }
        }
    }
}
