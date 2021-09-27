using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int maxHealth;
    public float moveSpeed;
    public float additionalAmmoDamage;
    public float ammoDamageMultipiler;
    public float critRate;
    public int inventoryCapacity;
    public float reloadTime;
}
