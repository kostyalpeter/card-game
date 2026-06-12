using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector2 originalPos;
    Vector2 Right;
    Vector2 Left;
    Vector2 Middle;
    public GameObject RightTarget;
    public GameObject LeftTarget;
    public GameObject MiddleTarget;
    public float Distance = 350;
    [SerializeField] public static bool beingDragged;

    void Start()
    {
        originalPos = transform.position;
        Right = RightTarget.transform.position;
        Left = LeftTarget.transform.position;
        Middle = MiddleTarget.transform.position;
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
        if (Vector2.Distance(transform.position, Right) >= Distance && Vector2.Distance(transform.position, Left) >= Distance && !gameObject.CompareTag("Card"))
        {
            transform.position = originalPos;
        }
        else if (Vector2.Distance(transform.position, Right) < Distance && gameObject.CompareTag("Card"))
        {
            transform.position = Right;
            transform.rotation = RightTarget.transform.rotation;
        }
        else if (Vector2.Distance(transform.position, Left) < Distance && gameObject.CompareTag("Card"))
        {
            transform.position = Left;
            transform.rotation = LeftTarget.transform.rotation;
        }
        else if (Vector2.Distance(transform.position, Middle) < Distance && gameObject.CompareTag("Card"))
        {
            transform.position = Middle;
            transform.rotation = MiddleTarget.transform.rotation;
        }
        beingDragged = false;
    }
}