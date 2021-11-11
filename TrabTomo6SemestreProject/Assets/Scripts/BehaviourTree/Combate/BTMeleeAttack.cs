using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTMeleeAttack : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        Print(bt);

        NPC npc = bt.GetComponent<NPC>();

        if (npc.target)
        {
            npc.transform.LookAt(npc.target.transform);

            npc.animator.SetBool("Attack", true);

            yield return new WaitForSeconds(npc.stats.fireRate);

            status = Status.SUCCESS;
        }
        else
            status = Status.FAILURE;

        Print(bt);
    }
}
