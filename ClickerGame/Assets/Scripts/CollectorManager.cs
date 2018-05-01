using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorManager : MonoBehaviour {

    #region Fields
    MoneyManager mm;
    public GameObject[] collectors;
    public GameObject[] collectorTexts;
    #endregion

    #region Methods
    // Use this for initialization
    void Start () {
        mm = GameObject.Find("GameManager").GetComponent<MoneyManager>();
	}

    private void Update()
    {
        if (collectors.Length > 0)
        {
            for (int i = 0; i < collectors.Length; i++)
            {
                collectorTexts[i].GetComponent<Text>().text = "" + collectors[i].GetComponent<Collector>().Collisions_Remaining;
            }
        }
    }
    #endregion
}
