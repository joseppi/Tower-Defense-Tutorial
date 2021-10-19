using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyIA : MonoBehaviour
{

    Node[] turretNodes;
    Node[] buildingNodes;
    Shop shop;

    public List<EnemyActions> actions;
        
    // Start is called before the first frame update
    void Start()
    {
        turretNodes = GameObject.Find("EnemyNodesTurrets").GetComponentsInChildren<Node>();
        buildingNodes = GameObject.Find("EnemyNodesBuildings").GetComponentsInChildren<Node>();
        shop = GameObject.Find("Shop").GetComponent<Shop>();
        
        actions.Add(new EnemyActions(buildingNodes[0], EnemyActions.Actions.Farm));
        actions.Add(new EnemyActions(buildingNodes[1], EnemyActions.Actions.Farm));
        actions.Add(new EnemyActions(buildingNodes[2], EnemyActions.Actions.Farm));        
        actions.Add(new EnemyActions(turretNodes[0], EnemyActions.Actions.Turret));
        actions.Add(new EnemyActions(turretNodes[1], EnemyActions.Actions.Missile));
        actions.Add(new EnemyActions(turretNodes[2], EnemyActions.Actions.Laser));
        actions.Add(new EnemyActions(buildingNodes[3], EnemyActions.Actions.BarracksRed));
        actions.Add(new EnemyActions(buildingNodes[4], EnemyActions.Actions.BarracksBlue));
        actions.Add(new EnemyActions(buildingNodes[5], EnemyActions.Actions.BarracksYellow));
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("RequestAction", 1.0f);
    }

    void RequestAction()
    {                
        for (int i = 0; i < actions.Count; i++)
        {
            switch(actions[i].typeAction)
            {
                case EnemyActions.Actions.BarracksBlue:
                    if (shop.blueEnemyBarracksBuilding.cost > StatsEnemy.Money)
                    {
                        Debug.Log("Not enoguh moneeeeeh");
                        return;
                    }
                    break;

                case EnemyActions.Actions.BarracksRed:
                    if (shop.redEnemyBarracksBuilding.cost > StatsEnemy.Money)
                    {
                        Debug.Log("Not enoguh moneeeeeh");
                        return;
                    }                    
                    break;

                case EnemyActions.Actions.BarracksYellow:
                    if (shop.yellowEnemyBarracksBuilding.cost > StatsEnemy.Money)
                    {
                        Debug.Log("Not enoguh moneeeeeh");
                        return;
                    }                    
                    break;

                case EnemyActions.Actions.Farm:
                    if (shop.farmEnemyBuilding.cost > StatsEnemy.Money)
                    {
                        Debug.Log("Not enoguh moneeeeeh");
                        return;
                    }                    
                    break;

                case EnemyActions.Actions.Laser:
                    if (shop.laserEnemyBeamer.cost > StatsEnemy.Money)
                    {
                        Debug.Log("Not enoguh moneeeeeh");
                        return;
                    }                    
                    break;

                case EnemyActions.Actions.Missile:
                    if (shop.missileEnemyLauncher.cost > StatsEnemy.Money)
                    {
                        Debug.Log("Not enoguh moneeeeeh");
                        return;
                    }                    
                    break;

                case EnemyActions.Actions.Turret:
                    if (shop.standardEnemyTurret.cost > StatsEnemy.Money)
                    {
                        Debug.Log("Not enoguh moneeeeeh");
                        return;
                    }                    
                    break;

            }

                
            switch (actions[i].typeAction)
            {
                case EnemyActions.Actions.BarracksBlue:
                    BuildBlueprint(i, actions[i].node, shop.blueEnemyBarracksBuilding);
                    break;

                case EnemyActions.Actions.BarracksRed:
                    BuildBlueprint(i, actions[i].node, shop.redEnemyBarracksBuilding);
                    break;

                case EnemyActions.Actions.BarracksYellow:
                    BuildBlueprint(i, actions[i].node, shop.yellowEnemyBarracksBuilding);
                    break;

                case EnemyActions.Actions.Farm:
                    BuildBlueprint(i, actions[i].node, shop.farmEnemyBuilding);
                    break;

                case EnemyActions.Actions.Laser:
                    BuildBlueprint(i, actions[i].node, shop.laserEnemyBeamer);
                    break;

                case EnemyActions.Actions.Missile:
                    BuildBlueprint(i, actions[i].node, shop.missileEnemyLauncher);
                    break;

                case EnemyActions.Actions.Turret:
                    BuildBlueprint(i, actions[i].node, shop.standardEnemyTurret);
                    break;
            }
        }

    }

    private void BuildBlueprint(int i, Node node, BuildingBlueprint blueprint)
    {
        Debug.Log(blueprint.prefab.name.ToString() + " is trying to Build");

        bool isConstructed = node.BuildTurret(blueprint);
        
        if (isConstructed)
        {                        
            actions.RemoveAt(i);            
        }
            
    }


}
