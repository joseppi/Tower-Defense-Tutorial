using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;
    public Text waveCountdownText;
    public float countdown = 2f;
    public float timeBetweenWaves = 5f;
    GameObject[] spawners;
    int currentRound = -1;
    public static float totalMatchTime = 0;
    public Node farmNode;
    public Node barracksNode;

    void Start ()
	{
        Shop shop = GameObject.Find("Shop").GetComponent<Shop>();
		GameIsOver = false;
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        countdown = timeBetweenWaves;
        Time.timeScale = 4.0f;

        //Hardcoding Player buildings
        farmNode.BuildTurret(shop.farmBuilding);
        barracksNode.BuildTurret(shop.redBarracksBuilding);
    }

	// Update is called once per frame
	void Update () {
		if (GameIsOver)
			return;

		if (StatsPlayer.Lives <= 0)
		{
			EndGame();
		}

        if (StatsEnemy.Lives == 0)
        {
            WinLevel();
        }

        totalMatchTime += Time.deltaTime;

        if (currentRound != StatsPlayer.Rounds && countdown <= .0f) // Start Next Round
        {
            for (int i = 0; i < spawners.Length;i++) //Remove previous waves. This is done like this because its easier to switch to pervious style if needed. Not optimal
            {                
                spawners[i].GetComponent<WaveSpawner>().waves.Clear();
            }

            GameObject[] enemyBarracks = GameObject.FindGameObjectsWithTag("EnemyBarracks");
            for(int i = 0; i < enemyBarracks.Length; i++)
            {
                enemyBarracks[i].GetComponent<EnemyBarracks>().AddEnemies();                
            }

            GameObject[] playerBarracks = GameObject.FindGameObjectsWithTag("PlayerBarracks");
            for (int i = 0; i < playerBarracks.Length; i++)
            {
                //playerBarracks[i].GetComponent<PlayerBarracks>().farmWave.rate += 0.05f; //OBSCURE SHIT CAUSE I SUCK AT DESIGN                                
                playerBarracks[i].GetComponent<PlayerBarracks>().AddFriendlies();                
            }
            currentRound = StatsPlayer.Rounds;
        }

        if (StatsPlayer.UnitsAlive != 0)
        {
            if (countdown == 0)
            {
                countdown = timeBetweenWaves;
                StatsPlayer.Rounds++;
            }
            return;
        }

        if (countdown <= 0.0f)
        {            
            for (int i = 0; i < spawners.Length; i++)
            {
                WaveSpawner it_Spawner = spawners[i].GetComponent<WaveSpawner>();                
                if (it_Spawner.isSpawning == false)
                {
                    it_Spawner.isSpawning = true;
                    StartCoroutine(it_Spawner.SpawnWave());
                }
            }                
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

	void EndGame ()
	{
		GameIsOver = true;
		gameOverUI.SetActive(true);
	}

	public void WinLevel ()
	{
		GameIsOver = true;
		completeLevelUI.SetActive(true);        
	}

}
