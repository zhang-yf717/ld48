using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance {
        get {
            if (!instance) {
                instance = GameObject.FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    [SerializeField]
    protected GameObject[] UIRoots;
}
