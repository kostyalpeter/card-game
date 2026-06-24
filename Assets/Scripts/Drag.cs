using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector2 originalPos;
    public float Distance = 350;
    [SerializeField] public static bool beingDragged;

    void Start()
    {
        originalPos = transform.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        beingDragged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
            transform.position = originalPos;
            beingDragged = false;
    }
}