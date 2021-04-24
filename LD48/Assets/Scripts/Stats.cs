using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats {
    protected float _health, _atkDamage, _atkRange, _speed;
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
    public float Speed {
        get => _speed;
        set => _speed = value;
    }
}
