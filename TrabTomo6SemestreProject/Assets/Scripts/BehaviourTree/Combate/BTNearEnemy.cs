using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNearEnemy : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        NPC npc = bt.GetComponent<NPC>();
        
        status = Status.FAILURE;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(npc.stats.targetTag);

        foreach (GameObject enemy in enemies)
        {
            if (enemy == bt.gameObject) continue;
            
            if(Vector3.Distance(bt.transform.position, enemy.transform.position) < npc.stats.spotEnemyDistance)
            {
                status = Status.SUCCESS;
                break;
            }
        }

        Print(bt);
        
        yield break;
    }
}
