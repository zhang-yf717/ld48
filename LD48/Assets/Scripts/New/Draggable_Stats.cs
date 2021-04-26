using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable_Stats : Draggable
{
    public float HealthDelta;
    public float AtkDelta;
    public float DefenceDelta;
    public float RegenDelta;

    public Sprite changeSprite;
    public override void ApplyEffect(int n) {
        // base.ApplyEffect(n);
        Debug.Log("group " + n.ToString() + " add " + AtkDelta + "ATK");
        foreach (Transform child in GameManager.Instance.groups[n].transform) {
            var slime = child.GetComponent<Slime>();
            slime.data.MaxHealth += HealthDelta;
            slime.data.Atk += AtkDelta;
            slime.data.Def += DefenceDelta;
            slime.data.Regen += RegenDelta;

            slime.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = changeSprite;
            
        }
    }
}
