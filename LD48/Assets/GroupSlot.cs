using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GroupSlot : MonoBehaviour, IDropHandler {
    public void OnDrop(PointerEventData eventData) {
        // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition
        //     = GetComponent<RectTransform>().anchoredPosition;
        var draggable = eventData.pointerDrag.GetComponent<DraggableItem>();
        Destroy(draggable.gameObject);
    }
}
