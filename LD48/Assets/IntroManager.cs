using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public GameObject bg;
    public void StartGame() {
        GameManager.Instance.TurnStart();
        
    }

    public void DestroyBg() {
        Destroy(bg);
    }
    public void DestroySelf() {
        
        Destroy(gameObject);
    }
}
