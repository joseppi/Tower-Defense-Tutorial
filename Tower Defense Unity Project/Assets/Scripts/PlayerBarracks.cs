using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarracks : MonoBehaviour
{
    GameObject[] spawners;
    public Wave farmWave;    

    public void AddFriendlies()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");

        for (int i = 0; i < spawners.Length; i++)
        {
            if (spawners[i].name.ToString().Contains("Player")) //This should be a tag instead of a name. Needs optimization
            {
                WaveSpawner it_Spawner = spawners[i].GetComponent<WaveSpawner>();

                it_Spawner.AddEntity(farmWave);
            }
        }
    }
}
