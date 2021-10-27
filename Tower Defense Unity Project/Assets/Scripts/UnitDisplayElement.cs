using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitDisplayElement : MonoBehaviour
{
    public PlayerBarracks barrack;
    public int barracksIndex = -1;

    private void Start()
    {

    }

    public void Update()
    {         
        if (barracksIndex != -1 && barrack == null)
        {
            barrack = StatsPlayer.playerBarracks[barracksIndex].GetComponent<PlayerBarracks>();
        }      
    }
        
    public void SetUnitWaypointsLeft()
    {
        barrack.path = UnitMovement.WayPoints.LEFT;       
    }

    public void SetUnitWaypointsMid()
    {
        barrack.path = UnitMovement.WayPoints.MID;
    }

    public void SetUnitWaypointsRight()
    {
        barrack.path = UnitMovement.WayPoints.RIGHT;
    }


}
