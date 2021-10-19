using UnityEngine;
using System.Collections;

[System.Serializable]
public class BuildingBlueprint {

	public GameObject prefab;
	public int cost;

	public GameObject upgradedPrefab;
	public int upgradeCost;

    private bool isEnemy = false;

	public int GetSellAmount ()
	{
		return cost / 2;
	}

    public void setToEnemy(bool isEnemy) { this.isEnemy = isEnemy; }
    public bool GetIsEnemy() { return this.isEnemy; }

}
