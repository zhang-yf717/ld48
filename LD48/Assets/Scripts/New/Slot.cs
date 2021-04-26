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
        draggable.gameObject.SetActive(false);
        var cnt = 0;
        foreach (var loc in UIManager.Instance.powerupLocations) {
            // loc.transform;
            if (loc.activeSelf == true) cnt++;
        }
        if (cnt == 4) GameManager.Instance.TurnStart(0);
    }
}
