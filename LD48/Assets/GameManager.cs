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

    public GameObject[] TurnStartGroup;

    private void Start() {
        // TurnStart(0);
    }

    public void TurnStart(int level=0) {
        UIManager.Instance.UIRoots[1].SetActive(false);
        slimeCount = FindObjectsOfType<Slime>().Length;
        
        foreach (var item in TurnStartGroup) {
            item.SetActive(true);
        }

        foreach (var group in groups) {
            foreach (Transform child in group.transform) {
                child.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                child.position = group.transform.position + (Vector3)Random.insideUnitCircle * 5;
                child.gameObject.SetActive(true);
            }
        }

    }

    public void TurnOver() {
        foreach (var item in TurnStartGroup) {
            item.SetActive(false);
        }

        UIManager.Instance.UIRoots[1].SetActive(true);
        foreach (var loc in UIManager.Instance.powerupLocations) {
            // loc.transform;
            loc.SetActive(true);
        }
    }
}
