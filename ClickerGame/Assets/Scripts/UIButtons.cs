using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour {

    #region Fields
    MoneyManager mm;
    CollectorManager cm;
    Collector c;
    public GameObject ballPrefab;
    private ulong _collision_count;
    private ulong _upgrade_cost;
    public GameObject UpgradeCostTxt;
    GameObject[] allcollectors;
    private GameObject Cash_remaining_Txt;
    private ulong _upgrade_tier = 5;
    private ulong _upgrade_tier_visual = 1;
    public GameObject UpgradeButton;
    private bool _automate_checked;
    private int _ball_upgrade_count = 1;
    #endregion

    #region Methods
    // Use this for initialization
    void Start()
    {
        _upgrade_cost = 1000;
        Cash_remaining_Txt = GameObject.Find("CashRemainingTxt");
        allcollectors = GameObject.FindGameObjectsWithTag("Collector");
        mm = GameObject.Find("GameManager").GetComponent<MoneyManager>();
        StartCoroutine("IncCounters");
    }

    IEnumerator Automate()
    {
        while (_automate_checked == true)
        {
            yield return new WaitForSeconds(0);
            UpgradeCollectors();
        }
    }

    IEnumerator IncCounters()
    {
        while (true)
        {
            yield return new WaitForSeconds(_upgrade_tier);
            // Increase collisions and update cash remaining
            Calculate_collisions_remaining(1);
            Update_player_cash();
        }
    }

    public void AddBall()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length < 10)
        {
            if (mm.Current_Player_Cash >= 1000)
            {
                mm.Current_Player_Cash -= 1000;
                GameObject ball = (GameObject)Instantiate(ballPrefab);

                Calculate_collisions_remaining(0);

                Update_player_cash();

                this.gameObject.GetComponent<AchievementManager>().EarnAchievement("Four!");
            }
        } else
        {
            GameObject.Find("AddBallBtn").SetActive(false);
        }
    }

    public void UpgradeBall()
    {
        if (_ball_upgrade_count < 20)
        {
            if (mm.Current_Player_Cash >= _upgrade_cost)
            {
                mm.Current_Player_Cash -= _upgrade_cost;

                Calculate_collisions_remaining(0);

                Update_player_cash();

                Calculate_upgrade_cost();

                for (int i = 0; i < allcollectors.Length; i++)
                {
                    allcollectors[i].gameObject.GetComponent<Collector>().Ball_upgrade_level += 1;
                }

                _ball_upgrade_count++;
            }
        } else
        {
            GameObject.Find("UpgradeBallBtn").SetActive(false);
        }
    }

    public void UpgradeCollectors()
    {
        if (mm.Current_Player_Cash >= _upgrade_cost)
        {
            // increase upgrade tier
            if (_upgrade_tier > 0)
            {
                _upgrade_tier--;
            }

            _upgrade_tier_visual += 1;

            if (_upgrade_tier_visual > 5)
            {
                UpgradeButton.GetComponentInChildren<Text>().text = "God Tier " + (_upgrade_tier_visual - 5);
            }
            else
            {
                UpgradeButton.GetComponentInChildren<Text>().text = "Tier " + _upgrade_tier_visual;
            }

            mm.Collision_value += 20000;
            mm.Current_Player_Cash -= _upgrade_cost;

            Calculate_collisions_remaining(0);

            Update_player_cash();

            Calculate_upgrade_cost();

            this.gameObject.GetComponent<AchievementManager>().EarnAchievement("Upgrayedd");
        }
    }

    public void Automate_Upgrades()
    {
        if (_automate_checked == false)
        {
            _automate_checked = true;
            StartCoroutine("Automate");
        }
        else
        {
            _automate_checked = false;
        }
    }

    private void Calculate_collisions_remaining(ulong inc_by)
    {
        // reset collision count
        _collision_count = 0;

        for (int i = 0; i < allcollectors.Length; i++)
        {
            allcollectors[i].gameObject.GetComponent<Collector>().Collisions_Remaining += inc_by;
            _collision_count += allcollectors[i].gameObject.GetComponent<Collector>().Collisions_Remaining;
        }
    }

    private void Update_player_cash()
    {
        mm.Player_Cash.text = "$" + mm.Current_Player_Cash;

        mm.Cash_Remaining = (_collision_count * mm.Collision_value);
        mm.Cash_Remaining_Txt.GetComponent<Text>().text = "$" + mm.Cash_Remaining;
    }

    private void Calculate_upgrade_cost()
    {
        _upgrade_cost += 5000;
        UpgradeCostTxt.gameObject.GetComponent<Text>().text = "$" + _upgrade_cost;
    }
    #endregion
}
