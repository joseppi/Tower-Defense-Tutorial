using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarracks : MonoBehaviour
{
    GameObject[] spawners;
    public Wave farmWave;

    public void AddEnemies()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner"); //Needs a better way to sort spawners from player and from enemy

        for (int i = 0; i < spawners.Length; i++)
        {
            if (spawners[i].name.ToString().Contains("Enemy"))
            {
                WaveSpawner it_Spawner = spawners[i].GetComponent<WaveSpawner>();

                it_Spawner.AddEntity(farmWave);
            }
        }
    }
}
