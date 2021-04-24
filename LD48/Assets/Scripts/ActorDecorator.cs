using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorDecorator : Actor {
    protected Actor _decoratee;
    public ActorDecorator(Actor targetActor) {
        _decoratee = targetActor;
    }
    public override void OnAttack(GameObject target) {
        _decoratee.OnAttack(target);
    }
}
