using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Ammo Stats")]
public class AmmoStats : ScriptableObject
{
    public float damage;
    public float speed;
    public float lifeTime;
    public int bounces;
}
