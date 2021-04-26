using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
    public int group = 0;
    public void OnDrop(PointerEventData eventData) {
        // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition
        //     = GetComponent<RectTransform>().anchoredPosition;
        var draggable = eventData.pointerDrag.GetComponent<Draggable>();
        draggable.ApplyEffect(group);
        Destroy(draggable.gameObject);
    }
}
