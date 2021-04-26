using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Draggable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,
    IBeginDragHandler, IEndDragHandler, IDragHandler {

    private Canvas canvas;
    private Canvas Canvas {
        get {
            if (!canvas) canvas = GetComponentInParent<Canvas>();
            return canvas;
        }
    }
    public RectTransform RectTransform {
        get {
            if (rectTransform == null) {
                rectTransform = GetComponent<RectTransform>();
            }
            return rectTransform;
        }
    }
    public CanvasGroup CanvasGroup {
        get {
            if (canvasGroup == null) {
                canvasGroup = GetComponent<CanvasGroup>();
            }
            return canvasGroup;
        }
    }



    private float timer;

    private bool isDragging;
    private bool isMouseOver;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 start;

    private void Start() {
        start = RectTransform.localPosition;
        timer = UIManager.Instance.infoTip_ShowTime;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        isDragging = true;
        //UIManager.Instance.InfoTip.SetActive(false);
        CanvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log(Canvas.scaleFactor);
        RectTransform.anchoredPosition += eventData.delta / Canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {

        RectTransform.DOLocalMove(start, .2f);
        CanvasGroup.blocksRaycasts = true;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        isMouseOver = false;
        timer = UIManager.Instance.infoTip_ShowTime;
        UIManager.Instance.InfoTip.SetActive(false);
    }

    public void Update() {
        if (!isDragging && isMouseOver) {
            if (timer > 0) {
                timer -= Time.deltaTime;
            } else if (timer <= 0) {
                if (!UIManager.Instance.InfoTip.activeSelf)
                    UIManager.Instance.InfoTip.SetActive(true);
            }
        }
    }

    protected virtual void OnDestroy() {
        Debug.Log(name + " is Destroyed...");
    }

    public virtual void ApplyEffect(int n) {

    }
}
