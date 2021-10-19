using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Farm : MonoBehaviour {
    
    float currentTime = 0f;

    [Header("Attributes")]
    public float money = 13;
    public float timePerTick = 5;    

    [Header("Unity Setup Fields")]

	public Transform partToRotate;
	public float turnSpeed = 10f;
    public bool isEnemy = false;

    // Use this for initialization
    void Start () {
        currentTime = timePerTick;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime -= 1 * Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;            
            if (isEnemy)
            {
                StatsEnemy.Money += (int)this.money;
            }
            else if (!isEnemy)
            {
                StatsPlayer.Money += (int)this.money;
            }
            
            currentTime = timePerTick;
        }
    }


}
