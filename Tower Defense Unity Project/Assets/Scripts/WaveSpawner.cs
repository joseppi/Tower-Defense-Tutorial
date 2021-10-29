using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour {

	public List<Wave> waves;

	private Transform spawnPoint;
  
    private GameManager gameManager;

    public GameObject canvasSpawner;

	public int waveIndex = 0;

    public bool isSpawning = false;       

    private void Start()
    {
        spawnPoint = this.transform;
        gameManager = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameManager>();
    }

    private void OnMouseOver()
    {
        canvasSpawner.SetActive(true);
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
            StartCoroutine(SpawnEachWave(wave)); //This needs optimization.
            yield return new WaitForSeconds(1f / wave.rate);
        }            
        isSpawning = false;        
    }

    public IEnumerator SpawnEachWave(Wave wave)
    {
        for (int i = 0; i < wave.count; i++)
        {
            wave.GetUnit().GetComponent<UnitMovement>().SetPath(wave.path);                                    
            SpawnEnemy(wave);
            
            //Debug.Log(wave.GetUnit().GetComponent<UnitMovement>().wayPointsPath);
            yield return new WaitForSeconds(1f / wave.rate);
        }
    }

	void SpawnEnemy (Wave wave)
	{
        GameObject obj = Instantiate(wave.GetUnit(), spawnPoint.position, spawnPoint.rotation);
        obj.GetComponent<Unit>().level = wave.level;
        obj.GetComponent<Unit>().UpdateLevelUp();
	}

}
