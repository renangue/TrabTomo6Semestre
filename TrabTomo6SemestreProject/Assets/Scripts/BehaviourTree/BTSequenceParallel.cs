using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSequenceParallel : BTNode
{
    public List<BTNode> children = new List<BTNode>();
    
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        Print(bt);

        Dictionary<BTNode, Coroutine> routines = new Dictionary<BTNode, Coroutine>();

        while (status == Status.RUNNING)
        {
            foreach (BTNode node in children)
            {
                if (!routines.ContainsKey(node)) routines.Add(node, bt.StartCoroutine(node.Run(bt)));

                if (node.status != Status.RUNNING) routines.Remove(node);

                if (node.status == Status.FAILURE)
                {
                    status = Status.FAILURE;
                    break;
                }

                yield return null;
            }

            if (status == Status.RUNNING && routines.Count == 0) status = Status.SUCCESS;

        }

        foreach (Coroutine routine in routines.Values)
        {
            bt.StopCoroutine(routine);
        }

        Print(bt);
    }
}

