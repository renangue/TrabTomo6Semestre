using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSpotEnemy : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject target = null;

        float distance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            if (enemy == bt.gameObject) continue;

            float dist = Vector3.Distance(bt.transform.position, enemy.transform.position);

            if (dist < distance)
            {
                target = enemy;

                distance = dist;
            }    
        }

        NPC npc = bt.GetComponent<NPC>();

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
