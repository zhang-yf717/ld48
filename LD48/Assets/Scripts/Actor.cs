using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour {
    protected Stats stats;
    public virtual float health { get => stats.Health; set => stats.Health = value; }
    public virtual float atkDamage { get => stats.AttackDamage; set => stats.AttackDamage = value; }
    public virtual float atkRange { get => stats.AttackRange; set => stats.AttackRange = value; }
    public virtual float speed { get => stats.Speed; set => stats.Speed = value; }
    public virtual void Attack(GameObject target) {
        Debug.Log("Actor: " + gameObject.name + " attacks " + target.name);
    }
    public virtual void Move(Vector3 loc) {
        Debug.Log("Actor: " + gameObject.name + " moves to " + loc);
    }

    public virtual Collider2D[] GetAllInRange() {
        var point = gameObject.transform.position;
        var radius = atkRange;
        return Physics2D.OverlapCircleAll(point, radius);
    }
}
