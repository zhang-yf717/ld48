using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Slime : Actor
{
    protected Actor _target;
    protected Actor Target {
        get {
            if (!_target) _target = FindObjectOfType<Hero>();
            return _target;
        }
    }

    protected Tweener scale_x_tweener; // moving animation;
    protected Tweener scale_y_tweener;
    protected Tweener attack_tweener;
    
    // Start is called before the first frame update
    void Start() {
        data.Health = data.MaxHealth;

        scale_x_tweener = transform.DOScaleX(1.25f, 0.3f)
            .SetLoops(2, LoopType.Yoyo)
            .SetAutoKill(false);
        scale_y_tweener = transform.DOScaleY(.8f, 0.3f)
            .SetLoops(2, LoopType.Yoyo)
            .SetAutoKill(false);

        OnMove += () => {
            Vector3 dir = (Target.transform.position - transform.position).normalized;
            if (dir.x > 0.01f && !spriteRenderer.flipX) spriteRenderer.flipX = true;
            else if (dir.x < -0.01f && spriteRenderer.flipX) spriteRenderer.flipX = false;
            rigidbody.MovePosition(transform.position + dir * data.Speed);
            if (!scale_x_tweener.IsPlaying()) scale_x_tweener.Restart();
            if (!scale_y_tweener.IsPlaying()) scale_y_tweener.Restart();
        };

        OnAttack += (Actor actor) => {
            // Debug.Log(name + " attacking!");

            // ------ placeholder attack animation
            Vector3 dir = (Target.transform.position - transform.position).normalized;
            if (attack_tweener == null || !attack_tweener.IsPlaying()) {
                attack_tweener = transform.DOPunchPosition(dir * Vector3.Distance(Target.transform.position, transform.position), data.AtkIntv, 3, 0);
                attack_tweener.Restart();
            }
            // ------


            actor.OnDamaged(data.Atk);
        };

        OnDamaged += (float dmg) => {
            data.Health -= Mathf.Max(0, dmg + data.Def);
            if (data.Health <= 0) {
                OnDie();
            }
        };

        OnDie += () => {
            gameObject.SetActive(false);
            data.Health = data.MaxHealth;
            GameManager.Instance.slimeCount -= 1;
            if (GameManager.Instance.slimeCount == 0) {
                GameManager.Instance.TurnOver();
            }
        };
    }

    private void Update() {
        if (Vector3.Distance(Target.transform.position, transform.position)
            <= data.AtkRange) {
            rigidbody.velocity = Vector2.zero;
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
            atkTimer -= Time.deltaTime;
            if (atkTimer <= 0) {
                OnAttack(Target);
                atkTimer = data.AtkIntv;
            }
        }
        data.Health = Mathf.Min(data.Health + Time.deltaTime, data.MaxHealth);
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Vector3.Distance(Target.transform.position, transform.position)
            > data.AtkRange) {
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
            OnMove();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        if (Vector3.Distance(Target.transform.position, transform.position)
            <= data.AtkRange) {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position, data.AtkRange);
    }
}
