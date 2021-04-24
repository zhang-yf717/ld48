using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour {
    [HideInInspector]
    public bool statsFoldout;

    [SerializeField]
    public SO_Stats statsData;

    protected Stats _stats;
    protected Stats stats {
        get {
            if (_stats == null) {
                CreateNewStats();
            }
            return _stats;
        }
    }

    public void CreateNewStats() {
        _stats = new Stats(statsData);
    }

    #region utils
    protected Rigidbody2D _rigidBody;
    protected Rigidbody2D Rigidbody {
        get {
            if (_rigidBody == null) {
                _rigidBody = GetComponent<Rigidbody2D>();
            }
            return _rigidBody;
        }
    }
    protected SpriteRenderer _spriteRenderer;
    protected SpriteRenderer SpriteRenderer {
        get {
            if (_spriteRenderer == null) {
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }
            return _spriteRenderer;
        }
    }
    #endregion

    public virtual float Health { get => stats.Health; set => stats.Health = value; }
    public virtual float AtkDamage { get => stats.AttackDamage; set => stats.AttackDamage = value; }
    public virtual float AtkRange { get => stats.AttackRange; set => stats.AttackRange = value; }
    public virtual float Speed { get => stats.Speed; set => stats.Speed = value; }
    public virtual float Defence { get => stats.Defence; set => stats.Defence = value; }

    public virtual void OnAttack(GameObject target) {
        // Debug.Log("Actor: " + gameObject.name + " attacks " + target.name);
    }
    public virtual void OnMove(Vector3 loc) {
        // Debug.Log("Actor: " + gameObject.name + " moves to " + loc);
    }
    public virtual void OnDamaged() {
        // Debug.Log("Actor: " + gameObject.name + " is damaged!");
    }

    public virtual Collider2D[] GetAllInRange() {
        var point = gameObject.transform.position;
        var radius = AtkRange;
        return Physics2D.OverlapCircleAll(point, radius);
    }
}
