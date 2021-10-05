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
        BTInverter noEnemyNear = new BTInverter();
        noEnemyNear.child = new BTNearEnemy();

        BTSequenceParallel moveToExit = new BTSequenceParallel();
        moveToExit.children.Add(noEnemyNear);
        moveToExit.children.Add(new BTMoveToExit());

        BTSequence combat = new BTSequence();
        combat.children.Add(new BTNearEnemy());
        combat.children.Add(new BTSpotEnemy());

        if (stats.type == NPCStats.Type.MELEE)
        {
            combat.children.Add(new BTMoveToEnemy());
            combat.children.Add(new BTRangedAttackEnemy());
        }

        else combat.children.Add(new BTRangedAttackEnemy());

        BTSequence walk = new BTSequence();
        walk.children.Add(new BTSpotExit());
        walk.children.Add(moveToExit); 

        BTSelector selector = new BTSelector();
        selector.children.Add(combat);
        selector.children.Add(walk); 

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
