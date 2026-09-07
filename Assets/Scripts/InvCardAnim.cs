using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InvCardAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float selectionOffset = 35f;
    public float hoverOffset = 15f;
    public float selectedScale = 1.15f;
    public float hoverScale = 1.08f;
    public float animationSpeed = 15f;

    public Image glowImage;

    private bool isSelected = false;
    private bool isHovered = false;
    private RectTransform rectTransform;
    private DoubleClick doubleClickScript;

    private Vector3 currentVisualOffset = Vector3.zero;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        doubleClickScript = GetComponent<DoubleClick>();

        if (glowImage != null)
        {
            glowImage.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (doubleClickScript != null)
        {
            if (isSelected != doubleClickScript.selected)
            {
                SetSelected(doubleClickScript.selected);
            }
        }

        AnimateVisuals();
    }

    public void SetSelected(bool state)
    {
        isSelected = state;
        if (glowImage != null)
        {
            glowImage.gameObject.SetActive(isSelected);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }

    private void AnimateVisuals()
    {
        if (rectTransform == null) return;

        float targetOffsetAmount = 0f;
        if (isSelected)
        {
            targetOffsetAmount = selectionOffset;
        }
        else if (isHovered)
        {
            targetOffsetAmount = hoverOffset;
        }

        Vector3 targetOffset = transform.up * targetOffsetAmount;

        rectTransform.localPosition -= currentVisualOffset;
        currentVisualOffset = Vector3.Lerp(currentVisualOffset, targetOffset, UnityEngine.Time.deltaTime * animationSpeed);
        rectTransform.localPosition += currentVisualOffset;

        float targetScaleValue = 1f;
        if (isSelected)
        {
            targetScaleValue = selectedScale;
        }
        else if (isHovered)
        {
            targetScaleValue = hoverScale;
        }

        Vector3 targetScale = Vector3.one * targetScaleValue;
        rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, targetScale, UnityEngine.Time.deltaTime * animationSpeed);
    }
}