using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorDecorator : Actor {
    protected Actor _decoratee;
    public ActorDecorator(Actor targetActor) {
        _decoratee = targetActor;
    }
    public override void Attack(GameObject target) {
        _decoratee.Attack(target);
    }
}
