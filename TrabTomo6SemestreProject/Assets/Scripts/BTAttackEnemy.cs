using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTAttackEnemy : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        Print(bt);

        NPC npc = bt.GetComponent<NPC>();

        if (npc.target)
        {
            npc.transform.LookAt(npc.target.transform);

            Vector3 position = npc.transform.position + npc.transform.forward;
            Quaternion rotation = npc.transform.rotation;
            GameObject clone = GameObject.Instantiate(npc.bullet, position, rotation);
            clone.GetComponent<Rigidbody>().AddForce(npc.transform.forward * 200);
            
            yield return new WaitForSeconds(0.1f);

            status = Status.SUCCESS;
        }
        else
        {
            status = Status.FAILURE;
        }

        Print(bt);
    }
}
