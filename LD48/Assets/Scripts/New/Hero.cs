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
            atkTimer = data.AtkIntv;

            // --- placeholder animation
            Vector3 dir = (actor.transform.position - transform.position).normalized;
            if (attack_tweener == null || !attack_tweener.IsPlaying()) {
                attack_tweener = transform.DOPunchPosition(dir * data.AtkRange / 2, data.AtkIntv/1.5f, 0, 0);
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
        Slime[] slimes = FindObjectsOfType<Slime>();
        foreach (var slime in slimes) {
            if (Vector2.Distance(slime.transform.position, 
                transform.position) <= data.AtkRange) {
                atkTimer -= Time.deltaTime;
                if (atkTimer <= 0) {
                    OnAttack(slime);
                    return;
                }
            }
        }
    }

    

    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, data.AtkRange);
    }
}
