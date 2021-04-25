using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public SlimeGroup[] SlimeGroups;

    public int slimesCount { get; private set; }



    

    // Start is called before the first frame update
    void Start()
    {
        TurnStart(0);
    }

    public void TurnStart(int turn) {
        slimesCount = 0;
        foreach (var group in SlimeGroups) {
            Utils.SpawnEvenlyInCircle(group.Pos, 1, group.count, group.Prototype, SpawnSlimes);
            slimesCount += group.count;
        }
        

        Init();
    }

    private void Init() {
        UIManager.Instance.SetSlimeCount(slimesCount);
    }

    void SpawnSlimes(float x, float y, Actor slime) {
        Instantiate(slime, new Vector2(x, y), Quaternion.identity);
    }

    public bool CheckTurnEnd() {
        return slimesCount == 0;
    }

    public void OnSlimeCountChange() {
        slimesCount--;
        if (CheckTurnEnd()) {
            Debug.Log("Turn Ends");
        }
        UIManager.Instance.SetSlimeCount(slimesCount);
    }
    
}
