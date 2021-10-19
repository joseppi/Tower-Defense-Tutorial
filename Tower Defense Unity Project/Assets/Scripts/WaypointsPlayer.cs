using UnityEngine;

public class WaypointsPlayer : Waypoints
{

	void Awake ()
	{
		playerPoints = new Transform[transform.childCount];
		for (int i = 0; i < playerPoints.Length; i++)
		{
			playerPoints[i] = transform.GetChild(i);
		}
	}

}
