using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

    #region Fields
    MoneyManager mm;
    private GameObject _collectorRef;
    private ulong _collisions_remaining;
    private ulong _collector_upgrade_level;
    private ulong _ball_upgrade_level;
    public ulong Collisions;
    #endregion

    #region Methods
    private void Start()
    {
        mm = GameObject.Find("GameManager").GetComponent<MoneyManager>();
        this._collisions_remaining = Collisions;
        _ball_upgrade_level = 1;
    }

    public ulong Collisions_Remaining
    {
        get { return _collisions_remaining; }
        set { _collisions_remaining = value; }
    }

    public ulong Ball_upgrade_level
    {
        get { return _ball_upgrade_level; }
        set { _ball_upgrade_level = value; }
    }

    public Collector(ulong collisions_remaining, ulong upgrade_level, GameObject collectorRef)
    {
        this.name = name;
        this._collisions_remaining = collisions_remaining;
        this._collector_upgrade_level = upgrade_level;
        this._collectorRef = collectorRef;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (this._collisions_remaining >= _ball_upgrade_level)
            {
                this._collisions_remaining -= _ball_upgrade_level;
                mm.Current_Player_Cash += (mm.Collision_value * _ball_upgrade_level);
                mm.Player_Cash.text = "$" + mm.Current_Player_Cash;
                mm.Cash_Remaining -= (mm.Collision_value * _ball_upgrade_level);
                
                mm.Cash_Remaining_Txt.text = "$" + mm.Cash_Remaining;
            }
        }
    }
    #endregion
}
