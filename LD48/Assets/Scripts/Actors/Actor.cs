using UnityEngine;
using DG.Tweening;

public abstract class Actor : MonoBehaviour {
    protected float punchScale = 0.33f;

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
                _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
            }
            return _spriteRenderer;
        }
    }
    protected Transform Sprite => transform.GetChild(0);
    protected Vector2 Position => transform.position;
    #endregion

    public virtual float Health { get => stats.Health; set => stats.Health = value; }
    public virtual float AtkDamage { get => stats.AttackDamage; set => stats.AttackDamage = value; }
    public virtual float AtkRange { get => stats.AttackRange; set => stats.AttackRange = value; }
    public virtual float Speed { get => stats.Speed; set => stats.Speed = value; }
    public virtual float Defence { get => stats.Defence; set => stats.Defence = value; }

    protected bool _isAttacking, _isDamagedColorChanging;
    protected float _attackCooldown;
    public virtual bool isAttacking { get => _isAttacking; set => _isAttacking = value; }
    public virtual bool IsDamagedColorChanging { get => _isDamagedColorChanging; set => _isDamagedColorChanging = value; }

    public virtual void OnAttack(Actor target) {
        // Debug.Log("Actor: " + gameObject.name + " attacks " + target.name);
        if (_attackCooldown >= 0) {
            return;
        }
        _attackCooldown = stats.AttackInterval;
        var _dir = Utils.Direction(Position, target.Position);

        // animation
        Sprite.DOPunchPosition(Utils.Direction(Position, target.Position) * AtkRange * punchScale, 0.5f, 3, 0);

        // apply damage
        target.OnDamaged(stats.AttackDamage);
    }
    public virtual void OnMove(Vector3 loc) {
        // Debug.Log("Actor: " + gameObject.name + " moves to " + loc);
    }
    public virtual void OnDamaged(float dmg) {
        Health -= dmg; 
        if (Health <= 0) {
            Die();
        }

        if (!IsDamagedColorChanging) {
            IsDamagedColorChanging = true;
            SpriteRenderer.DOColor(Color.red, 0.2f).SetLoops(2, LoopType.Yoyo).OnComplete(() => IsDamagedColorChanging = false);
            Sprite.DOPunchScale(new Vector3(0.05f, 0.05f, 1), 0.3f, 5, 0f);
        }
        // Debug.Log("Actor: " + gameObject.name + " is damaged!");
    }

    public virtual void Die() {
        Destroy(gameObject);
    }

    protected virtual void Update() {
        _attackCooldown -= Time.deltaTime;
    }

    
}
