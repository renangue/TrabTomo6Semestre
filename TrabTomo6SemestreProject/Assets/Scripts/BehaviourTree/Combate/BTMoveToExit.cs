using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BTMoveToExit : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        Print(bt);

        GameObject exit = GameObject.FindGameObjectWithTag("Finish");

        NPC npc = bt.GetComponent<NPC>();
        
        while (exit)
        {
            NavMeshAgent agent = npc.GetComponent<NavMeshAgent>();
            npc.transform.LookAt(exit.transform);
            agent.SetDestination(exit.transform.position);

            if (Vector3.Distance(bt.transform.position, exit.transform.position ) < 1)
            {
                status = Status.SUCCESS;
                break;
            }

            yield return null;
        }

        if (status == Status.RUNNING) status = Status.FAILURE;

        Print(bt);
    }
}
