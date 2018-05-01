using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour {

    #region Fields
    UIButtons b;
    MoneyManager mm;
    public GameObject visualAchievement;
    public GameObject achievementPrefab;
    #endregion

    //Start achievement Queue
    Queue<IEnumerator> achievementQueue = new Queue<IEnumerator>();
    //End achievement Queue

    #region Properties
    //Access an object without an instance of an object
    private static AchievementManager instance;
    public static AchievementManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<AchievementManager>();
            }
            return AchievementManager.instance;
        }
    }
    #endregion

    public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

    #region Methods
    // Use this for initialization
    void Start()
    {
        mm = GameObject.Find("GameManager").GetComponent<MoneyManager>();
        StartCoroutine(Process());
        Txt2Achievement.ReadFile(achievements, achievementPrefab);
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EarnAchievement("Press Space");
        }

        if (mm.Current_Player_Cash >= 2147483647)
        {
            EarnAchievement("Integer Overflow");
        }

        if (achievements["Press Space"].Unlocked && achievements["Four!"].Unlocked && achievements["Upgrayedd"].Unlocked && achievements["Integer Overflow"].Unlocked)
        {
            EarnAchievement("Donesies");
        }
    }

    public void EarnAchievement(string title)
    {
        if (achievements[title].EarnAchievement())
        {
            achievementQueue.Enqueue(HideAchievement(title));
        }
    }

    public IEnumerator HideAchievement(string title)
    {
        GameObject achievement = Instantiate(visualAchievement);
        SetAchievementInfo("AchievementsCanvas", achievement, title);
        yield return new WaitForSeconds(5f);
        Destroy(achievement);
    }

    private IEnumerator Process()
    {
        while (true)
        {
            if (achievementQueue.Count > 0)
                yield return StartCoroutine(achievementQueue.Dequeue());
            else
                yield return null;
        }
    }

    public void SetAchievementInfo(string parent, GameObject achievement, string title)
    {
        achievement.transform.SetParent(GameObject.Find(parent).transform);
        achievement.transform.localScale = new Vector3(1, 1, 1);
        achievement.transform.GetChild(1).GetComponent<Text>().text = "" + title;
        achievement.transform.GetChild(2).GetComponent<Text>().text = "" + achievements[title].Description;
    }
    #endregion
}