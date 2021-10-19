using UnityEngine;
using System.Collections;

public class StatsEnemy : MonoBehaviour {

	public static int Money;
	public int startMoney = 400;

	public static int Lives;
	public int startLives = 20;

	public static int Rounds;    

	void Start ()
	{
		Money = startMoney;
		Lives = startLives;

		Rounds = 0;
	}

    private void Update()
    {
        
    }

}
