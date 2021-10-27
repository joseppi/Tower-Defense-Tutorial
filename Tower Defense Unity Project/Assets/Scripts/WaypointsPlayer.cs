using UnityEngine;

public class WaypointsPlayer : Waypoints
{
	void Awake ()
	{
		playerPointsMid = new Transform[transform.childCount];
		for (int i = 0; i < playerPointsMid.Length; i++)
		{
			playerPointsMid[i] = transform.GetChild(i);
		}
	}
}
