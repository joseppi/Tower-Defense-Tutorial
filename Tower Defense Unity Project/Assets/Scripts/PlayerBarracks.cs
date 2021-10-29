using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarracks : MonoBehaviour
{
    GameObject[] spawners;
    public enum EnemyType
    {
        UNDEFINED,
        TOUGH,
        FAST,
        SIMPLE
    }

    public EnemyType enemyType = EnemyType.UNDEFINED;
    public Wave farmWave;
    public UnitMovement.WayPoints path = UnitMovement.WayPoints.UNDEFINED;
    public int level = 1;
    
    public void Awake()
    {
        StatsPlayer.playerBarracks.Add(gameObject);
    }

    public void Start()
    {
        
        switch (enemyType)
        {
            case EnemyType.UNDEFINED:
                farmWave.SetUnitPrefab(Resources.Load("Player/PlayerUnits/Tough/Friendly_Tough") as GameObject);                
                break;
            case EnemyType.TOUGH:
                farmWave.SetUnitPrefab(Resources.Load("Player/PlayerUnits/Tough/Friendly_Tough") as GameObject);
                break;
            case EnemyType.FAST:
                farmWave.SetUnitPrefab(Resources.Load("Player/PlayerUnits/Fast/Friendly_Fast") as GameObject);
                break;
            case EnemyType.SIMPLE:
                farmWave.SetUnitPrefab(Resources.Load("Player/PlayerUnits/Simple/Friendly_Simple") as GameObject);                
                break;
        }        
    }

    public void AddFriendlies()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");

        for (int i = 0; i < spawners.Length; i++)
        {
            if (spawners[i].name.ToString().Contains("Player")) //This should be a tag instead of a name. Needs optimization
            {
                WaveSpawner it_Spawner = spawners[i].GetComponent<WaveSpawner>();
                farmWave.path = this.path;
                farmWave.level = this.level;
                it_Spawner.AddEntity(farmWave); 
            }
        }
    }    
}