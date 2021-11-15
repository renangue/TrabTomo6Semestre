using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="NPC/Stats")]
public class NPCStats : ScriptableObject
{
    public enum Type
    {
        MELEE,
        RANGED,
    }
   
    public string targetTag = "Enemy";
    public Type type = Type.RANGED;
    public int life = 5;
    public float speed = 5f;
    public float spotEnemyDistance = 10;
    public float attackRange = 3f;
    public float fireRate = 1f;
    public float damagePower = 1f;
    public int shieldForce = 3;
    public float bulletSpeed = 200f;

    public void Setup(NPCStats _stats)
    {
        this.life = _stats.life;
        this.speed = _stats.speed;
        this.fireRate = _stats.fireRate;
        this.damagePower = _stats.damagePower;
    }
}
