using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats {
    [SerializeField]
    protected float _health, _atkDamage, _atkRange, _atkInterval, _speed, _defence, _healthRegen;
    public float Health {
        get => _health;
        set => _health = value;
    }
    public float AttackDamage {
        get => _atkDamage;
        set => _atkDamage = value;
    }
    public float AttackRange {
        get => _atkRange;
        set => _atkRange = value;
    }
    public float AttackInterval {
        get => _atkInterval;
        set => _atkInterval = value;
    }
    public float Speed {
        get => _speed;
        set => _speed = value;
    }
    public float Defence {
        get => _defence;
        set => _defence = value;
    }

    public float HealthRegen {
        get => _healthRegen;
        set => _healthRegen = value;
    }

    public Stats() { }
    public Stats(SO_Stats statsData) : 
        this(statsData.Health, statsData.AttackDamage, statsData.AttackRange, statsData.AttackInterval, statsData.Speed, statsData.Defence, statsData.HealthRegen) {
    }
    public Stats(float health, float atkDamage, float atkRange, float attackInterval, float speed, float defence, float healthRegen) {
        _health = health;
        _atkDamage = atkDamage;
        _atkRange = atkRange;
        _atkInterval = attackInterval;

        _speed = speed;
        _defence = defence;
        _healthRegen = healthRegen;
        
    }

}
