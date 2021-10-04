using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNearEnemy : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.FAILURE;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy == bt.gameObject) continue;
            
            if(Vector3.Distance(bt.transform.position, enemy.transform.position) < 10)
            {
                status = Status.SUCCESS;
                break;
            }
        }

        Print(bt);
        
        yield break;
    }
}
