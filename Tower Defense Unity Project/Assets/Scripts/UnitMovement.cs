using UnityEngine;
using System.Collections;
using UnityEngine.AI;

[RequireComponent(typeof(Unit))]
public class UnitMovement : MonoBehaviour {

	private Transform target;
	private int wavepointIndex = 0;
    public enum WayPoints
    {
        UNDEFINED,
        MID,
        LEFT,
        RIGHT
    }

    public WayPoints wayPointsPath = WayPoints.UNDEFINED;

	private Unit unit;

    public void SetPath(WayPoints path)
    {
        this.wayPointsPath = path;        
    }

    void Start()
	{
		unit = GetComponent<Unit>();    
        switch (this.tag)
        {
            case "Enemy":
                target = Waypoints.IAPoints[0];
                break;
            case "Friendly":
                switch (wayPointsPath)
                {
                    case WayPoints.UNDEFINED:
                        target = Waypoints.playerPointsMid[0];
                        break;
                    case WayPoints.MID:
                        target = Waypoints.playerPointsMid[0];
                        break;
                    case WayPoints.LEFT:
                        target = Waypoints.playerPointsLeft[0];
                        break;
                    case WayPoints.RIGHT:
                        target = Waypoints.playerPointsRight[0];
                        break;
                }                
                break;
        }
    }

    void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * unit.speed * Time.deltaTime, Space.World);
        
		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
            switch(this.tag)
            {
                case "Enemy":
                    GetNextWaypoint(Waypoints.IAPoints);
                    break;
        
                case "Friendly":
                    switch (wayPointsPath)
                    {
                        case WayPoints.UNDEFINED:
                            GetNextWaypoint(Waypoints.playerPointsMid);
                            break;
                        case WayPoints.MID:
                            GetNextWaypoint(Waypoints.playerPointsMid);
                            break;
                        case WayPoints.LEFT:
                            GetNextWaypoint(Waypoints.playerPointsLeft);
                            break;
                        case WayPoints.RIGHT:
                            GetNextWaypoint(Waypoints.playerPointsRight);
                            break;
                    }
                    
                    break;
            }

        }

        unit.speed = unit.startSpeed;
    }

    void GetNextWaypoint(Transform[] points)
	{
		if (wavepointIndex >= points.Length - 1)
		{
			EndPath(this.tag);
			return;
		}

		wavepointIndex++;
		target = points[wavepointIndex];
	}

	void EndPath(string tag)
	{
        switch(tag)
        {
            case "Enemy":
                StatsPlayer.Lives--;
                break;

            case "Friendly":
                StatsEnemy.Lives--;
                break;
        }
		
		StatsPlayer.UnitsAlive--;
        
		Destroy(gameObject);
	}

}
