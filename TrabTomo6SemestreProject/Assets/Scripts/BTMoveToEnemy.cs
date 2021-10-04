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
            if(Vector3.Distance(npc.transform.position, npc.target.transform.position) < 4 )
            {
                status = Status.SUCCESS;
                break;
            }
            
            npc.transform.LookAt(npc.target.transform);
            npc.transform.Translate(Vector3.forward * 4 * Time.deltaTime);
            yield return null;
        }

        if (status == Status.RUNNING) status = Status.FAILURE;
        
        Print(bt);
    }
}
