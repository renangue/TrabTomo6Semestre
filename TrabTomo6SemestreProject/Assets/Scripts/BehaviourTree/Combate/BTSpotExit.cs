using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSpotExit : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        NPC npc = bt.GetComponent<NPC>();

        GameObject exit = GameObject.FindGameObjectWithTag("Finish");

        GameObject target = null;

        float distance = Mathf.Infinity;

        float dist = Vector3.Distance(bt.transform.position, exit.transform.position);

        if (dist < distance)
        {
            target = exit;
        }
        
        if (target)
        {
            npc.target = target;
            status = Status.SUCCESS;
        }
        else
        {
            npc.target = null;
            status = Status.FAILURE;
        }

        Print(bt);

        yield break;
    }
}
