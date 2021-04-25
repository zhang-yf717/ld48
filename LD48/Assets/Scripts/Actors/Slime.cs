using UnityEngine;
using DG.Tweening;

public class Slime : Actor
{
    protected Hero _target;
    protected Hero Target { 
        get {
            if (_target == null) {
                _target = FindObjectOfType<Hero>();
            }
            return _target;
        }
    }
    private Vector2 TargetPos => Target.transform.position;
    private float _dist => Utils.Distance(Position, TargetPos);
    public override void OnAttack(Actor hero) {
        base.OnAttack(hero);
        Rigidbody.velocity = Vector3.zero;
    }
    public override void OnMove(Vector3 loc) {
        Rigidbody.MovePosition(loc);
    }
    public override void OnDamaged(float dmg) {
        base.OnDamaged(dmg);
    }
    public override void Die() {
        GameManager.Instance.OnSlimeCountChange();
        base.Die();
    }
    protected void FixedUpdate() {
        if (Utils.Distance(Position, TargetPos) <= AtkRange) {
            if (Rigidbody.bodyType != RigidbodyType2D.Kinematic) {
                Rigidbody.bodyType = RigidbodyType2D.Kinematic;
            }
            OnAttack(Target);
            
        } else {
            if (Rigidbody.bodyType != RigidbodyType2D.Dynamic) {
                Rigidbody.bodyType = RigidbodyType2D.Dynamic;
            }
            var _next_pos = Utils.Direction(Position, TargetPos) * stats.Speed + Position;
            OnMove(_next_pos);
        }
    }
    protected override void Update() {
        if (Utils.Distance(Position, TargetPos) <= AtkRange) {
            _attackCooldown -= Time.deltaTime;
        }
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        if (AtkRange >= _dist) Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Position, AtkRange);
    }
}
