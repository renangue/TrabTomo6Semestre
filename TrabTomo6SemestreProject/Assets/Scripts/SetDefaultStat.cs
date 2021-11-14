using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultStat : MonoBehaviour
{
    public NPC[] players;

    public NPCStats[] defaultStats;

    public void RestartStats()
    {
        players[0].stats.Setup(defaultStats[0]);

        players[1].stats.Setup(defaultStats[1]);

        print("restart");
    }
}
