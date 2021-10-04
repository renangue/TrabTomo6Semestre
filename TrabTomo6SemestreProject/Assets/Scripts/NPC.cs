using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public NPCStats stats;

    private float life;

    public GameObject target;

    public GameObject bullet;

    void Start()
    {

        BTSequence combat = new BTSequence();
        combat.children.Add(new BTNearEnemy());
        combat.children.Add(new BTSpotEnemy());

        BTSequence moveToExit = new BTSequence();
        moveToExit.children.Add(new BTSpotExit());
        moveToExit.children.Add(new BTMoveToExit());

        BTSelector selector = new BTSelector();
        selector.children.Add(combat);
        selector.children.Add(moveToExit);

        if (stats.type == NPCStats.Type.MEELE) combat.children.Add(new BTMoveToEnemy());
        
        else combat.children.Add(new BTAttackEnemy());

        BehaviourTree bt = GetComponent<BehaviourTree>();

        if (bt.CompareTag("Player")) bt.root = selector;

        else bt.root = combat;

        StartCoroutine(bt.Begin());

        life = stats.life;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(bullet.tag))
        {
            Destroy(other.gameObject);

            life--;

            if (life == 0) Destroy(gameObject);
        }
    }
}
