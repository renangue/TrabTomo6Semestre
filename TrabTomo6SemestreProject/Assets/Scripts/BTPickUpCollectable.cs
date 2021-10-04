using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTPickUpCollectable : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.FAILURE;

        GameObject[] collectables = GameObject.FindGameObjectsWithTag("Collectable");

        foreach (GameObject collectable in collectables)
        {
            if(Vector3.Distance(bt.transform.position, collectable.transform.position) < 1)
            {
                collectable.SetActive(false);

                status = Status.SUCCESS;

                break;
            }
        }

        Print(bt);

        yield break;
    }
}
