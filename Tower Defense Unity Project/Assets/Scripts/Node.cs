using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

	public GameObject building;	
	public BuildingBlueprint bulidingBlueprint;
	public bool isUpgraded = false;

	private Renderer rend;
	private Color startColor;

	private BuildManager buildManager;

    public bool isEnemyNode = false;

	void Start ()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;


    }

	public Vector3 GetBuildPosition ()
	{
		return transform.position + positionOffset;
	}

	void OnMouseDown ()
	{
        if (this.isEnemyNode)
            return;         

		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (building != null)
		{
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.CanBuild)
			return;

		BuildTurret(buildManager.GetTurretToBuild());
	}

    public void HardBuildNode()
    {
        if (this.isEnemyNode)
            return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (building != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

	public bool BuildTurret (BuildingBlueprint blueprint)
	{
        if (!blueprint.GetIsEnemy())
        {
            if (StatsPlayer.Money < blueprint.cost)
            {
                Debug.Log("Not enough money from player!");
                return false;
            }

            StatsPlayer.Money -= blueprint.cost;
        }
        else if (blueprint.GetIsEnemy())
        {
            if (StatsEnemy.Money < blueprint.cost)
            {
                Debug.Log("Not enough money from enemy!");
                return false;
            }

            StatsEnemy.Money -= blueprint.cost;
        }


		GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		building = _turret;

		bulidingBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(BuildManager.instance.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

        return true;
	}

	public void UpgradeTurret()
	{
		if (StatsPlayer.Money < bulidingBlueprint.upgradeCost)
		{
			Debug.Log("Not enough money to upgrade that!");
			return;
		}

		StatsPlayer.Money -= bulidingBlueprint.upgradeCost;

        PlayerBarracks buildingComponent = null;
        if (building.TryGetComponent(out buildingComponent))
        {
            buildingComponent.level++;
        }

		////Get rid of the old building
		//Destroy(building);
        //
		////Build a new one
		//GameObject _building = (GameObject)Instantiate(bulidingBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
		//building = _building;
        //
		//GameObject effect = (GameObject)Instantiate(BuildManager.instance.buildEffect, GetBuildPosition(), Quaternion.identity);
		//Destroy(effect, 5f);
        //
		//isUpgraded = true;
        
		Debug.Log("Turret upgraded!");
	}

	public void SellTurret ()
	{
		StatsPlayer.Money += bulidingBlueprint.GetSellAmount();

		GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Destroy(building);
		bulidingBlueprint = null;
	}

	void OnMouseEnter ()
	{
        if (this.isEnemyNode)
            return;

		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (!buildManager.CanBuild)
			return;

		if (buildManager.PlayerHasMoney)
		{
			rend.material.color = hoverColor;
		} else
		{
			rend.material.color = notEnoughMoneyColor;
		}

	}

	void OnMouseExit ()
	{
		rend.material.color = startColor;
    }

}
