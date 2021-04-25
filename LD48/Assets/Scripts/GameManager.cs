using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Slime slime;
    public Transform[] spawnPosition;

    private static GameManager instance;
    public static GameManager Instance { 
        get {
            if (instance == null) {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public GameObject toolTip;

    // Start is called before the first frame update
    void Start()
    {
        
        Utils.EvenlyInCircle(spawnPosition[0].position, 3, 20, SpawnSlimes);
        Utils.EvenlyInCircle(spawnPosition[1].position, 3, 10, SpawnSlimes);
        Utils.EvenlyInCircle(spawnPosition[2].position, 3, 15, SpawnSlimes);
        Utils.EvenlyInCircle(spawnPosition[3].position, 3, 10, SpawnSlimes);
    }

    void SpawnSlimes(float x, float y) {
        Instantiate(slime, new Vector2(x, y), Quaternion.identity);
    }

    
}
