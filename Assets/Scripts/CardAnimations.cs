using UnityEngine;
using UnityEngine.EventSystems;

public class CardAnimations : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    private static CardAnimations currentSelectedCard;

    [Header("Hover Beallitasok")]
    public float liftAmount = 30f;
    public float scaleMultiplier = 1.05f;
    public float tiltAmount = 35f;

    [Header("Kattintas & Lenyomas (Balatro Juice)")]
    public float selectLiftAmount = 60f;
    public float pressScaleMultiplier = 0.9f;
    public float pressYOffset = -10f;

    [Header("Lebeges")]
    public bool enableIdleFloat = true;
    public float floatSpeed = 2f;
    public float floatAmount = 4f;

    [Header("Simitas")]
    public float moveSmoothTime = 0.04f;
    public float tiltSmoothTime = 0.05f;

    private RectTransform rectTransform;
    private Vector3 initialScale;
    private Vector2 currentPosOffset;
    private Vector2 targetPosOffset;
    private Vector3 targetScale;

    private Vector2 currentPosVelocity;
    private Vector3 currentScaleVelocity;

    private Vector3 currentRotationEuler;
    private Vector3 targetRotationEuler;
    private Vector3 rotationVelocity;

    private float idleOffset;
    public bool isSelected = false;
    private bool isPressed = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        initialScale = rectTransform.localScale;
        targetScale = initialScale;
        currentRotationEuler = rectTransform.localEulerAngles;
        idleOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        float idleY = (enableIdleFloat && !isPressed) ? Mathf.Sin((UnityEngine.Time.time + idleOffset) * floatSpeed) * floatAmount : 0f;
        Vector2 finalOffset = targetPosOffset + new Vector2(0, idleY);

        Vector2 prevOffset = currentPosOffset;
        currentPosOffset = Vector2.SmoothDamp(currentPosOffset, finalOffset, ref currentPosVelocity, moveSmoothTime);
        
        Vector2 deltaPos = currentPosOffset - prevOffset;
        rectTransform.anchoredPosition += deltaPos;

        Vector3 nextScale = Vector3.SmoothDamp(rectTransform.localScale, targetScale, ref currentScaleVelocity, moveSmoothTime);

        currentRotationEuler.x = Mathf.SmoothDampAngle(currentRotationEuler.x, targetRotationEuler.x, ref rotationVelocity.x, tiltSmoothTime);
        currentRotationEuler.y = Mathf.SmoothDampAngle(currentRotationEuler.y, targetRotationEuler.y, ref rotationVelocity.y, tiltSmoothTime);
        currentRotationEuler.z = Mathf.SmoothDampAngle(currentRotationEuler.z, targetRotationEuler.z, ref rotationVelocity.z, tiltSmoothTime);

        Quaternion nextRot = Quaternion.Euler(currentRotationEuler);

        if ((nextScale - rectTransform.localScale).sqrMagnitude > 0.0001f)
            rectTransform.localScale = nextScale;

        if (Quaternion.Angle(rectTransform.localRotation, nextRot) > 0.01f)
            rectTransform.localRotation = nextRot;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.SetAsLastSibling();
        
        if (!isSelected && !isPressed)
        {
            targetPosOffset = new Vector2(0, liftAmount);
            targetScale = initialScale * scaleMultiplier;
        }
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint))
        {
            float normX = Mathf.Clamp(localPoint.x / (rectTransform.sizeDelta.x / 2f), -1f, 1f);
            float normY = Mathf.Clamp(localPoint.y / (rectTransform.sizeDelta.y / 2f), -1f, 1f);
            targetRotationEuler = new Vector3(-normY * tiltAmount, normX * tiltAmount, 0f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isSelected && !isPressed)
        {
            targetPosOffset = Vector2.zero;
            targetScale = initialScale;
        }
        
        targetRotationEuler = Vector3.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        rectTransform.SetAsLastSibling();

        float baseLift = isSelected ? selectLiftAmount : liftAmount;
        targetPosOffset = new Vector2(0, baseLift + pressYOffset);
        targetScale = initialScale * pressScaleMultiplier;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isSelected)
        {
            DeselectCard();
        }
        else
        {
            if (currentSelectedCard != null && currentSelectedCard != this)
            {
                currentSelectedCard.DeselectCard();
            }

            isSelected = true;
            currentSelectedCard = this;

            rectTransform.SetAsLastSibling();
            targetPosOffset = new Vector2(0, selectLiftAmount);
            targetScale = initialScale * (scaleMultiplier * 1f);
        }
    }

    public void DeselectCard()
    {
        isSelected = false;
        if (currentSelectedCard == this)
        {
            currentSelectedCard = null;
        }

        targetPosOffset = Vector2.zero;
        targetScale = initialScale;
    }
}