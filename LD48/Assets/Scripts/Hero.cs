using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Actor {
    private void Start() {
        punchScale = 0.05f;
    }

    public override void OnDamaged(float dmg) {
        base.OnDamaged(dmg);
    }
    public override void OnAttack(Actor target) {
        base.OnAttack(target);
    }

    protected override void Update() {
        base.Update();
    }

    private void FixedUpdate() {
        var colliders = Physics2D.OverlapCircleAll(Position, AtkRange);
        if (colliders.Length > 0) {
            OnAttack(colliders[Random.Range(0, colliders.Length)].GetComponent<Actor>());
        }
        
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        // if (AtkRange >= _dist) Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AtkRange);
    }
}
