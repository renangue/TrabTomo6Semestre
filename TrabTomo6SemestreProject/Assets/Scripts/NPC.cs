using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float life = 5;

    public GameObject target;

    public GameObject bullet;

    void Start()
    {
        BTInverter noNearEnemy = new BTInverter();
        noNearEnemy.child = new BTNearEnemy();

        BTSequenceParallel hunter = new BTSequenceParallel();
        hunter.children.Add(noNearEnemy);
        hunter.children.Add(new BTHunter());


        BTSequence collect = new BTSequence();
        collect.children.Add(new BTCollectable());
        collect.children.Add(hunter);
        collect.children.Add(new BTPickUpCollectable());

        BTSequence combat = new BTSequence();
        combat.children.Add(new BTNearEnemy());
        combat.children.Add(new BTSpotEnemy());
        combat.children.Add(new BTMoveToEnemy());
        combat.children.Add(new BTAttackEnemy());
        combat.children.Add(new BTDodge());

        BTSelector selector = new BTSelector();
        selector.children.Add(combat);
        selector.children.Add(collect);

        BehaviourTree bt = GetComponent<BehaviourTree>();
        bt.root = selector;

        StartCoroutine(bt.Begin());
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
