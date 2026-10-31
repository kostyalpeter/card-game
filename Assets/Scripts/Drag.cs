using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 originalAnchoredPos;
    [SerializeField] public static bool beingDragged;
    private RectTransform rectTransform;
    private RectTransform canvasRectTransform;
    private Canvas canvas;
    private Vector2 pointerOffset;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalAnchoredPos = rectTransform.anchoredPosition;
        canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvasRectTransform = canvas.transform as RectTransform;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (DoubleClick.Countdown) return;

        beingDragged = true;

        if (canvasRectTransform != null)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRectTransform,
                eventData.position,
                canvas.worldCamera,
                out Vector2 localPointerPos
            );
            pointerOffset = rectTransform.anchoredPosition - localPointerPos;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (DoubleClick.Countdown) return;

        if (canvasRectTransform != null && canvas != null)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRectTransform,
                eventData.position,
                canvas.worldCamera,
                out Vector2 localPointerPos
            );

            rectTransform.anchoredPosition = localPointerPos + pointerOffset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = originalAnchoredPos;
        beingDragged = false;
    }
}