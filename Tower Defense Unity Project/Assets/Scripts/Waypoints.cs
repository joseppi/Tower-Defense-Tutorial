using UnityEngine;

public class Waypoints : MonoBehaviour {

	public static Transform[] IAPoints;
    public static Transform[] playerPointsMid;
    public static Transform[] playerPointsLeft;
    public static Transform[] playerPointsRight;

    public GameObject IAPointsGO;
    public GameObject playerPointsMidGO;
    public GameObject playerPointsLeftGO;
    public GameObject playerPointsRightGO;

    void Awake()
    {
        playerPointsMid = new Transform[playerPointsMidGO.transform.childCount];
        for (int i = 0; i < playerPointsMid.Length; i++)
        {
            playerPointsMid[i] = playerPointsMidGO.transform.GetChild(i);
        }
        playerPointsLeft = new Transform[playerPointsLeftGO.transform.childCount];
        for (int i = 0; i < playerPointsLeft.Length; i++)
        {
            playerPointsLeft[i] = playerPointsLeftGO.transform.GetChild(i);
        }
        playerPointsRight = new Transform[playerPointsRightGO.transform.childCount];
        for (int i = 0; i < playerPointsRight.Length; i++)
        {
            playerPointsRight[i] = playerPointsRightGO.transform.GetChild(i);
        }
    }
}
