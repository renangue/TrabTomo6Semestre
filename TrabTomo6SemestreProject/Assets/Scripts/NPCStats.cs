using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="NPC/Stats")]
public class NPCStats : ScriptableObject
{
    public enum Type
    {
        MEELE,
        RANGED,
    }
   
    public string targetTag = "Enemy";
    public Type type = Type.RANGED;
    public int life = 5;
    public float speed = 5f;
    public float spotEnemyDistance = 10;
    public float fireRate = 1f;
    public float bulletSpeed = 200f;
}
