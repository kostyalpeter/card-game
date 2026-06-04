using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector2 originalPos;
    Vector2 Right;
    Vector2 Left;
    public GameObject RightTarget;
    public GameObject LeftTarget;
    public float Distance = 350;

    void Start()
    {
        originalPos = transform.position;
        Right = RightTarget.transform.position;
        Left = LeftTarget.transform.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
            if (Vector2.Distance(transform.position, Right) >= Distance && Vector2.Distance(transform.position, Left) >= Distance)
            {
                transform.position = originalPos;
            }
            else if (Vector2.Distance(transform.position, Right) < Distance)
            {
                transform.position = Right;
            }
            else if (Vector2.Distance(transform.position, Left) < Distance)
            {
                transform.position = Left;
        }
    }
}