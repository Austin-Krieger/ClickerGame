using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

    public Text Player_Cash;
    private int _current_player_cash = 1000;
    //private static int _earned_cash;

    public int Current_Player_Cash
    {
        get { return _current_player_cash; }
        set { _current_player_cash = value; }
    }

    /*public int Earned_Cash
    {
        get { return _earned_cash; }
        set { _earned_cash = value; }
    }*/

    // Use this for initialization
    void Start () {
        Player_Cash = GameObject.Find("CurrentCashTxt").GetComponent<Text>();
        Player_Cash.text = "$" + _current_player_cash;
    }
}
