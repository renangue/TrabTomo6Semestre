using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultStat : MonoBehaviour
{
    public NPCStats defaultStats;

    private NPC npc;
    // Start is called before the first frame update
    void Awake()
    {
        npc = GetComponent<NPC>();

        npc.stats.life = defaultStats.life;
        npc.stats.speed = defaultStats.speed;
        npc.stats.fireRate = defaultStats.fireRate;
        npc.stats.damagePower = defaultStats.damagePower;
    }
}
