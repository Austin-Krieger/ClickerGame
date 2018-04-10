using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement {

    private string _name;
    private GameObject _achievementRef;
    private bool _unlocked;
    private string _description;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
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

    public Achievement(string name, string description, GameObject achievementRef)
    {
        this.Name = name;
        this._description = description;
        this._unlocked = false;
        this._achievementRef = achievementRef;
    }

    public bool EarnAchievement()
    {
        if (!_unlocked)
        {
            _achievementRef.transform.GetChild(3).GetComponent<Text>().text = "Complete";
            _unlocked = true;
            return true;
        }
        return false;
    }
}
