using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTHunter : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        Print(bt);
        
        GameObject[] collectables = GameObject.FindGameObjectsWithTag("Collectable");

        GameObject target = null;

        float distance = Mathf.Infinity;

        Print(bt);

        foreach (GameObject collectable in collectables)
        {
            float currentDist = Vector3.Distance(bt.transform.position, collectable.transform.position);

            if(currentDist < distance)
            {
                target = collectable;

                distance = currentDist;
            }
        }

        while(target)
        {
            bt.transform.LookAt(target.transform);
            bt.transform.Translate(Vector3.forward * 4 * Time.deltaTime);

            if(Vector3.Distance(bt.transform.position, target.transform.position) < 1)
            {
                status = Status.SUCCESS;
                break;
            }
            
            yield return null;
        }

        if(status == Status.RUNNING) status = Status.FAILURE;

        Print(bt);
    }
}
