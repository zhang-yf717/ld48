using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FllowCursor : MonoBehaviour
{
    [SerializeField]
    private Canvas parentCanvas;

    public void Start() {
        SetPos();
    }

    public void Update() {
        SetPos();
    }

    private void OnEnable() {
        SetPos();
    }

    private void SetPos() {
        Vector2 pos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform, Input.mousePosition,
            parentCanvas.worldCamera,
            out pos);

        transform.position = parentCanvas.transform.TransformPoint(pos);
    }
}
