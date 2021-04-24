using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Actor
{
    protected Transform _target;
    protected Transform Target { 
        get {
            if (_target == null) {
                _target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            return _target;
        }
    }
    protected Vector3 _dir {
        get => Utils.Direction(transform.position, Target.position);
    }
    protected float _dist {
        get => Utils.Distance(transform.position, Target.position);
    }

    public override void OnAttack(GameObject target) {
        Rigidbody.velocity = Vector3.zero;
    }
    public override void OnMove(Vector3 loc) {
        Rigidbody.MovePosition(loc);
    }
    public override void OnDamaged() {
        base.OnDamaged();
    }

    public void FixedUpdate() {
        if (_dist <= AtkRange) {
            if (Rigidbody.bodyType != RigidbodyType2D.Kinematic) {
                Rigidbody.bodyType = RigidbodyType2D.Kinematic;
            }
            OnAttack(Target.gameObject);
        } else {
            if (Rigidbody.bodyType != RigidbodyType2D.Dynamic) {
                Rigidbody.bodyType = RigidbodyType2D.Dynamic;
            }
            var _next_pos = transform.position + _dir * stats.Speed;
            OnMove(_next_pos);
        }
    }
    
    

    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        if (AtkRange >= _dist) Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AtkRange);
    }
}
