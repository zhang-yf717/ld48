using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    enum STATE { ATTACKING, MOVING }

    public ActorData data;

    #region utils
    Rigidbody2D _rb;
    protected new Rigidbody2D rigidbody {
        get {
            if (!_rb) _rb = GetComponent<Rigidbody2D>();
            return _rb;
        }
    }
    #endregion

    protected Action OnMove;
    protected Action OnDie;
    public Action<float> OnDamaged;
    protected Action<Actor> OnAttack;

    protected float atkTimer;
}
