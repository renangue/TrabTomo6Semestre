using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTMoveToEnemy : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        Print(bt);

        NPC npc = bt.GetComponent<NPC>();

        while (npc.target)
        {
            if(Vector3.Distance(npc.transform.position, npc.target.transform.position) < npc.stats.attackRange)
            {
                status = Status.SUCCESS;
                break;
            }
            
            npc.agent.speed = npc.stats.speed;
            npc.transform.LookAt(npc.target.transform);
            npc.agent.SetDestination(npc.target.transform.position);
            
            yield return null;
        }

        if (status == Status.RUNNING) status = Status.FAILURE;
        
        Print(bt);
    }
}
