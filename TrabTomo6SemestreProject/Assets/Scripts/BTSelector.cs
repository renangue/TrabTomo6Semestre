using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSelector : BTNode
{
    public List<BTNode> children = new List<BTNode>();

    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        Print(bt);

        foreach (BTNode node in children)
        {
            yield return bt.StartCoroutine(node.Run(bt));

            if (node.status == Status.SUCCESS)
            {
                status = Status.SUCCESS;

                break;
            }

            if (status == Status.RUNNING) status = Status.FAILURE;

            Print(bt);
        }
    }
}
