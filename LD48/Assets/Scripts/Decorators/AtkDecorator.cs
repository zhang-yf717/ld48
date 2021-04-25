using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkDecorator : ActorDecorator {
    public float atkDelta = 1;
    public AtkDecorator(Actor targetActor) : base(targetActor) {
    }
    public override float AtkDamage { get => base.AtkDamage + atkDelta; set => base.AtkDamage = value; }
}
