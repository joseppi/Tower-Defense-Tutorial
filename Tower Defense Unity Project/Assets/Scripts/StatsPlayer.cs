using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatsPlayer : MonoBehaviour {

	public static int Money;
	public int startMoney = 400;

	public static int Lives;
	public int startLives = 5;

	public static int Rounds;
    public static int UnitsAlive;

    public static List<GameObject> playerBarracks = new List<GameObject>();

	void Start ()
	{
		Money = startMoney;
		Lives = startLives;

		Rounds = 0;
	}

    private void Update()
    {        
        InvokeRepeating("UpdateUnitsAlive", 0f, 0.5f); //This function should be in GameMaster Insteads
    }


    void UpdateUnitsAlive()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); //Extremely Suboptimal. Making an empty child and putting all the enemies there should do the trick.
        GameObject[] friendlies = GameObject.FindGameObjectsWithTag("Friendly");
        UnitsAlive = enemies.Length + friendlies.Length;
    }
}
