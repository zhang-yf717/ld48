using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable_ATK : Draggable
{
    public float amount;
    public Sprite changeSprite;
    public override void ApplyEffect(int n) {
        // base.ApplyEffect(n);
        Debug.Log("group " + n.ToString() + " add " + amount + "ATK");
        foreach (Transform child in GameManager.Instance.groups[n].transform) {
            var slime = child.GetComponent<Slime>();
            slime.data.Atk += amount;
            slime.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = changeSprite;
            
        }
    }
}
