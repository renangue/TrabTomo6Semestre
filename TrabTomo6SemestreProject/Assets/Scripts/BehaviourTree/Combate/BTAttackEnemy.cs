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
            npc.animator.SetBool("Attack", true);

            Vector3 position = npc.transform.position + npc.transform.forward;
            Quaternion rotation = npc.transform.rotation;
            GameObject clone = GameObject.Instantiate(npc.bullet, npc.muzzle.position, rotation);
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