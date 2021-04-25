using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeGroup : MonoBehaviour {
    [SerializeField]
    private Actor prototype;
    public Actor Prototype => prototype;
    public int count = 10;
    public Vector2 Pos {
        get => transform.position;
    }
    
    public void UpdatePrototype(ActorDecorator decorator) {
        prototype = decorator;
    }
}
