using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTDodge : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;
        Print(bt);

        NPC npc = bt.GetComponent<NPC>();

        int direction = Random.Range(-1, 2);
        float time = Time.time + 0.1f;

        if (direction != 0) time += 0.4f;

        while(npc.target)
        {
            if(time < Time.time)
            {
                status = Status.SUCCESS;
                break;
            }

            npc.transform.LookAt(npc.target.transform);
            npc.transform.Translate(Vector3.right * direction * Time.deltaTime);
            yield return null;
        }

        if (status == Status.RUNNING) status = Status.FAILURE;

        Print(bt);
    }
}
