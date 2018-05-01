using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement {

    #region Fields
    private string _title;
    private GameObject _achievementRef;
    private bool _unlocked;
    private string _description;
    #endregion

    #region Properties
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public bool Unlocked
    {
        get { return _unlocked; }
        set { _unlocked = value; }
    }
    #endregion

    #region Methods
    public Achievement(string title, string description, GameObject achievementRef)
    {
        this._title = title;
        this._description = description;
        this._unlocked = false;
        this._achievementRef = achievementRef;
    }

    public bool EarnAchievement()
    {
        if (!_unlocked)
        {
            _unlocked = true;
            return true;
        }
        return false;
    }
    #endregion
}
