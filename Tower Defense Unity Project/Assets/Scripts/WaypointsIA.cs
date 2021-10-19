using UnityEngine;

public class WaypointsIA : Waypoints
{
	void Awake ()
	{
		IAPoints = new Transform[transform.childCount];
		for (int i = 0; i < IAPoints.Length; i++)
		{
			IAPoints[i] = transform.GetChild(i);
		}
	}

}
