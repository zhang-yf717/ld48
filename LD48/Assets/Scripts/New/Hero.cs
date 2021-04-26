using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Actor
{
    protected Tweener attack_tweener;
    protected Tweener damaged_tweener;

    private void Start() {
        atkTimer = data.AtkIntv;

        OnAttack += (Actor actor) => {
            Debug.Log("Hero attacks " + actor.name);
            atkTimer = data.AtkIntv;

            // --- placeholder animation
            Vector3 dir = (actor.transform.position - transform.position).normalized;
            if (attack_tweener == null || !attack_tweener.IsPlaying()) {
                attack_tweener = transform.DOPunchPosition(dir * Vector3.Distance(actor.transform.position, transform.position), data.AtkIntv/1.5f, 1, 0);
                attack_tweener.Play();
            }
            // -------------------------

            actor.OnDamaged(data.Atk);
        };

        OnDamaged += (float dmg) => {
            Debug.Log("Hero is Damaged by " + dmg);
            data.Health -= dmg;

            // --- placeholder animation
            if (damaged_tweener == null|| !damaged_tweener.IsPlaying()) {
                damaged_tweener = transform.GetChild(0)
                                    .GetComponent<SpriteRenderer>()
                                    .DOColor(new Color(.8f, 151 / 255, 144 / 255), .2f)
                                    .SetLoops(2, LoopType.Yoyo);
            }
            // -------------------------
        };
    }

    private void Update() {
        var slimes = Physics2D.OverlapCircleAll(transform.position, data.AtkRange, GameManager.Instance.slimeLayer);
        
        if (slimes.Length > 0) {
            atkTimer -= Time.deltaTime;
            var slime = slimes[0].GetComponent<Actor>();
            if (atkTimer <= 0) {
                OnAttack(slime);
                return;
            }
        }
    }

    

    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, data.AtkRange);
    }
}
