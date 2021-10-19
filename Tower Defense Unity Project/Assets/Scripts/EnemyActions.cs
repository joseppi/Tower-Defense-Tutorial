using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{

    public static List<EnemyActions> actions;

    public enum Actions
    {
        Undefined,
        BarracksBlue,
        BarracksYellow,
        BarracksRed,
        Farm,
        Turret,
        Laser,
        Missile
    }

    public Node node;    
    public Actions typeAction = Actions.Undefined;

    public EnemyActions(Node node, Actions action)
    {
        this.node = node;
        this.typeAction = action;
    }

    public void AddAction(Node node, Actions action)
    {
        actions.Add(new EnemyActions(node, action));        
    }

}



