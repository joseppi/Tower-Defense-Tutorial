using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public GameObject buildEffect;
	public GameObject sellEffect;

	private BuildingBlueprint buildingToBuild;
	private Node selectedNode;

	public NodeUI nodeUI;

	public bool CanBuild { get { return buildingToBuild != null; } }
	public bool PlayerHasMoney { get { return StatsPlayer.Money >= buildingToBuild.cost; } }
    public bool EnemyHasMoney { get { return StatsEnemy.Money >= buildingToBuild.cost; } }

    public void SelectNode (Node node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}

		selectedNode = node;
		buildingToBuild = null;

		nodeUI.SetTarget(node);
	}

	public void DeselectNode()
	{
		selectedNode = null;
		nodeUI.Hide();
	}

	public void SelectBuildingToBuild (BuildingBlueprint building)
	{        
        buildingToBuild = building;
		DeselectNode();
	}

	public BuildingBlueprint GetTurretToBuild ()
	{
		return buildingToBuild;
	}

}
