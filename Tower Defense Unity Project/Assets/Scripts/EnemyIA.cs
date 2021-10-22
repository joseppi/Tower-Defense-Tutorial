using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyIA : MonoBehaviour
{

    Node[] turretNodes;
    Node[] buildingNodes;
    Shop shop;
    int currentRound = 0;

    public List<Action> actions;
        
    // Start is called before the first frame update
    void Start()
    {
        turretNodes = GameObject.Find("EnemyNodesTurrets").GetComponentsInChildren<Node>();
        buildingNodes = GameObject.Find("EnemyNodesBuildings").GetComponentsInChildren<Node>();
        shop = GameObject.Find("Shop").GetComponent<Shop>();
        
        actions.Add(new Action(buildingNodes[0], Action.ActionType.Farm));
        actions.Add(new Action(buildingNodes[1], Action.ActionType.Farm));
        actions.Add(new Action(buildingNodes[2], Action.ActionType.Farm));
        actions.Add(new Action(buildingNodes[2], Action.ActionType.Farm));
        actions.Add(new Action(turretNodes[0], Action.ActionType.Missile));
        actions.Add(new Action(turretNodes[1], Action.ActionType.Turret));
        actions.Add(new Action(turretNodes[2], Action.ActionType.Laser));
        actions.Add(new Action(turretNodes[3], Action.ActionType.Missile));
        actions.Add(new Action(turretNodes[4], Action.ActionType.Turret));
        actions.Add(new Action(turretNodes[5], Action.ActionType.Laser));
        actions.Add(new Action(turretNodes[6], Action.ActionType.Missile));
        actions.Add(new Action(turretNodes[7], Action.ActionType.Turret));
        actions.Add(new Action(turretNodes[8], Action.ActionType.Laser));
        actions.Add(new Action(turretNodes[9], Action.ActionType.Missile));
        actions.Add(new Action(turretNodes[10], Action.ActionType.Turret));
        actions.Add(new Action(turretNodes[11], Action.ActionType.Laser));
        actions.Add(new Action(turretNodes[12], Action.ActionType.Missile));
        actions.Add(new Action(turretNodes[13], Action.ActionType.Turret));
        actions.Add(new Action(turretNodes[14], Action.ActionType.Laser));
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRound != StatsPlayer.Rounds)
        {
            Invoke("RequestAction", 1.0f);
            currentRound = StatsPlayer.Rounds;
        }        
    }

    void LogBuildState(BuildingBlueprint blueprint)
    {
        //Debug.Log("Not enoguh money for " + blueprint.prefab.name.ToString());
    }
    
    void RequestAction()
    {                
        foreach (Action action in actions)
        {
            if (action.isConstructed)
                continue;

            switch(action.typeAction)
            {
                case Action.ActionType.BarracksBlue:
                    if (shop.blueEnemyBarracksBuilding.cost > StatsEnemy.Money)
                    {
                        LogBuildState(shop.blueEnemyBarracksBuilding);                        
                        return;
                    }
                    break;

                case Action.ActionType.BarracksRed:
                    if (shop.redEnemyBarracksBuilding.cost > StatsEnemy.Money)
                    {
                        LogBuildState(shop.redEnemyBarracksBuilding);
                        return;
                    }                    
                    break;

                case Action.ActionType.BarracksYellow:
                    if (shop.yellowEnemyBarracksBuilding.cost > StatsEnemy.Money)
                    {
                        LogBuildState(shop.yellowEnemyBarracksBuilding);
                        return;
                    }                    
                    break;

                case Action.ActionType.Farm:
                    if (shop.farmEnemyBuilding.cost > StatsEnemy.Money)
                    {
                        LogBuildState(shop.farmEnemyBuilding);
                        return;
                    }                    
                    break;

                case Action.ActionType.Laser:
                    if (shop.laserEnemyBeamer.cost > StatsEnemy.Money)
                    {
                        LogBuildState(shop.laserEnemyBeamer);
                        return;
                    }                    
                    break;

                case Action.ActionType.Missile:
                    if (shop.missileEnemyLauncher.cost > StatsEnemy.Money)
                    {
                        LogBuildState(shop.missileEnemyLauncher);
                        return;
                    }                    
                    break;

                case Action.ActionType.Turret:
                    if (shop.standardEnemyTurret.cost > StatsEnemy.Money)
                    {
                        LogBuildState(shop.standardEnemyTurret);
                        return;
                    }                    
                    break;

            }

                
            switch (action.typeAction)
            {
                case Action.ActionType.BarracksBlue:
                    BuildBlueprint(action, shop.blueEnemyBarracksBuilding);
                    break;

                case Action.ActionType.BarracksRed:
                    BuildBlueprint(action, shop.redEnemyBarracksBuilding);
                    break;

                case Action.ActionType.BarracksYellow:
                    BuildBlueprint(action, shop.yellowEnemyBarracksBuilding);
                    break;

                case Action.ActionType.Farm:
                    BuildBlueprint(action, shop.farmEnemyBuilding);
                    break;

                case Action.ActionType.Laser:
                    BuildBlueprint(action, shop.laserEnemyBeamer);
                    break;

                case Action.ActionType.Missile:
                    BuildBlueprint(action, shop.missileEnemyLauncher);
                    break;

                case Action.ActionType.Turret:
                    BuildBlueprint(action, shop.standardEnemyTurret);
                    break;
            }
        }
    }

    private void BuildBlueprint(Action action, BuildingBlueprint blueprint)
    {
        //Debug.Log("Enemy is trying to build " + blueprint.prefab.name.ToString());

        bool isConstructed = action.node.BuildTurret(blueprint);
        
        if (isConstructed)
        {
            action.isConstructed = true;       
        }
            
    }


}
