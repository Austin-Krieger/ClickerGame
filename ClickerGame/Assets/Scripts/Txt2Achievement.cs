using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Txt2Achievement : MonoBehaviour {

    #region Fields
    AchievementManager A;
    private Achievement myAchievement;
    private string lines;
    private static string[] category;
    private static string[] title;
    private static string[] description;
    private static int achievement_Count = 5;
    #endregion

    #region Methods
    public static void ReadFile(Dictionary<string, Achievement> achievements, GameObject achievementPrefab)
    {
        string path = Application.dataPath;
        path = path + "/Resources/Achievements.txt";

        StreamReader reader = new StreamReader(path);
        int i = 0;

        string[] category = new string[achievement_Count];
        string[] title = new string[achievement_Count];
        string[] description = new string[achievement_Count];

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] SplitInput = line.Split(new string[] { "; " }, StringSplitOptions.None);

            try
            {
                category[i] = SplitInput[0];
                title[i] = SplitInput[1];
                description[i] = SplitInput[2];
            }
            catch
            {
                //Do Nothing
            }

            i++;
        }

        for (int b = 0; b < achievement_Count; b++)
        {
            CreateAchievement(achievements, achievementPrefab, category[b], title[b], description[b]);
        }

        reader.Close();
    }

    public static void CreateAchievement(Dictionary<string, Achievement> achievements, GameObject achievementPrefab, string parent, string title, string description)
    {
        GameObject achievement = (GameObject)Instantiate(achievementPrefab);
        Achievement newAchievement = new Achievement(title, description, achievement);
        achievements.Add(title, newAchievement);
    }
    #endregion
}
