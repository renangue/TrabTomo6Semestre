using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTMoveToEnemy : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        Print(bt);

        NPC npc = bt.GetComponent<NPC>();
        NavMeshAgent agent = bt.GetComponent<NavMeshAgent>();

        while (npc.target)
        {
            if(Vector3.Distance(npc.transform.position, npc.target.transform.position) < 8)
            {
                status = Status.SUCCESS;
                agent.speed = 0;
                break;
            }
            
            npc.transform.LookAt(npc.target.transform);
            
            agent.speed = npc.stats.speed;
            agent.SetDestination(npc.target.transform.position);
            
            yield return null;
        }

        if (status == Status.RUNNING) status = Status.FAILURE;
        
        Print(bt);
    }
}
