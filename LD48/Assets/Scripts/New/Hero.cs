using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Actor
{
    private void Start() {
        OnDamaged += (float dmg) => {
            Debug.Log("Hero is Damaged");
        };
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        
        Gizmos.DrawWireSphere(transform.position, data.AtkRange);
    }
}
