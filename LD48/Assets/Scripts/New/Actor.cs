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
    SpriteRenderer _sr;
    protected SpriteRenderer spriteRenderer {
        get {
            if (!_sr) _sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
            return _sr;
        }
    }
    #endregion

    public Action OnMove;
    public Action OnDie;
    public Action<float> OnDamaged;
    public Action<Actor> OnAttack;

    protected float atkTimer;
}
