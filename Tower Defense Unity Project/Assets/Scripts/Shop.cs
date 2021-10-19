using UnityEngine;

public class Shop : MonoBehaviour {

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

	void Start ()
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
    }

    private void FixedUpdate()
    {        

        if (Input.GetKey(KeyCode.Alpha1)) { buildManager.SelectBuildingToBuild(standardTurret); }
        if (Input.GetKey(KeyCode.Alpha2)) { buildManager.SelectBuildingToBuild(missileLauncher); }
        if (Input.GetKey(KeyCode.Alpha3)) { buildManager.SelectBuildingToBuild(laserBeamer); }
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
