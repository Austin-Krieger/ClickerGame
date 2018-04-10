using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtons : MonoBehaviour {

    //Rename me to UIButtons.cs

    public GameObject ballPrefab;
    MoneyManager mm;

	// Use this for initialization
	void Start () {
        mm = GameObject.Find("GameManager").GetComponent<MoneyManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddBall()
    {
        if (mm.Current_Player_Cash >= 1000)
        {
            mm.Current_Player_Cash -= 1000;
            GameObject ball = (GameObject)Instantiate(ballPrefab);
            mm.Player_Cash.text = "$" + mm.Current_Player_Cash;
        }
    }

}
