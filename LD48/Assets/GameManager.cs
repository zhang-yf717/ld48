using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance {
        get {
            if (!instance) {
                instance = GameObject.FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public GameObject[] groups;
    public LayerMask slimeLayer;
    public int slimeCount;

    private void Start() {
        TurnStart(0);
    }

    public void TurnStart(int level) {
        UIManager.Instance.UIRoots[1].SetActive(false);
        slimeCount = FindObjectsOfType<Slime>().Length;
        
        foreach (var group in groups) {
            foreach (Transform child in group.transform) {
                child.position = group.transform.position + (Vector3)Random.insideUnitCircle * 5;
                child.gameObject.SetActive(true);
            }
        }

    }

    public void TurnOver() {
        UIManager.Instance.UIRoots[1].SetActive(true);
        foreach (var loc in UIManager.Instance.powerupLocations) {
            // loc.transform;
        }
    }
}
