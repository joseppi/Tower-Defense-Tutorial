using UnityEngine;
using System.Collections;
using UnityEngine.AI;

[RequireComponent(typeof(Unit))]
public class UnitMovement : MonoBehaviour {

	private Transform target;
	private int wavepointIndex = 0;

	private Unit unit;
    private NavMeshAgent agent;

	void Start()
	{
		unit = GetComponent<Unit>();    
        switch (this.tag)
        {
            case "Enemy":
                target = WaypointsIA.IAPoints[0];
                break;
            case "Friendly":                
                target = WaypointsPlayer.playerPoints[0];
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
                    GetNextWaypoint(Waypoints.playerPoints);
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
