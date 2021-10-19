using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour {

	public List<Wave> waves;

	private Transform spawnPoint;
  
    private GameManager gameManager;

	public int waveIndex = 0;

    public bool isSpawning = false;    

    private void Start()
    {
        spawnPoint = this.transform;
        gameManager = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameManager>();
    }

    void Update ()
	{

	}

    public void AddEntity(Wave wave)
    {
        waves.Add(wave);
    }

	public IEnumerator SpawnWave ()
	{		       
        for (int y = 0; y < waves.Count;y++)
        {
            Wave wave = waves[y];

            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }        		
        isSpawning = false;
	}

	void SpawnEnemy (GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
	}

}
