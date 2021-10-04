using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTCollectable : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        GameObject gameObject = GameObject.FindWithTag("Collectable");
        
        if (gameObject) status = Status.SUCCESS;
        else status = Status.FAILURE;

        Print(bt);

        yield break;
    }
}
