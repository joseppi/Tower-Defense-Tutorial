using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{

    public static List<Action> actions;

    public enum ActionType
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
    public ActionType typeAction = ActionType.Undefined;
    public bool isConstructed = false;

    public Action(Node node, ActionType action)
    {
        this.node = node;
        this.typeAction = action;
    }

    public void AddAction(Node node, ActionType action)
    {
        actions.Add(new Action(node, action));        
    }

}



