using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorDecorator : Actor {
    protected Actor _decoratee;
    public ActorDecorator(Actor targetActor) {
        _decoratee = targetActor;
    }
    public override float Health { get => _decoratee.Health; set => _decoratee.Health = value; }
    public override float AtkDamage { get => _decoratee.AtkDamage; set => _decoratee.AtkDamage = value; }
    public override float AtkRange { get => _decoratee.AtkRange; set => _decoratee.AtkRange = value; }
    public override float Speed { get => _decoratee.Speed; set => _decoratee.Speed = value; }
    public override float Defence { get => _decoratee.Defence; set => _decoratee.Defence = value; }
    public override bool isAttacking { get => _decoratee.isAttacking; set => _decoratee.isAttacking = value; }
    public override bool IsDamagedColorChanging { get => _decoratee.IsDamagedColorChanging; set => _decoratee.IsDamagedColorChanging = value; }
    public override void OnAttack(Actor target) {
        _decoratee.OnAttack(target);
    }
    public override void OnMove(Vector3 loc) {
        _decoratee.OnMove(loc);
    }
    public override void OnDamaged(float dmg) {
        _decoratee.OnDamaged(dmg);
    }
    public override void Die() {
        _decoratee.Die();
    }
}
