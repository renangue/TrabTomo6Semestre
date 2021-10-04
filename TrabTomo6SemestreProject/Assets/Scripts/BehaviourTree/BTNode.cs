using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTNode
{
    public enum Status { RUNNING, SUCCESS, FAILURE }

    public Status status;

    public abstract IEnumerator Run(BehaviourTree bt);

    public void Print(BehaviourTree bt)
    {
        string color = "cyan";

        if (status == Status.SUCCESS) color = "lime";
        else if (status == Status.FAILURE) color = "red";

        string text = bt.name + " " + this + " " + status;

        Debug.Log("<color=\"" + color + "\">" + text + "</color>");

    }
}
