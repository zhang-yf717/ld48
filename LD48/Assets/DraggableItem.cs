using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DraggableItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,
    IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField]
    private Canvas canvas;
    private RectTransform rectTransform;
    private Vector3 start;
    private bool isMouseOver;

    private float tooltipTime = 2;
    private float timer;
    
    private void Start() {
        rectTransform = GetComponent<RectTransform>();
        start = rectTransform.localPosition;
        tooltipTime = 2;
        timer = tooltipTime;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        rectTransform.DOLocalMove(start, 1f);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        isMouseOver = false;
        timer = tooltipTime;
        GameManager.Instance.toolTip.GetComponent<CanvasGroup>().alpha = 0;
    }



    public void Update() {
        if (isMouseOver && timer > 0) {
            timer -= Time.deltaTime;
        }
        if (isMouseOver && timer <= 0) {
            if (GameManager.Instance.toolTip.GetComponent<CanvasGroup>().alpha == 0)
                GameManager.Instance.toolTip.GetComponent<CanvasGroup>().alpha = 1;
        } 
    }
}
