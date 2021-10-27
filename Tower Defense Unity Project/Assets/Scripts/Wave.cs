using UnityEngine;

[System.Serializable]
public class Wave {

	GameObject unit;
	public int count;
	public float rate;    
    public UnitMovement.WayPoints path = UnitMovement.WayPoints.UNDEFINED;
    public int level = 1;

    public void SetUnitPrefab(GameObject prefab)
    {
        this.unit = prefab;
    }

    public GameObject GetUnit()
    {
        return this.unit;
    }
}
