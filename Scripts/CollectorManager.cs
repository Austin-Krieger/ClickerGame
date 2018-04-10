using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorManager : MonoBehaviour {

    public GameObject collectorPrefab;
    public GameObject collectorText;
    MoneyManager mm;
    //public GameObject counter;
    //private Text _counter_txt;
    //public GameObject[] collector_game_objects;
    //public int collisions_remaining;
    public GameObject[] collectors;
    
	// Use this for initialization
	void Start () {
        mm = GameObject.Find("GameManager").GetComponent<MoneyManager>();
        collectors = GameObject.FindGameObjectsWithTag("Collector");
        collectorText = GameObject.Find("CC1Txt");
        
        //collector_game_objects = GameObject.FindGameObjectsWithTag("Collector");
        //_counter_txt = counter.GetComponent<Text>();
        //_counter_txt.text = ("" + collisions_remaining);

        //CreateCollector("LevelDesign", "collector01", 25, 1);
	}

    private void Update()
    {
        if (collectors.Length > 0)
        {
            for (int i = 0; i < collectors.Length; i++)
            {
                collectorText.GetComponent<Text>().text = "" + collectors[i].GetComponent<Collector>().Collisions_Remaining;

                if (collectors[i].GetComponent<Collector>().Collisions_Remaining < 1)
                {
                    Destroy(collectors[i]);
                }
            }
        }
    }

    /*public void CreateCollector(string parent, string name, int collisions_remaining, int upgrade_level)
    {
        GameObject collector = (GameObject)Instantiate(collectorPrefab);
        //coresponding text element.GetComponent<Text>().text = Collector[name].collisions_remaining
        collector.transform.SetParent(GameObject.Find(parent).transform);
        collector.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }*/

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < collector_game_objects.Length; i++)
        {
            if (collision.gameObject.CompareTag("Ball") && collisions_remaining > 1)
            {
                _earned_cash += 20;
                collisions_remaining--;
                _counter_txt.text = ("" + collisions_remaining);
                _player_cash.text = ("$" + (current_player_cash + _earned_cash));
            }
            else
            {
                Destroy(counter.transform.gameObject);
                Destroy(collector_game_objects[i].transform.gameObject);
            }
        }
    }*/

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            mm.Current_Player_Cash += 20;
            mm.Player_Cash.text = "$" + mm.Current_Player_Cash;
        }
    }*/
}
