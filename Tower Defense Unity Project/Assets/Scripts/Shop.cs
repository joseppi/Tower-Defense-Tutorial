using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    enum ShopItems
    {
        STANDARDTURRET,
        MISSILELAUNCHER,
        LASERBEAMER,
        FARM,
        BLUEBARRACKS,
        REDBARRACKS,
        YELLOWBARRACKS
    }

    [Header("Player")]
    public BuildingBlueprint standardTurret;
	public BuildingBlueprint missileLauncher;
	public BuildingBlueprint laserBeamer;
    public BuildingBlueprint farmBuilding;
    public BuildingBlueprint blueBarracksBuilding;
    public BuildingBlueprint redBarracksBuilding;
    public BuildingBlueprint yellowBarracksBuilding;

    [Header("Enemy")]
    public BuildingBlueprint standardEnemyTurret;
    public BuildingBlueprint missileEnemyLauncher;
    public BuildingBlueprint laserEnemyBeamer;
    public BuildingBlueprint farmEnemyBuilding;
    public BuildingBlueprint blueEnemyBarracksBuilding;
    public BuildingBlueprint redEnemyBarracksBuilding;
    public BuildingBlueprint yellowEnemyBarracksBuilding;

    BuildManager buildManager;
    private List<int> ShopList = new List<int>();

    void Start()
    {
        buildManager = BuildManager.instance;

        //Set enemy blueprints to enemy
        standardEnemyTurret.setToEnemy(true);
        missileEnemyLauncher.setToEnemy(true);
        laserEnemyBeamer.setToEnemy(true);
        farmEnemyBuilding.setToEnemy(true);
        blueEnemyBarracksBuilding.setToEnemy(true);
        redEnemyBarracksBuilding.setToEnemy(true);
        yellowEnemyBarracksBuilding.setToEnemy(true);

        
        ShopList.Add((int)ShopItems.STANDARDTURRET);
        ShopList.Add((int)ShopItems.MISSILELAUNCHER);
        ShopList.Add((int)ShopItems.LASERBEAMER);
        ShopList.Add((int)ShopItems.FARM);
        ShopList.Add((int)ShopItems.REDBARRACKS);
        ShopList.Add((int)ShopItems.YELLOWBARRACKS);
        ShopList.Add((int)ShopItems.BLUEBARRACKS);


        for (int i = 0; i < ShopList.Count; i++)
        {
            switch (ShopList[i])
            {
                case (int)ShopItems.STANDARDTURRET:
                    Instantiate<GameObject>(Resources.Load("Items/StandardTurretItem") as GameObject,this.transform);                    
                    break;
                case (int)ShopItems.MISSILELAUNCHER:
                    Instantiate<GameObject>(Resources.Load("Items/MissileLauncherItem") as GameObject, this.transform);
                    break;
                case (int)ShopItems.LASERBEAMER:
                    Instantiate<GameObject>(Resources.Load("Items/LaserBeamerItem") as GameObject, this.transform);
                    break;
                case (int)ShopItems.FARM:
                    Instantiate<GameObject>(Resources.Load("Items/FarmItem") as GameObject, this.transform);
                    break;
                case (int)ShopItems.REDBARRACKS:
                    Instantiate<GameObject>(Resources.Load("Items/RedBarracksItem") as GameObject, this.transform);
                    break;
                case (int)ShopItems.BLUEBARRACKS:
                    Instantiate<GameObject>(Resources.Load("Items/BlueBarracksItem") as GameObject, this.transform);
                    break;
                case (int)ShopItems.YELLOWBARRACKS:
                    Instantiate<GameObject>(Resources.Load("Items/YellowBarracksItem") as GameObject, this.transform);
                    break;
            }
        }
    }


    private void FixedUpdate()
    {        

        //if (Input.GetKey(KeyCode.Alpha1)) { buildManager.SelectBuildingToBuild(standardTurret); }
        //if (Input.GetKey(KeyCode.Alpha2)) { buildManager.SelectBuildingToBuild(missileLauncher); }
        //if (Input.GetKey(KeyCode.Alpha3)) { buildManager.SelectBuildingToBuild(laserBeamer); }
        if (Input.GetKey(KeyCode.Alpha4)) { buildManager.SelectBuildingToBuild(farmBuilding); }
        if (Input.GetKey(KeyCode.Alpha5)) { buildManager.SelectBuildingToBuild(blueBarracksBuilding); }
        if (Input.GetKey(KeyCode.Alpha6)) { buildManager.SelectBuildingToBuild(redBarracksBuilding); }
        if (Input.GetKey(KeyCode.Alpha7)) { buildManager.SelectBuildingToBuild(yellowBarracksBuilding); }

        if (Input.GetKey(KeyCode.Q)) { buildManager.SelectBuildingToBuild(standardEnemyTurret); }
        if (Input.GetKey(KeyCode.W)) { buildManager.SelectBuildingToBuild(missileEnemyLauncher); }
        if (Input.GetKey(KeyCode.E)) { buildManager.SelectBuildingToBuild(laserEnemyBeamer); }
        if (Input.GetKey(KeyCode.R)) { buildManager.SelectBuildingToBuild(farmEnemyBuilding); }
        if (Input.GetKey(KeyCode.T)) { buildManager.SelectBuildingToBuild(blueEnemyBarracksBuilding); }
        if (Input.GetKey(KeyCode.Y)) { buildManager.SelectBuildingToBuild(redEnemyBarracksBuilding); }
        if (Input.GetKey(KeyCode.U)) { buildManager.SelectBuildingToBuild(yellowEnemyBarracksBuilding); }
       
    }

    public void SelectStandardTurret ()
	{
		Debug.Log("Standard Turret Selected");
		buildManager.SelectBuildingToBuild(standardTurret);
	}

	public void SelectMissileLauncher()
	{
		Debug.Log("Missile Launcher Selected");
		buildManager.SelectBuildingToBuild(missileLauncher);
	}

	public void SelectLaserBeamer()
	{
		Debug.Log("Laser Beamer Selected");
		buildManager.SelectBuildingToBuild(laserBeamer);
	}

    public void SelectFarm()
    {
        Debug.Log("Farm Selected");
        buildManager.SelectBuildingToBuild(farmBuilding);
    }

    public void SelectBlueBarracks()
    {
        Debug.Log("BlueBarracks Selected");
        buildManager.SelectBuildingToBuild(blueBarracksBuilding);
    }

    public void SelectRedBarracks()
    {
        Debug.Log("RedBarracks Selected");
        buildManager.SelectBuildingToBuild(redBarracksBuilding);
    }

    public void SelectYellowBarracks()
    {
        Debug.Log("YellowBarracks Selected");
        buildManager.SelectBuildingToBuild(yellowBarracksBuilding);
    }


    
}