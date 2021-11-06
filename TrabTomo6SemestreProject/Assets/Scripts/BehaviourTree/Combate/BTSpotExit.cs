using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSpotExit : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        NPC npc = bt.GetComponent<NPC>();

        GameObject exit = GameObject.FindGameObjectWithTag("Finish");

        
        if (exit)
        {
            npc.target = exit;
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
