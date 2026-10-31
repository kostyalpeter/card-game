using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationEvery : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 originalScale;
    private Vector3 targetScale;
    private RectTransform rectTransform;
    private bool isHovered;
    private bool isPressed;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = transform.localScale;
        targetScale = originalScale;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, UnityEngine.Time.deltaTime * 18f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
        if (!isPressed)
        {
            targetScale = originalScale * 1.05f;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        if (!isPressed)
        {
            targetScale = originalScale;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        targetScale = originalScale * 0.95f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        targetScale = isHovered ? originalScale * 1.05f : originalScale;
    }
}