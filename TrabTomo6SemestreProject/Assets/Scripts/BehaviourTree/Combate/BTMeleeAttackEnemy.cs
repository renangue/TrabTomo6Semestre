using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTMeleeAttackEnemy : BTNode
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
            clone.GetComponent<Rigidbody>().AddForce(npc.transform.forward * npc.stats.bulletSpeed);

            yield return new WaitForSeconds(npc.stats.fireRate);

            status = Status.SUCCESS;
        }
        else
        {
            status = Status.FAILURE;
        }

        Print(bt);
    }
}
