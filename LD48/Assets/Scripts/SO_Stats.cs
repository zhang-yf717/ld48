using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stats", menuName = "ScriptableObjects/New Stats", order = 1)] 
public class SO_Stats : ScriptableObject {
    public float Health;
    public float AttackDamage;
    public float AttackRange;
    public float AttackInterval;
    public float Speed;
    public float Defence;
    public float HealthRegen;
}
