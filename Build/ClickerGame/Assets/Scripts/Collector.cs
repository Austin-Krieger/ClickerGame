using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

    //private string name;
    private GameObject _collectorRef;
    private int _collisions_remaining;
    private int _upgrade_level;
    MoneyManager mm;
    //CollectorManager cm;

    private void Start()
    {
        mm = GameObject.Find("GameManager").GetComponent<MoneyManager>();
        this._collisions_remaining = 25;
        //cm = GameObject.Find("GameManager").GetComponent<CollectorManager>();
    }

    public int Collisions_Remaining
    {
        get { return _collisions_remaining; }
        set { _collisions_remaining = value; }
    }

    public Collector(int collisions_remaining, int upgrade_level, GameObject collectorRef)
    {
        this.name = name;
        this._collisions_remaining = collisions_remaining;
        this._upgrade_level = upgrade_level;
        this._collectorRef = collectorRef;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            this._collisions_remaining--;
            mm.Current_Player_Cash += 20;
            mm.Player_Cash.text = "$" + mm.Current_Player_Cash;
        }
    }
}
