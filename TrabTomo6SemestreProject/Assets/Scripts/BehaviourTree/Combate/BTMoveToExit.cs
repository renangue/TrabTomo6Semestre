using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTMoveToExit : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        Print(bt);

        GameObject exit = GameObject.FindGameObjectWithTag("Finish");

        GameObject target = null;

        float distance = Mathf.Infinity;

        Print(bt);
        
        float currentDist = Vector3.Distance(bt.transform.position, exit.transform.position);

        if (currentDist < distance)
        {
            target = exit;
        }
        
        while (target)
        {
            bt.transform.LookAt(target.transform);
            bt.transform.Translate(Vector3.forward * 4 * Time.deltaTime);

            if (Vector3.Distance(bt.transform.position, target.transform.position) < 1)
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
