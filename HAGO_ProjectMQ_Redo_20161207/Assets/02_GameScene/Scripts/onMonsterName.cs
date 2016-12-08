using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class onMonsterName : MonoBehaviour {
    public GameObject target;
    public Text myNameText;
    public Vector3 Offset;
    // Use this for initialization
    void Start()
    {
        //target = GameObject.Find("Mob");
    }

    // Update is called once per frame
    void Update()
    {
        if (target.gameObject)
        {
            myNameText.transform.position = Camera.main.WorldToScreenPoint(target.GetComponent<Transform>().transform.position) + Offset;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
