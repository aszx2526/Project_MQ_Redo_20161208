using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMQ_WinFlyInLastFrame : MonoBehaviour {
    public bool isLastFram;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void myWinFlyLastFram()
    {
        isLastFram = true;
        this.gameObject.SetActive(false);
    }
}
