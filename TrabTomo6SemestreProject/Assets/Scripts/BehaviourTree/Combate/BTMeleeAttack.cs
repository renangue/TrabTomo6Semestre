using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTMeleeAttack : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        //Print(bt);

        NPC npc = bt.GetComponent<NPC>();

        while (npc.target)
        {
            npc.transform.LookAt(npc.target.transform);

            if(bt.CompareTag("Player"))
            {
                npc.animator.speed = npc.stats.fireRate * 0.5f;
            }

            npc.animator.SetBool("Attack", true);

            yield return new WaitForSeconds(1f);

            status = Status.SUCCESS;
            break;
        }

        if(status == Status.RUNNING) status = Status.FAILURE;

        //Print(bt);
    }
}
